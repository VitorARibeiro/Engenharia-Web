using System.ComponentModel.DataAnnotations;

namespace NOR_2023_01_24.Models
{
    public class Veiculo
    {
        [Key]
        [RegularExpression(@"^([A-Z]{2}-\d{2}-\d{2}|\d{2}-[A-Z]{2}-\d{2}|\d{2}-\d{2}-[A-Z]{2})$", ErrorMessage = "A matrícula deve seguir um dos formatos: AA-00-00, 00-AA-00 ou 00-00-AA.")]
        public string Matricula { get; set; }

        
        public string Marca { get; set; }

        
        public string Modelo { get; set; }

        public int ProprietarioId { get; set; }
        public Proprietario ?Proprietario { get; set; }
    }
}
