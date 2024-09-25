using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PrjRRHH.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PrjRRHH.Controllers
{
    [ApiController]
    [Route("/usuario")]
    public class UsuarioController:ControllerBase
    {
        public IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("/signin")]
        public dynamic InicioSesion([FromBody] UserSignInDto usuarioNuevo)
        {
            string user = usuarioNuevo.Usuario;
            string password = usuarioNuevo.Password;

            //Codigo para buscar el usuario en la BD

            var jwt = _configuration.GetSection("Jwt").Get<JwtDto>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", usuarioNuevo.Usuario.ToString()),
            };

            var key = new SymmetricSecurityKey( System.Text.Encoding.UTF8.GetBytes(jwt.Key) );
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signIn
                );

            return new
            {
                success = true,
                message = "Credenciales creadas Correctamente",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };

        }
    }
}
