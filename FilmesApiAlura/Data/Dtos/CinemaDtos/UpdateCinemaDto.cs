using System.ComponentModel.DataAnnotations;

namespace FilmesApiAlura.Data.Dtos.CinemaDtos
{
    public class UpdateCinemaDto
    {
            [Required(ErrorMessage = "O campo de nome é obrigatório")]
            public string Nome { get; set; }
        
    }
}
