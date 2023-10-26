using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Dieta;
using LabMedicineAPI.DTOs.Exame;
using LabMedicineAPI.DTOs.Exercicio;
using LabMedicineAPI.DTOs.Medicamento;
using LabMedicineAPI.Service.Dieta;
using LabMedicineAPI.Service.Exercicio;
using LabMedicineAPI.Service.Medicamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LabMedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietasController : ControllerBase
    {
        private readonly IDietaServices _services;

        public DietasController(IDietaServices services)
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
                var dietaDTO = _services.Get(pacienteId);

                if (dietaDTO == null || !dietaDTO.Any())

                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Nenhum resultado encontrado para o ID do paciente fornecido");

                return StatusCode(HttpStatusCode.OK.GetHashCode(), dietaDTO);
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
        public IActionResult CreateExercicio([FromBody] DietaCreateDTO dietaCreateDTO)
        {
            try
            {
                var dieta = _services.DietaCreateDTO(dietaCreateDTO);


                if (dieta == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para registro de dieta");
                }

                return StatusCode(HttpStatusCode.Created.GetHashCode(), dieta);
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
        public IActionResult UpdateDieta(int id, [FromBody] DietaUpdateDTO dietaUpdateDTO)
        {
            try
            {
                var dieta = _services.DietaUpdateDTO(id, dietaUpdateDTO);

                if (dieta == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a atualização de dieta");
                }

                return StatusCode(HttpStatusCode.OK.GetHashCode(), dieta);
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
                var result = _services.DeleteDieta(id);

                if (result == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a exclusão de dieta");
                }

                return StatusCode(HttpStatusCode.Accepted.GetHashCode(), "Dieta excluída com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Ocorreu um erro interno no servidor");
            }

        }
    }
}