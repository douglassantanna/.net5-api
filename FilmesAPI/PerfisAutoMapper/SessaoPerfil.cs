using System.Linq;
using apiRestDotNet5.Data.DTOs;
using apiRestDotNet5.Models;
using AutoMapper;

namespace apiRestDotNet5.PerfisAutoMapper
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
