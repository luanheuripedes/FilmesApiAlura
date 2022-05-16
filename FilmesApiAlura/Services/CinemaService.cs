using AutoMapper;
using FilmesApiAlura.Data;
using FilmesApiAlura.Data.Dtos.CinemaDtos;
using FilmesApiAlura.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApiAlura.Services
{
    public class CinemaService
    {
        private readonly ApiAluraContext _context;
        private readonly IMapper _mapper;

        public CinemaService(ApiAluraContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AdicionarCinema(CreateCinemaDto cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);


            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperaCinema(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (cinemas == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                //Lembra a consulta sql convecional
                IEnumerable<Cinema> query = from c in cinemas
                                            where c.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                                            select c;

                cinemas = query.ToList();
            }

            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto RecuperaCinemaId(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return cinemaDto;
            }

            return null;
        }

        public Result DeletaCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado!");
            }
            _context.Remove(cinema);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }

            _mapper.Map(cinema, cinemaDto);
            _context.SaveChanges();


            return Result.Ok();
        }
    }
}
