using System.ComponentModel.DataAnnotations;
using NOR_2022_02_08.Models;

namespace NOR_2022_02_08.ViewModels
{
    public class EmpresaViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public IFormFile? Logotipo { get; set; }

        [Required]
        public int PaisId { get; set; }

        public Pais ?Pais { get; set; }
    }
}
