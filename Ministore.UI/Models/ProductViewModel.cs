using System.ComponentModel.DataAnnotations;

namespace Ministore.UI.Models
{
    public class ProductViewModel
    {
        public System.Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"\d+(\,\d{1,2})?", ErrorMessage = "Invalid price")]
        public string Price { get; set; }
    }
}