using AutoMapper;
using FilmesApiAlura.Data;
using FilmesApiAlura.Data.Dtos.GerenteDtos;
using FilmesApiAlura.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApiAlura.Services
{
    public class GerenteService
    {
        private readonly IMapper _mapper;
        private readonly ApiAluraContext _context;

        public GerenteService(IMapper mapper, ApiAluraContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadGerenteDto AdicionarGerente(CreateGerenteDto dto)
        {
            var gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                var gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return gerenteDto;
            }

            return null;
        }

        public List<ReadGerenteDto> RecuperaGerentes()
        {
            List<Gerente> gerentes = new List<Gerente>();
                

            var readDto = _mapper.Map<List<ReadGerenteDto>>(gerentes);
            return readDto;
        }

        public Result DeletaGerente(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(x => x.Id == id);

            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado!");
            }

            _context.Remove(gerente);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
