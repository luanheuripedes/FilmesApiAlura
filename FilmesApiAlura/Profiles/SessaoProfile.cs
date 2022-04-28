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
            CreateMap<ReadSessaoDto, Sessao>().ReverseMap();
        }
    }
}
