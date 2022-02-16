using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using AutoMapper;

namespace FilmesAPI.PerfisAutoMapper
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
