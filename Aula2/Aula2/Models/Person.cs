using System.ComponentModel.DataAnnotations;

namespace Aula2.Models
{
    public class Person
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(18,100,ErrorMessage = "{0} must be between {1} and {2} ")]
        public string? Name { get; set; }
    }
}
