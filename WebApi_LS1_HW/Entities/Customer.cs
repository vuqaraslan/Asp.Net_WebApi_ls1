using System.Reflection.Metadata.Ecma335;

namespace WebApi_LS1_HW.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        //public string? Fullname { get; set; }
        public string ?Name { get; set; }
        public string ?Surname { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
