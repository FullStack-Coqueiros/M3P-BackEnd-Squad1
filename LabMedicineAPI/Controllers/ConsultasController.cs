using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Consulta;
using LabMedicineAPI.Service.Consulta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace LabMedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaServices _consultaServices;

        public ConsultasController(IConsultaServices consultaServices)
        {
            _consultaServices = consultaServices;
        }

        [Authorize(Roles = "Administrador, Médico")]
        [Authorize(Policy = "StatusSistemaAtivo")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromQuery] int? pacienteId)
        {
            try
            {
                var consultaDTO = _consultaServices.Get(pacienteId);
                
                if (consultaDTO == null || !consultaDTO.Any())
                
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Nenhum resultado encontrado para o ID do paciente fornecido");
                
                return StatusCode(HttpStatusCode.OK.GetHashCode(), consultaDTO);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),"Ocorreu um erro interno no servidor");
            }
        }

        [Authorize(Roles = "Administrador, Médico")]
        [Authorize(Policy = "StatusSistemaAtivo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateConsulta([FromBody] ConsultaCreateDTO consultaCreateDTO)
        {
            try
            {
                var consulta = _consultaServices.ConsultaCreateDTO(consultaCreateDTO);

                if (consulta == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a criação da consulta");
                }

                return StatusCode(HttpStatusCode.Created.GetHashCode(), consulta);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),"Erro interno no servidor");
            }
        }

        [Authorize(Roles = "Administrador, Médico")]
        [Authorize(Policy = "StatusSistemaAtivo")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateConsulta(int id, [FromBody] ConsultaUpdateDTO consultaUpdateDTO)
        {
            try
            {
                var consulta = _consultaServices.ConsultaUpdate(id, consultaUpdateDTO);

                if (consulta == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a atualização da consulta");
                }

                return StatusCode(HttpStatusCode.OK.GetHashCode(), consulta);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [Authorize(Roles = "Administrador, Médico")]
        [Authorize(Policy = "StatusSistemaAtivo")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _consultaServices.DeleteConsulta(id);

                if (result == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Dados inválidos fornecidos para a exclusão da consulta");
                }

                return StatusCode(HttpStatusCode.Accepted.GetHashCode(), "Consulta excluída com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),"Ocorreu um erro interno no servidor");
            }
        }

    }
}
