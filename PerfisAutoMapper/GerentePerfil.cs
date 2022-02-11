using System.Linq;
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
            CreateMap<Gerente, ConsultarGerenteDTO>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select
                (c => new { c.Id, c.Nome, c.Endereco, c.EnderecoID})));
        }
    }
}
