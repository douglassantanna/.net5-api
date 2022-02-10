using System.Collections.Generic;
using apiRestDotNet5.Models;

namespace apiRestDotNet5.Data.DTOs
{
    public class ConsultarGerenteDTO
    {
        public string Nome { get; set; }   
        public List<Cinema> Cinemas { get; set; }
        
        
    }
}
