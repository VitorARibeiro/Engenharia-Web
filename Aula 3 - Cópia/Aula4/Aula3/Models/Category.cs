using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aula3.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(256, ErrorMessage = "{0} length can not exceed {1} characters")]
        public string? Description { get; set; }

        [DisplayName ("Creation Date")]
        public DateTime date { get; set; } = DateTime.Now;

        public Boolean State { get; set; } = true; //default value
        
        public ICollection<Course>? Courses { get; set; }
    }
}