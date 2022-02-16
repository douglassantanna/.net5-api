using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
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
