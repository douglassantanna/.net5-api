using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.DTOs;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller")]
    public class CadastroController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastrarUsuario(CriarUsuarioDTO criarUsuarioDTO)
        {
            return Ok();
        }
    }
}