using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Consulta;
using LabMedicineAPI.DTOs.Exame;
using LabMedicineAPI.Model;
using LabMedicineAPI.Service.Exame;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LabMedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly IExameServices _examesServices;

        public ExameController(IExameServices examesServices)
        {
            _examesServices = examesServices;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromQuery] int? pacienteId)
        {
            try
            {
                var exameDTO = _examesServices.Get(pacienteId);

                if (exameDTO == null || !exameDTO.Any())

                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Nenhum resultado encontrado para o ID do paciente fornecido");

                return StatusCode(HttpStatusCode.OK.GetHashCode(), exameDTO);
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
        public IActionResult CreateExame([FromBody] ExameCreateDTO exameCreateDTO)
        {
            try
            {
                var exame = _examesServices.ExameCreateDTO(exameCreateDTO);
               

                if (exame == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a criação do exame");
                }

                return StatusCode(HttpStatusCode.Created.GetHashCode(), exame);
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
        public IActionResult UpdateExame(int id, [FromBody] ExameUpdateDTO exameUpdateDTO)
        {
            try
            {
                var exame = _examesServices.ExameUpdate(id, exameUpdateDTO);

                if (exame == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a atualização da consulta");
                }

                return StatusCode(HttpStatusCode.OK.GetHashCode(), exame);
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
                    var result = _examesServices.DeleteExame(id);

                    if (result == null)
                    {
                        return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a exclusão do exame");
                    }

                    return StatusCode(HttpStatusCode.Accepted.GetHashCode(), "Exame excluído com sucesso");
                }
                catch (Exception)
                {
                    return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Ocorreu um erro interno no servidor");
                }

            }
        }
    }
