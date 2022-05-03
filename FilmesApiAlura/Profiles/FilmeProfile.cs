using AutoMapper;
using FilmesApiAlura.Data.Dtos;
using FilmesApiAlura.Models;

namespace FilmesApiAlura.Profiles
{
    public class FilmeProfile:Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();

            CreateMap<Filme, ReadFilmeDto>().ReverseMap();

            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
