using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using AutoMapper;

namespace FilmesAPI.PerfisAutoMapper
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