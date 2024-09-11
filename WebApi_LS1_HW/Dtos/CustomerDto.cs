using System.ComponentModel.DataAnnotations;

namespace WebApi_LS1_HW.Dtos
{
    public class CustomerDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
    }
}
