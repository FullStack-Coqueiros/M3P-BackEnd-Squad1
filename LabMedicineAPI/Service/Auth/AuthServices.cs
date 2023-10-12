using LabMedicineAPI.DTOs.Login;
using LabMedicineAPI.Interfaces;
using LabMedicineAPI.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LabMedicineAPI.Service.Auth
{
    public class AuthServices : IAuthServices
    {
        private readonly IUserServices _userService;

        private readonly string _chaveJwt;

        public AuthServices(IUserServices userService, IConfiguration configuration)
        {
            _userService = userService;

            _chaveJwt = configuration.GetSection("jwtTokenChave").Get<string>();
        }

        public bool Autenticar(LoginDTO login)
        {
            var usuario = new LoginDTO
            {
                Email = login.Email,
                Senha = login.Senha // Você pode definir a senha aqui se for necessário
            };
            var usuarioModel = _userService.ObterPorLogin(usuario);
            if (usuario != null)
            {
                return usuario.Senha == Criptografia.CriptografarSenha(login.Senha);

            }
            return false;

        }

        public string GerarToken(LoginDTO loginDTO)
        {

            var usuario = _userService.ObterPorLogin(loginDTO);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_chaveJwt);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                  {
                      new Claim(ClaimTypes.Name, usuario.Email),
                      new Claim("Nome", usuario.NomeCompleto),
                      new Claim("Interno", usuario.Email.ToString()),
                      new Claim(ClaimTypes.Role, usuario.Tipo.ToString()),// determina as permissões de acesso
                  }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }
    }
}
