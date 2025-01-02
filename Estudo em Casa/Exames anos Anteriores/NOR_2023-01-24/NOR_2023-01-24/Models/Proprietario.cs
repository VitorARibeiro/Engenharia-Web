using System.ComponentModel.DataAnnotations;

namespace NOR_2023_01_24.Models
{
    public class Proprietario
    {
        [Key]
        public int Id { get; set; }

        
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 200 caracteres.")]
        public string Nome { get; set; }

        public string Nacionalidade { get; set; }

        public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    }
}
