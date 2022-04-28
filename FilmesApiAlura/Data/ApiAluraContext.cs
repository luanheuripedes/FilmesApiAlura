using FilmesApiAlura.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApiAlura.Data
{
    public class ApiAluraContext:DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet <Cinema> Cinemas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public ApiAluraContext()
        {

        }

        public ApiAluraContext(DbContextOptions<ApiAluraContext> options):base(options) { }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);

            builder.Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId).IsRequired(false);
        }
        
    }
}
