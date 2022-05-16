using AutoMapper;
using FilmesApiAlura.Data;
using FilmesApiAlura.Data.Dtos.SessoesDto;
using FilmesApiAlura.Models;
using FilmesApiAlura.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly SessaoService _sessaoService;

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDTO dto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionaSessao(dto);
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("id")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.RecuperaSessoesPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }
    }
}
