using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.DTOs.Request
{
    public class SolicitarNovaSenhaRequest
    {
        [Required]
        public string Email { get; set; }
        
        
    }
}