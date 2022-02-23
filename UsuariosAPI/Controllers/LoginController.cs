using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.DTOs.Request;
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

        [HttpPost("/solicitar-nova-senha")]
        public IActionResult SolicitarNovaSenha(SolicitarNovaSenhaRequest request)
        {
            Result result = _loginServico.SolicitarNovaSenhaUsuario(request);
            if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }

        [HttpPost("/redefinir-nova-senha")]
        public IActionResult RedefinirNovaSenha(DefinirNovaSenhaRequest request)
        {
            Result result = _loginServico.DefinirNovaSenhaUsuario(request);
            if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }
    }
}