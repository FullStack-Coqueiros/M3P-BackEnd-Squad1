using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.Service.Paciente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Net;

namespace LabMedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteServices _services;

        public PacientesController(IPacienteServices services)
        {
            _services = services;
        }

        [Authorize(Roles = "Administrador, Medico")]
        [Authorize(Policy = "StatusSistemaAtivo")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<PacienteGetDTO> pacientes = _services.Get();
                if (pacientes != null)
                    return StatusCode(HttpStatusCode.OK.GetHashCode(), pacientes);

                return BadRequest("Não foi encontrado nenhum usuario cadastrado no sistema");

            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno no servidor");
            }
        }

        [Authorize(Roles = "Administrador, Medico")]
        [Authorize(Policy = "StatusSistemaAtivo")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                PacienteGetDTO paciente = _services.GetById(id);
                if (paciente != null)
                    return StatusCode(HttpStatusCode.OK.GetHashCode(), paciente);

                return BadRequest("Não foi localizado o pacinete com o Id fornecido");

            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno no servidor");

            }
        }

        [Authorize(Roles = "Administrador, Medico")]
        [Authorize(Policy = "StatusSistemaAtivo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Post([FromBody] PacienteEnderecoCreateDTO pacienteEnderecoCreateDTO)
        {
            try
            {
                var paciente = _services.CriarPacienteEndereco(pacienteEnderecoCreateDTO);

                return StatusCode(StatusCodes.Status201Created, "Paciente cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("CPF"))
                {
                    return StatusCode(StatusCodes.Status409Conflict, "Conflito de CPF: ");
                }
                else if (ex.Message.Contains("email"))
                {
                    return StatusCode(StatusCodes.Status409Conflict, "Conflito de email: ");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor");
                }
            }
        }

        [Authorize(Roles = "Administrador, Medico")]
        [Authorize(Policy = "StatusSistemaAtivo")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PacienteEnderecoUpdate(int id, [FromBody] PacienteEnderecoUpdateDTO pacienteEnderecoUpdate)
        {
            try
            {
                var pacienteAtualizado = _services.PacienteEnderecoUpdate(id, pacienteEnderecoUpdate);
                if (pacienteAtualizado != null)
                    return Ok(pacienteAtualizado);
               
                return BadRequest("Requisição com dados inválidos");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [Authorize(Roles = "Administrador, Medico")]
        [Authorize(Policy = "StatusSistemaAtivo")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _services.DeletePaciente(id);

                if (result == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a exclusão do paciente");
                }

                return StatusCode(HttpStatusCode.Accepted.GetHashCode(), "Paciente excluído dos registros com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
            }
        }

    }

}
