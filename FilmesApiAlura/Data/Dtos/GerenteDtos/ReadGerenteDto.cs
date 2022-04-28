using FilmesApiAlura.Models;
using System.Collections.Generic;

namespace FilmesApiAlura.Data.Dtos.GerenteDtos
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public object Cinemas { get; set; }
    }
}
