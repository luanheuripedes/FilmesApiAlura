using FilmesApiAlura.Models;

namespace FilmesApiAlura.Data.Dtos.SessoesDto
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
    }
}
