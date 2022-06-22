using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles
{
    public class UsuarioProfile:Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>().ReverseMap();
            CreateMap<Usuario, IdentityUser<int>>().ReverseMap();
            CreateMap<Usuario, CustomIdentityUser>().ReverseMap();
        }
    }
}
