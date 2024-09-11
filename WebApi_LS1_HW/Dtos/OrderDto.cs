using System.ComponentModel.DataAnnotations;
using WebApi_LS1_HW.Entities;

namespace WebApi_LS1_HW.Dtos
{
    public class OrderDto
    {
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
