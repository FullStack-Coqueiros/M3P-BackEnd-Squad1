using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Service.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LabMedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServices _services;

        public UsuariosController(IUsuarioServices services)
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult Get()
        {
            try
            {
                IEnumerable<UsuarioGetDTO> usuarios = _services.Get();
                if (usuarios != null)
                    return StatusCode(HttpStatusCode.OK.GetHashCode(), usuarios);

                return NotFound("Não foi encontrado nenhum usuario cadastrado no sistema");

            }
            catch(Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),"Erro interno no servidor");
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
                UsuarioGetDTO usuario = _services.GetById(id);
                if (usuario != null)
                    return StatusCode(HttpStatusCode.OK.GetHashCode(), usuario);

                return BadRequest("Não foi localizado o usuario com o Id fornecido");

            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),"Erro interno no servidor");

            }

            if (nome == "vitor")
            {
                return Ok("Usuario Bloqueado");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Post([FromBody] UsuarioCreateDTO usuarioCreateDTO)
        {
            try
            {
                var usuario = _services.UsuarioCreateDTO(usuarioCreateDTO);

                if (usuario != null)
                {
                    return Ok("Usuario registrado com sucesso");
                }
                return BadRequest("Dados inválidos fornecidos para a criação do usuario");

            }
            // implantar excepyion para conflito de cpf e email

            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update([FromRoute]int id, [FromBody] UsuarioUpdateDTO usuarioUpdate)
        {
            try
            {
                UsuarioGetDTO usuario = _services.GetById(id);
                if (usuario == null)
                    return BadRequest("Requisição com dados inválidos");
                UsuarioGetDTO usuarioGet = _services.UsuarioUpdateDTO(id,usuarioUpdate);
                return Ok(usuarioGet);
            }
            catch
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
                var where = _services.GetById(id);
                if(where == null)
                   return BadRequest("Dados inválidos fornecidos para a exclusão do usuário");
                
                var result = _services.DeleteUsuario(id);
                return StatusCode(HttpStatusCode.Accepted.GetHashCode(), "Usuario excluído dos registros com sucesso");
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Ocorreu um erro interno no servidor");
            }
        }
    }
}
