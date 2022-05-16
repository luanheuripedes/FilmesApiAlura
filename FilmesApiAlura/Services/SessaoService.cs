using AutoMapper;
using FilmesApiAlura.Data;
using FilmesApiAlura.Data.Dtos.SessoesDto;
using FilmesApiAlura.Models;
using System.Linq;

namespace FilmesApiAlura.Services
{
    public class SessaoService
    {
            private readonly ApiAluraContext _context;
            private readonly IMapper _mapper;

            public SessaoService(ApiAluraContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public ReadSessaoDto AdicionaSessao(CreateSessaoDTO dto)
            {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                return _mapper.Map<ReadSessaoDto>(sessao);
            }

            return null;
        }
        
    }
}
