using System.ComponentModel.DataAnnotations;

namespace apiRestDotNet5.Data.DTOs
{
    public class ConsultarCinemaDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
