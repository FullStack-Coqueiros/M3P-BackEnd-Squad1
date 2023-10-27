using LabMedicineAPI.DTOs.Login;
using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Service.Usuario;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LabMedicineAPI.Service.Auth
{
    public class LoginService : ILoginService
    {
        const string CHARS = "P0O9I8U7Y6T5R4E3W2Q1";
        private readonly IUsuarioServices _usuarios;
        private readonly Random _random;
        private readonly string _chaveJwt;

        public LoginService(IUsuarioServices usuarios, IConfiguration configuration)
        {
            _usuarios = usuarios;
            _random = new Random();
            _chaveJwt = configuration.GetSection("jwtTokenChave").Get<string>();
        }
        public bool Login(LoginDTO login)
        {
            UsuarioGetDTO usuario = _usuarios.GetByEmail(login.Email);
            if (usuario == null)
            {
                return false;
            }
            else
            {
                if (usuario.Senha != login.Senha)
                {
                    return false;
                }
            }

            return true;
        }
        public string GeraTokenJWT(LoginDTO login)
        {
            UsuarioGetDTO usuario = _usuarios.GetByEmail(login.Email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_chaveJwt);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim("Nome", usuario.NomeCompleto),
                    new Claim("Tipo", usuario.Tipo),
                    new Claim("Id", usuario.Id.ToString()),
                    new Claim("StatusSistema", usuario.StatusSistema.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Tipo.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GeraNovaSenha(ResetSenhaDTO resetSenha)
        {
            UsuarioGetDTO usuario = _usuarios.GetByEmail(resetSenha.Email);
            if (usuario == null)
            {
                return null;
            }

            return new string(Enumerable.Repeat(CHARS, 12).Select(s => s[_random.Next(s.Length)]).ToArray());
        }



    }
}
