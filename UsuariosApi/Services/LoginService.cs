using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password,false,false);

            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users.FirstOrDefault(usuario => usuario.NormalizedUserName == request.UserName.ToUpper());

                //Gerar o token atraves do token service 
                Token token = _tokenService.CreateToken(identityUser);


                return Result.Ok().WithSuccess(token.Value);
            }
           
            return Result.Fail("Login Falhou!");
            
        }

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = _signInManager.
                                                UserManager.
                                                Users.FirstOrDefault(u => u.NormalizedEmail == request.Email.ToUpper());

            if(identityUser != null)
            {
                string codigoDeRecuperacao =  _signInManager.
                                                    UserManager.
                                                    GeneratePasswordResetTokenAsync(identityUser)
                                                    .Result;
                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }

            return Result.Fail("Falha ao solicitar redefinição");
        }
    }
}
