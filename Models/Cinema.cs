using System.ComponentModel.DataAnnotations;

namespace apiRestDotNet5.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoID { get; set; }
    }
}