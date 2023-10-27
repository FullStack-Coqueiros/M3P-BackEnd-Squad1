using LabMedicineAPI.DTOs.Login;
using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Interfaces;
using LabMedicineAPI.Service.Auth;
using LabMedicineAPI.Service.Usuario;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ILoginService _loginServices;
        public UsuariosController(IUsuarioServices services, ILoginService login)
        {
            _services = services;
            _loginServices = login;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Login([FromBody] LoginDTO login)
        {
            try
            {
                if (_loginServices.Login(login) == false)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Não foi possível logar.");
                }
                login.Logado = true;

                string tokenJwt = _loginServices.GeraTokenJWT(login);
                return StatusCode(HttpStatusCode.OK.GetHashCode(), tokenJwt);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
            }
        }
        [AllowAnonymous]
        [HttpPost("login/resetarsenha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        IActionResult ResetSenha([FromBody] ResetSenhaDTO resetSenhaDTO)
        {
            try
            {
                string novaSenha = _loginServices.GeraNovaSenha(resetSenhaDTO);
                if (novaSenha == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "email não cadastrado.");
                }

                resetSenhaDTO.SenhaNova = novaSenha;
                resetSenhaDTO.SenhaAntiga = null;
                return StatusCode(HttpStatusCode.OK.GetHashCode(), resetSenhaDTO);
            }
            catch (Exception)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
            }

        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] UsuarioCreateDTO usuarioCreate)
        {
            try
            {
                var usuario = _services.CreateUsuario(usuarioCreate);
                if (usuario == null)
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Existem dados inválidos na requisição");

                bool verificaCpfEmail = _services.Get()
                                .Any(a => a.Cpf == usuarioCreate.CPF || a.Email == usuarioCreate.Email);
                if (verificaCpfEmail)
                {
                    return StatusCode(HttpStatusCode.Conflict.GetHashCode(), "Cpf e/ou email ja cadastrado(s).");
                }
                usuarioCreate.StatusSistema = true;
                UsuarioGetDTO usuarioGet = _services.CreateUsuario(usuarioCreate);
                return Created("Usuario salvo com sucesso.", usuarioGet);

            }
            catch (Exception)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
            }
        }
        [Authorize(Roles = "Administrador")]
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
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno no servidor");
            }
        }
        [Authorize(Roles = "Administrador")]
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
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro interno no servidor");

            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult Update([FromRoute] int id, [FromBody] UsuarioUpdateDTO usuarioUpdate)
        {
            try
            {
                UsuarioGetDTO usuario = _services.GetById(id);
                if (usuario == null)
                    return BadRequest("Requisição com dados inválidos");
                UsuarioGetDTO usuarioGet = _services.UsuarioUpdateDTO(id, usuarioUpdate);
                return Ok(usuarioGet);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor");

            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult Delete(int id)
        {
            try
            {
                var where = _services.GetById(id);
                if (where == null)
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

