using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosApi.Data;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly EmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public  Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            var usuario = _mapper.Map<Usuario>(createDto);

            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);

            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password).Result;

            _userManager.AddToRoleAsync(usuarioIdentity, "regular");


            if (resultadoIdentity.Succeeded)
            {
                //precisamos disponibilizar um codigo para essa conta ser ativada
                var codeAtivation =  _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;

                var encodedCode = HttpUtility.UrlEncode(codeAtivation);

                _emailService.EnviarEmail(new[] {usuarioIdentity.Email},
                                                    "Link de Ativação",
                                                    usuarioIdentity.Id,
                                                    encodedCode);

                return Result.Ok().WithSuccess(codeAtivation);
            }

            return Result.Fail("Falha ao cadastrar usuário");

        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser =  _userManager.Users.FirstOrDefault(u => u.Id == request.UsuarioId);

            var identityResult =  _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta de usuario");
        }
    }
}
