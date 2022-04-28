using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmesApiAlura.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo titulo é obrigatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage ="Diretor é um campo obrigatorio")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O genero nao pode passar de 30 caracteres")]
        public string Genero { get; set; }

        [Range(1,600,ErrorMessage ="A duração deve ter no minimo 1 e no maximo 600 minutos")] //Intervalo de valores que suporta
        public int Duracao { get; set; }

        public int ClassificacaoEtaria { get; set; }

        public virtual List<Cinema> Cinemas { get; set; }
    }
}
