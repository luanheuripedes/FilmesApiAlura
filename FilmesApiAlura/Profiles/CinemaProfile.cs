using AutoMapper;
using FilmesApiAlura.Data.Dtos.CinemaDtos;
using FilmesApiAlura.Models;

namespace FilmesApiAlura.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
