using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Servicos
{

    public class LogoutServico
    {
        private TokenServico _tokenService;
        private SignInManager<IdentityUser<int>> _signInManager;
        public LogoutServico(SignInManager<IdentityUser<int>> signInManager, TokenServico tokenService)
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