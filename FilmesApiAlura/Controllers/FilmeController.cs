using AutoMapper;
using FilmesApiAlura.Data;
using FilmesApiAlura.Data.Dtos;
using FilmesApiAlura.Models;
using FilmesApiAlura.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var readDto = _filmeService.AdicionaService(filmeDto);
            

            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readDto.Id}, readDto);
            
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            var readdto = _filmeService.RecuperaFilmes(classificacaoEtaria);

            if(readdto != null)
            {
                return Ok(readdto);
            }

            return NotFound();
        }

        /*
        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmesTodosOsFilmes()
        {
            return _contex.Filmes;
        }
        */
        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {

            var readdto = _filmeService.RecuperaFilmesPorId(id);

            if (readdto != null)
            {
                return Ok();
            }

            return NotFound();


        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var resultado = _filmeService.AtualizaFilme(id, filmeDto);

            if (resultado.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {

            var result = _filmeService.DeletaFilme(id);
            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
