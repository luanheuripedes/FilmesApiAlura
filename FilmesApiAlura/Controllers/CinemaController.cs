using AutoMapper;
using FilmesApiAlura.Data;
using FilmesApiAlura.Data.Dtos.CinemaDtos;
using FilmesApiAlura.Models;
using FilmesApiAlura.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {

        private readonly CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
        {

            var readCinemaDto = _cinemaService.AdicionarCinema(cinemaDto);

            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readCinemaDto.Id }, readCinemaDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinema([FromQuery] string nomeDoFilme)
        {
            var readDto = _cinemaService.RecuperaCinema(nomeDoFilme);
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            var readDto = _cinemaService.RecuperaCinemaId(id);

            if(readDto != null)
            {
                return Ok(readDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {

            var updateDto = _cinemaService.AtualizaCinema(id, cinemaDto);

            if(updateDto == null)
            {
                return NotFound();
            }
           return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {

            var deletaDto = _cinemaService.DeletaCinema(id);

            if (deletaDto == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
