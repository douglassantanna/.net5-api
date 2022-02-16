using System.Linq;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using AutoMapper;

namespace FilmesAPI.PerfisAutoMapper
{
    public class GerentePerfil : Profile
    {
        public GerentePerfil()
        {
            CreateMap<CriarGerenteDTO, Gerente>();
            CreateMap<Gerente, ConsultarGerenteDTO>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select
                (c => new { c.Id, c.Nome, c.Endereco, c.EnderecoID})));
        }
    }
}
