using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Models;

namespace UsuariosAPI.Perfil
{
    public class UsuarioPerfil : Profile
    {
        public UsuarioPerfil()
        {
            CreateMap<CriarUsuarioDTO, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
            CreateMap<Usuario, CustomIdentityUser>();
        }
    }
}