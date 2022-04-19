using FilmesApiAlura.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApiAlura.Data
{
    public class ApiAluraContext:DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet <Cinema> Cinemas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }
        public ApiAluraContext()
        {

        }

        public ApiAluraContext(DbContextOptions<ApiAluraContext> options):base(options) { }
       

        
    }
}
