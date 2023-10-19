using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.Service.Paciente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Net;

namespace LabMedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteServices _services;

        public PacienteController(IPacienteServices services)
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<PacienteGetDTO>pacientes = _services.Get();
                if (pacientes != null)
                    return StatusCode(HttpStatusCode.OK.GetHashCode(), pacientes);

                return BadRequest("Não foi encontrado nenhum usuario cadastrado no sistema");

            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno no servidor");
            }


        }
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Post([FromBody] PacienteCreateDTO pacienteCreateDTO)
        {
            try
            {
                var paciente = _services.PacienteCreateDTO(pacienteCreateDTO);
                
                if (paciente != null)

                    return Ok("Paciente cadastrado com sucesso");

                return BadRequest("Dados inválidos fornecidos para a criação do paciente");

            }
            // implantar excepyion para conflito de cpf e email
            
            catch (Exception)
            {         
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PacienteUpdateDTO(int id, [FromBody]PacienteUpdateDTO pacienteUpdate)
        {
            try
            {
                var paciente = _services.PacienteUpdateDTO(id, pacienteUpdate);
                if (paciente != null)
                    return BadRequest("Requisição com dados inválidos");

                return Ok(paciente);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor");

            }
        }
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
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }


    }

}
