using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesApiAlura.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        //Variaveis de Navegação
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }

        //Fks
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }
    }
}
