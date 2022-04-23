using AutoMapper;
using FilmesApiAlura.Data;
using FilmesApiAlura.Data.Dtos.Gerente;
using FilmesApiAlura.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiAluraContext _context;

        public GerenteController(IMapper mapper, ApiAluraContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarGerente(CreateGerenteDto dto)
        {
            var gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerente.Id}, gerente);
        }

        [HttpGet]
        public IActionResult RecuperaGerentePorId(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if(gerente != null)
            {
                var gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return Ok(gerenteDto);
            }

            return NotFound();
        }

        [HttpGet]
        public IEnumerable<Gerente> RecuperaGerentes()
        {
            return _context.Gerentes.ToList();
        }

        [HttpDelete]
        public IActionResult DeletaFilme(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(x => x.Id == id);

            if (gerente == null)
            {
                return NotFound();
            }

            _context.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
