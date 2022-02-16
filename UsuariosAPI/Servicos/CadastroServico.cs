using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Models;

namespace UsuariosAPI.Servicos
{

    public class CadastroServico
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        public CadastroServico(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public Result CadastrarUsuario(CriarUsuarioDTO criarUsuarioDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(criarUsuarioDTO);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, criarUsuarioDTO.Senha);
            if(resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário.");
        }
    }
}