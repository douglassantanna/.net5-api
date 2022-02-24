using System;
using System.Linq;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.DTOs.Request;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Models;

namespace UsuariosAPI.Servicos
{

    public class LoginServico
    {
        private TokenServico _tokenService;
        private SignInManager<IdentityUser<int>> _signInManager;
        public LoginServico(SignInManager<IdentityUser<int>> signInManager, TokenServico tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public Result LogarUsuario(LoginRequest loginRequest)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var IdentityUser =
                _signInManager.UserManager.Users
                .FirstOrDefault(usuario => usuario.NormalizedUserName == loginRequest.Username.ToUpper());
                
                Token token = _tokenService.CriarToken(IdentityUser,
                _signInManager.UserManager.GetRolesAsync(IdentityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result SolicitarNovaSenhaUsuario(SolicitarNovaSenhaRequest request)
        {
            IdentityUser<int> identityUser = RecuperarUsuarioPorEmail(request.Email);

            if(identityUser != null)
            {
                string codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoDeRecuperacao);

            }
            return Result.Fail("Erro ao redefinir senha");
        }

        public Result DefinirNovaSenhaUsuario(DefinirNovaSenhaRequest request)
        {
            IdentityUser<int> identityUser = RecuperarUsuarioPorEmail(request.Email);

            IdentityResult identityResult = _signInManager
            .UserManager
            .ResetPasswordAsync(identityUser, request.Token, request.Password)
            .Result;

            if (identityResult.Succeeded) return Result.Ok().WithSuccess("Senha redefinida");
            return Result.Fail("Ocorreu um erro");

        }

        private IdentityUser<int> RecuperarUsuarioPorEmail(string email)
        {
            return _signInManager
                        .UserManager
                        .Users
                        .FirstOrDefault(x => x.NormalizedEmail == email.ToUpper());
        }
    }
}