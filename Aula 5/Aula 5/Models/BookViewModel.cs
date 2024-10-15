using System.ComponentModel.DataAnnotations;

namespace Aula_5.Models
{
    public class BookViewModel
    {
        [Required(ErrorMessage = "Required Field")]
        [StringLength(100, ErrorMessage = "The {0} do not exceed {1} characteres.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Select a Image File")]
        public IFormFile? CoverPhoto { get; set; }

        [Required(ErrorMessage = "Select a Document_ File")]
        public IFormFile? Document { get; set; }
    }
}
