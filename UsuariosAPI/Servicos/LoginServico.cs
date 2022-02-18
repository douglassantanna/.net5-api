using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Request;

namespace UsuariosAPI.Servicos
{

    public class LoginServico
    {
        private IMapper _mapper;
        private SignInManager<IdentityUser<int>> _signInManager;
        public LoginServico(IMapper mapper, SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public Result LogarUsuario(LoginRequest loginRequest)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
            if(resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Login falhou");
        }
    }
}