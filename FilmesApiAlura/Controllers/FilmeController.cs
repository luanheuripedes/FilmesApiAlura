using AutoMapper;
using FilmesApiAlura.Data;
using FilmesApiAlura.Data.Dtos;
using FilmesApiAlura.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController:ControllerBase
    {
        private readonly ApiAluraContext _contex;
        private readonly IMapper _mapper;


        public FilmeController(ApiAluraContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

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
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                Ok(filmeDto);
            }
            return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _contex.Filmes.FirstOrDefault(x => x.Id == id);

            if(filme == null)
            {
                return NotFound();
            }

            _mapper.Map(filmeDto, filme);

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
