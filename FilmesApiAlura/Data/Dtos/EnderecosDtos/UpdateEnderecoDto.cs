using System.ComponentModel.DataAnnotations;

namespace FilmesApiAlura.Data.Dtos.EnderecosDtos
{
    public class UpdateEnderecoDto
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
