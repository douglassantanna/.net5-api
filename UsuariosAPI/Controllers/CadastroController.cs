using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Servicos;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroServico _cadastroServico;

        public CadastroController(CadastroServico cadastroServico)
        {
            _cadastroServico = cadastroServico;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CriarUsuarioDTO criarUsuarioDTO)
        {
            Result result = _cadastroServico.CadastrarUsuario(criarUsuarioDTO);
            if(result.IsFailed) return StatusCode(500);
            return Ok();
        }
    }
}