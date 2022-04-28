using AutoMapper;
using FilmesApiAlura.Data.Dtos.SessoesDto;
using FilmesApiAlura.Models;

namespace FilmesApiAlura.Profiles
{
    public class SessaoProfile:Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDTO, Sessao>().ReverseMap();

            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto =>
                dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}
