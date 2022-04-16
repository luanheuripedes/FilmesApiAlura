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

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] Filme filmeNovo)
        {
            Filme filme = _contex.Filmes.FirstOrDefault(x => x.Id == id);

            if(filme == null)
            {
                return NotFound();
            }

            filme.Titulo = filmeNovo.Titulo;
            filme.Genero = filmeNovo.Genero;
            filme.Duracao = filmeNovo.Duracao;
            filme.Diretor = filmeNovo.Diretor;

            _contex.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _contex.Filmes.FirstOrDefault(x => x.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            _contex.Remove(filme);
            _contex.SaveChanges();
            return NoContent();
        }


    }
}
