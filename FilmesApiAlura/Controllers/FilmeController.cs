using FilmesApiAlura.Data;
using FilmesApiAlura.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController:ControllerBase
    {
        private readonly ApiAluraContext _contex;

        public FilmeController(ApiAluraContext contex)
        {
            _contex = contex;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _contex.Filmes.Add(filme);
            _contex.SaveChanges();

            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id}, filme);
            
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _contex.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filme filme = _contex.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme != null)
            {
                Ok(filme);
            }
            return NotFound();

            
        }


    }
}
