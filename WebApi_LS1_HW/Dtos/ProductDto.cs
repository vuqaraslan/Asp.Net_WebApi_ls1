using System.ComponentModel.DataAnnotations;

namespace WebApi_LS1_HW.Dtos
{
    public class ProductDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Discount { get; set; }
    }
}
