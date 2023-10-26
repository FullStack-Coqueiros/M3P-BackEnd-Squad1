using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Exame;
using LabMedicineAPI.DTOs.Medicamento;
using LabMedicineAPI.Service.Medicamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LabMedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosController : ControllerBase
    {
        private readonly IMedicamentoServices _services;

        public MedicamentosController(IMedicamentoServices services)
        {
            _services = services;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromQuery] int? pacienteId)
        {
            try
            {
                var medicacaoDTO = _services.Get(pacienteId);

                if (medicacaoDTO == null || !medicacaoDTO.Any())

                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Nenhum resultado encontrado para o ID do paciente fornecido");

                return StatusCode(HttpStatusCode.OK.GetHashCode(), medicacaoDTO);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Ocorreu um erro interno no servidor");
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateMedicacao([FromBody] MedicamentoCreateDTO medicamentoCreateDTO)
        {
            try
            {
                var medicamento = _services.MedicamentoCreateDTO(medicamentoCreateDTO);


                if (medicamento == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para registro de medicamentos");
                }

                return StatusCode(HttpStatusCode.Created.GetHashCode(), medicamento);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno no servidor");
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateMedicamento(int id, [FromBody] MedicamentoUpdateDTO medicamentoUpdateDTO)
        {
            try
            {
                var medicamento = _services.MedicamentoUpdateDTO(id, medicamentoUpdateDTO);

                if (medicamento == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a atualização da medicamentos");
                }

                return StatusCode(HttpStatusCode.OK.GetHashCode(), medicamento);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _services.DeleteMedicamento(id);

                if (result == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a exclusão de medicamentos");
                }

                return StatusCode(HttpStatusCode.Accepted.GetHashCode(), "Medicamento excluído com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Ocorreu um erro interno no servidor");
            }

        }
    }
}