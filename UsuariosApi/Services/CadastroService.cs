﻿using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly UserDbContext _userDbContext;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, UserDbContext userDbContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _userDbContext = userDbContext;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            var usuario = _mapper.Map<Usuario>(createDto);

            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);

            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);

            if (resultadoIdentity.Result.Succeeded)
            {
                //precisamos disponibilizar um codigo para essa conta ser ativada
                var codeAtivation =  _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;

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
