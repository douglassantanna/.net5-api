using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Servicos;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginServico _loginServico;

        public LoginController(LoginServico loginServico)
        {
            _loginServico = loginServico;
        }

        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest loginRequest)
        {
            Result result = _loginServico.LogarUsuario(loginRequest);
            if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }
    }
}