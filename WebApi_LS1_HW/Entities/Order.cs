﻿namespace WebApi_LS1_HW.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
