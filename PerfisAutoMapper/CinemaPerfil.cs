using apiRestDotNet5.Data.DTOs;
using apiRestDotNet5.Models;
using AutoMapper;

namespace apiRestDotNet5.PerfisAutoMapper
{
    public class CinemaPerfil : Profile
    {
        public CinemaPerfil()
        {
            CreateMap<CriarCinemaDTO, Cinema>();
            CreateMap<Cinema, ConsultarCinemaDTO>();
            CreateMap<AtualizarCinemaDTO, Cinema>();
        }
    }
}
