using System;
using apiRestDotNet5.Models;

namespace apiRestDotNet5.Data.DTOs
{
    public class ConsultarSessaoDTO
    {
        public int Id { get; set; }        
        public Filme Filme { get; set; }   
        public Cinema Cinema { get; set; }   
        public DateTime HorarioDeEncerramento { get; set; }   
        public DateTime HorarioDeInicio { get; set; }   

    }
}
