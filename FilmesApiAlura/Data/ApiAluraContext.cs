using FilmesApiAlura.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApiAlura.Data
{
    public class ApiAluraContext:DbContext
    {
        public ApiAluraContext()
        {

        }

        public ApiAluraContext(DbContextOptions<ApiAluraContext> options):base(options) { }
       

        public DbSet<Filme> Filmes { get; set; }
    }
}
