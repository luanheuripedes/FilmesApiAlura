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
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        
        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return filmes;
        }

        [HttpGet("{id}")]
        public Filme RecuperaFilmesPorId(int id)
        {
            /*
            foreach(Filme filme in filmes){
                if(filme.Id == id)
                {
                    return filme;
                }
            }
            */

            return filmes.FirstOrDefault(filme => filme.Id == id);

        }
    }
}
