using System.ComponentModel.DataAnnotations;

namespace apiRestDotNet5.Data.DTOs
{
    public class ConsultarEnderecoDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }

    }
}
