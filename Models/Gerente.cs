using System.ComponentModel.DataAnnotations;

namespace apiRestDotNet5.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
    }
}