using System.ComponentModel.DataAnnotations;

namespace testapi.Models
{
    public class Shirt
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        [StringLength(50, ErrorMessage = "Brand can't be longer than 50 characters")]
        public string? Brand { get; set; }

        [Required(ErrorMessage = "Colour is required")]
        [StringLength(30, ErrorMessage = "Colour can't be longer than 30 characters")]
        public string? Colour { get; set; }

        [Range(4, 10, ErrorMessage = "Size must be between 1 and 10")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("Male|Female|Unisex", ErrorMessage = "Gender must be 'Male', 'Female', or 'Unisex'")]
        public string? Gender { get; set; }

        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000")]
        public int Price { get; set; }
    }
}
