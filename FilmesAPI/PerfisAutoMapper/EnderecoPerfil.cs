using apiRestDotNet5.Data.DTOs;
using apiRestDotNet5.Models;
using AutoMapper;

namespace apiRestDotNet5.PerfisAutoMapper
{
    public class EnderecoPerfil : Profile
    {
        public EnderecoPerfil()
        {
            CreateMap<CriarEnderecoDTO, Endereco>();
            CreateMap<Endereco, ConsultarEnderecoDTO>();
            CreateMap<AtualizarEnderecoDTO, Endereco>();
        }
    }
}