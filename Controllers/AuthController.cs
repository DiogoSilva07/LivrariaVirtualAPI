using LivrariaVirtualAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LivrariaVirtualAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin login)
        {
            string role;

            // Validação de usuário e atribuição de papéis
            if (login.UserName.Equals("Gerente") && login.Password.Equals("123456"))
            {
                role = "Gerente";
            }
            else if (login.UserName.Equals("Funcionário") && login.Password.Equals("654321"))
            {
                role = "Funcionário";
            }
            else
            {
                return Unauthorized(new { Mensagem = "Credenciais Inválidas", Codigo = 001 });
            }

            // Gerar token baseado no papel do usuário
            var token = GerarTokenJWT(role);
            return Ok(new { Token = token });
        }


        [HttpGet("RotaProtegida")]
        [Authorize] //Restringe o acesso somente quem possuir o token.
        public IActionResult RotaProtegida()
        {
            return Ok("Acessando uma rota protegida");
        }


        private string GerarTokenJWT(string role)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Role, role) // Define o papel do usuário no token
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a2bb3b00a9c5066fa4258401a60e4ef301ece1534bd3b24be2a7eec159f31a8e")); // Chave para assinatura do Token.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // Criptografia

            var token = new JwtSecurityToken // Configuração do Token
            (
                issuer: "api-autenticação",
                audience: "api-registro",
                claims: claims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
