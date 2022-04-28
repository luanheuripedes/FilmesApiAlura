using AutoMapper;
using FilmesApiAlura.Data;
using FilmesApiAlura.Data.Dtos.SessoesDto;
using FilmesApiAlura.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly ApiAluraContext _context;
        private readonly IMapper _mapper;

        public SessaoController(ApiAluraContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDTO dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet("id")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if(sessao == null)
            {
                return NotFound();
            }

            var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return Ok(sessaoDto);

        }
    }
}
