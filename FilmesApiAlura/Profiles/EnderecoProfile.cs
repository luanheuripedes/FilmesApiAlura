using AutoMapper;
using FilmesApiAlura.Models;

namespace FilmesApiAlura.Profiles
{
    public class EnderecoProfile:Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>().ReverseMap();
            CreateMap<Endereco, ReadEnderecoDto>().ReverseMap();
            CreateMap<UpdateEnderecoDto, Endereco>().ReverseMap();
        }
    }
}
