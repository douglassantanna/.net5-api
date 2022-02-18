using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Servicos;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private LogoutServico _logoutServico;

        public LogoutController(LogoutServico logoutServico)
        {
            _logoutServico = logoutServico;
        }

        [HttpPost]
        public IActionResult LogoutUsuario()
        {
            Result result = _logoutServico.LogoutUsuario();
            if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }
    }
}