using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UsuariosAPI.Models;

namespace UsuariosAPI.Servicos
{
    public class TokenServico
    {
        public Token CriarToken(CustomIdentityUser usuario, string funcao)
        {
            Claim[] direitoUsuario = new Claim[]
            {
               new Claim("username", usuario.UserName),
               new Claim("id", usuario.Id.ToString()),
               new Claim(ClaimTypes.Role, funcao),
               new Claim(ClaimTypes.DateOfBirth, usuario.DataDeNascimento.ToString())
            };

            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0asdjas09djsa09djsadajsd09asjd09sajcnzxn")
            );
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitoUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }
    }
}