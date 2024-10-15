using System.ComponentModel.DataAnnotations;

namespace Aula_5.Models
{
    public class Books
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(100, ErrorMessage = "The {0} do not exceed {1} characteres. ")]
        public string? Title { get; set; }

        [Required]
        public string? CoverPhoto { get; set; } // File name of the image in the file system

        [Required]
        public string? Document { get; set; } // File name of the Document in the file system
    }
}
