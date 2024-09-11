namespace WebApi_LS1_HW.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
