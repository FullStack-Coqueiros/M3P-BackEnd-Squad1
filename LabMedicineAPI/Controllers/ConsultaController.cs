﻿using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Consulta;
using LabMedicineAPI.Service.Consulta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LabMedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaServices _consultaServices;

        public ConsultaController(IConsultaServices consultaServices)
        {
            _consultaServices = consultaServices;
        }

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
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Nenhum resultado encontrado para o ID do paciente fornecido");
                }

                return StatusCode(HttpStatusCode.OK.GetHashCode(), consultaDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),ex);
            }
        }

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
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateConsulta(int id, [FromBody] ConsultaUpdateDTO consultaUpdateDTO)
        {
            try
            {
                var consulta = _consultaServices.ConsultaUpdateDTO(id, consultaUpdateDTO);

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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
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
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

    }
}