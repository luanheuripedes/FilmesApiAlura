using AutoMapper;
using FilmesApiAlura.Data.Dtos.GerenteDtos;
using FilmesApiAlura.Models;
using System.Linq;

namespace FilmesApiAlura.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<Gerente, CreateGerenteDto>().ReverseMap();


            CreateMap<Gerente, ReadGerenteDto>()
                //.ReverseMap()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select
                (c => new {c.Id,c.Nome, c.Endereco,c.EnderecoId})));
        }
    }
}
