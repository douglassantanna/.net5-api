using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class CriarSessaoDTO
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
