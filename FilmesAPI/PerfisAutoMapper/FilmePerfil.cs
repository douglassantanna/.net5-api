using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using AutoMapper;

namespace FilmesAPI.PerfisAutoMapper
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