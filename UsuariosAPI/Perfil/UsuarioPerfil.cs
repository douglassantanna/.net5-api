using AutoMapper;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Models;

namespace UsuariosAPI.Perfil
{
    public class UsuarioPerfil : Profile
    {
        public UsuarioPerfil()
        {
            CreateMap<CriarUsuarioDTO, Usuario>();
        }
    }
}