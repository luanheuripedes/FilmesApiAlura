using AutoMapper;
using FilmesApiAlura.Data;
using FilmesApiAlura.Data.Dtos.GerenteDtos;
using FilmesApiAlura.Models;
using FilmesApiAlura.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController:ControllerBase
    {
        private readonly GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody]CreateGerenteDto dto)
        {
            var readGerenteDto = _gerenteService.AdicionarGerente(dto);
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readGerenteDto.Id}, readGerenteDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            var readDto = _gerenteService.RecuperaGerentePorId(id);


            if(readDto != null)
            {
                return Ok(readDto);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            var readDto = _gerenteService.RecuperaGerentes().ToList();

            if (readDto != null)
            {
                return Ok(readDto);
            }

            return NotFound();

        }

        [HttpDelete]
        public IActionResult DeletaGerente(int id)
        {
            var result = _gerenteService.DeletaGerente(id);

            if (result.IsFailed)
            {
                return NotFound();
            }
            
            return NoContent();
        }

    }
}
