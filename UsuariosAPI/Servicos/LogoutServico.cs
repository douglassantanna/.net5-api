using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Models;

namespace UsuariosAPI.Servicos
{

    public class LogoutServico
    {
        private TokenServico _tokenService;
        private SignInManager<CustomIdentityUser> _signInManager;
        public LogoutServico(SignInManager<CustomIdentityUser> signInManager, TokenServico tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public Result LogoutUsuario()
        {
            var resultadoIdentity = _signInManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logout falhou");
        }
    }
}