using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class TokenService
    {
        public Token CreateToken(IdentityUser<int> usuario, string role)
        {
            //Criado o array de clains

            Claim[] direitosUsuario = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            //Gerar a chave para criptografar o token
            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9")
                );

            //criar credenciais
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);


            //gerar token
            var token = new JwtSecurityToken(
                    claims: direitosUsuario,
                    signingCredentials: credenciais,
                    expires: DateTime.UtcNow.AddHours(1)
                );

            //transformamos o nosso token em string
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            //retornamos o Token
            return new Token(tokenString);
        }
    }
}
