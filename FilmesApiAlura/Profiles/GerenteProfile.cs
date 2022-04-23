using AutoMapper;
using FilmesApiAlura.Data.Dtos.Gerente;
using FilmesApiAlura.Models;

namespace FilmesApiAlura.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<Gerente, CreateGerenteDto>().ReverseMap();
            CreateMap<Gerente, ReadGerenteDto>().ReverseMap();
        }
    }
}
