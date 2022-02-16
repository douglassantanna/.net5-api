using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.DTOs
{
    public class CriarUsuarioDTO
    {
        [Required]
        public string NomeUsuario { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha")]
        public string ConfirmarSenha { get; set; }
        
        
        
        
        
    }
}