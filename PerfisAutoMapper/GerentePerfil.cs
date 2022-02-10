using apiRestDotNet5.Data.DTOs;
using apiRestDotNet5.Models;
using AutoMapper;

namespace apiRestDotNet5.PerfisAutoMapper
{
    public class GerentePerfil : Profile
    {
        public GerentePerfil()
        {
            CreateMap<CriarGerenteDTO, Gerente>();
            CreateMap<Gerente, ConsultarGerenteDTO>();
        }
    }
}
