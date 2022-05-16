using AutoMapper;
using FilmesApiAlura.Data;
using FilmesApiAlura.Data.Dtos;
using FilmesApiAlura.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApiAlura.Services
{
    public class FilmeService
    {
        private readonly ApiAluraContext _contex;
        private readonly IMapper _mapper;

        public FilmeService(ApiAluraContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaService(CreateFilmeDto filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);

            _contex.Filmes.Add(filme);
            _contex.SaveChanges();

            var readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);

            return readFilmeDto;    
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes = new List<Filme>();

            if (classificacaoEtaria == null)
            {
                filmes = _contex.Filmes.ToList();
            }

            if (filmes != null)
            {
                var filmesDto = _mapper.Map<List<ReadFilmeDto>>(filmes);

                return filmesDto;
            }

            return null;
        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
            Filme filme = _contex.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

               return filmeDto;
            }

            return null;
        }

        public object AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _contex.Filmes.FirstOrDefault(x => x.Id == id);

            if (filme == null)
            {
                return null;
            }

            var readDto = _mapper.Map(filmeDto, filme);

            _contex.SaveChanges();

            return readDto;
        }

        public void DeletaFilme(int id)
        {
            var filme = _contex.Filmes.FirstOrDefault(x => x.Id == id);

            _contex.Remove(filme);
            _contex.SaveChanges();
        }
    }
}
