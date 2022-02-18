using System.Linq;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Models;

namespace UsuariosAPI.Servicos
{

    public class LoginServico
    {
        private TokenServico _tokenService;
        private SignInManager<IdentityUser<int>> _signInManager;
        public LoginServico(SignInManager<IdentityUser<int>> signInManager, TokenServico tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public Result LogarUsuario(LoginRequest loginRequest)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var IdentityUser = _signInManager.UserManager.Users.FirstOrDefault(usuario => usuario.NormalizedUserName == loginRequest.Username.ToUpper());
                Token token = _tokenService.CriarToken(IdentityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }
    }
}