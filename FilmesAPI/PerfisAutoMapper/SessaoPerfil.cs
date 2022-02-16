using System.Linq;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using AutoMapper;

namespace FilmesAPI.PerfisAutoMapper
{
    public class SessaoPerfil : Profile
    {
        public SessaoPerfil()
        {
            CreateMap<CriarSessaoDTO, Sessao>();
            CreateMap<Sessao, ConsultarSessaoDTO>()
                .ForMember(sessao => sessao.HorarioDeInicio, opts => opts
                .MapFrom(sessao => sessao.HorarioDeEncerramento.AddMinutes(sessao.Filme.Duracao * ( -1))));
        }
    }
}
