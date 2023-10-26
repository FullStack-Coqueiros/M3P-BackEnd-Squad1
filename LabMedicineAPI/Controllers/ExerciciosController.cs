using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Exame;
using LabMedicineAPI.DTOs.Exercicio;
using LabMedicineAPI.DTOs.Medicamento;
using LabMedicineAPI.Service.Exercicio;
using LabMedicineAPI.Service.Medicamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LabMedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciciosController : ControllerBase
    {
        private readonly IExercicioServices _services;

        public ExerciciosController(IExercicioServices services)
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
                var exercicioDTO = _services.Get(pacienteId);

                if (exercicioDTO == null || !exercicioDTO.Any())

                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Nenhum resultado encontrado para o ID do paciente fornecido");

                return StatusCode(HttpStatusCode.OK.GetHashCode(), exercicioDTO);
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
        public IActionResult CreateExercicio([FromBody] ExercicioCreateDTO exercicioCreateDTO)
        {
            try
            {
                var exercicio = _services.ExercicioCreateDTO(exercicioCreateDTO);


                if (exercicio == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para registro de exercicio");
                }

                return StatusCode(HttpStatusCode.Created.GetHashCode(), exercicio);
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
        public IActionResult UpdateExercicio(int id, [FromBody] ExercicioUpdateDTO exercicioUpdateDTO)
        {
            try
            {
                var exercicio = _services.ExercicioUpdateDTO(id, exercicioUpdateDTO);

                if (exercicio == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a atualização de exercicios");
                }

                return StatusCode(HttpStatusCode.OK.GetHashCode(), exercicio);
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
                var result = _services.DeleteExercicio(id);

                if (result == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a exclusão de exercicio");
                }

                return StatusCode(HttpStatusCode.Accepted.GetHashCode(), "Exercicio excluído com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Ocorreu um erro interno no servidor");
            }

        }
    }
}