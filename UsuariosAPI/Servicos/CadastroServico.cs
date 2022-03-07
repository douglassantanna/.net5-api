using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Models;

namespace UsuariosAPI.Servicos
{

    public class CadastroServico
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private EmailServico _emailServico;
        private RoleManager<IdentityRole<int>> _roleManager;
        public CadastroServico(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailServico emailServico, RoleManager<IdentityRole<int>> roleManager = null)
        {
            _userManager = userManager;
            _mapper = mapper;
            _emailServico = emailServico;
        }
        public Result CadastrarUsuario(CriarUsuarioDTO criarUsuarioDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(criarUsuarioDTO);

            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);

            Task<IdentityResult> resultadoIdentity =
            _userManager.CreateAsync(usuarioIdentity, criarUsuarioDTO.Password);

            _userManager.AddToRoleAsync(usuarioIdentity, "regular");
            if (resultadoIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCode = HttpUtility.UrlDecode(code);
                 _emailServico.EnviarEmail(new [] {usuarioIdentity.Email}, "Link de ativação", usuarioIdentity.Id, encodedCode);
                return Result.Ok().WithSuccess(code);
            }

            return Result.Fail("Falha ao cadastrar usuário.");
        }

        public Result ConfirmarEmailUsuario(ConfirmarEmailRequest confirmarEmailRequest)
        {
            var IdentityUser = _userManager.Users.FirstOrDefault(usuario => usuario.Id == confirmarEmailRequest.UsuarioId);
            var IdentityResult = _userManager.ConfirmEmailAsync(IdentityUser, confirmarEmailRequest.CodigoDeAtivacao).Result;
           
            if(IdentityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta do usuário");
        }
    }
}