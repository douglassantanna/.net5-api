using apiRestDotNet5.Data.DTOs;
using apiRestDotNet5.Models;
using AutoMapper;

namespace apiRestDotNet5.PerfisAutoMapper
{
    public class FilmePerfil : Profile
    {
        public FilmePerfil()
        {
            CreateMap<CriarFilmeDTO, Filme>();
            CreateMap<Filme, ConsultarFilmeDTO>();
            CreateMap<AtualizarFilmeDTO, Filme>();
        }
    }
}