using LabMedicineAPI.DTOs.Login;
using LabMedicineAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabMedicineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authService;

        public AuthController(IAuthServices authService)
        {
            _authService = authService;
        }
        [HttpPost("logar")]
        [AllowAnonymous]
        public IActionResult Logar(LoginDTO loginDTO)
        {
            if (!_authService.Autenticar(loginDTO))
                return Unauthorized("Email ou Senha inválidos");

            string token = _authService.GerarToken(loginDTO);
            return Ok(token);
        }
    }
}
