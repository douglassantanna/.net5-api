using System.ComponentModel.DataAnnotations;

namespace apiRestDotNet5.Data.DTOs
{
    public class CriarCinemaDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
