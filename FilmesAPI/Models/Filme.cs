using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Titulo é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "Mínimo de 1 e máximo de 600")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; } 
    }
}