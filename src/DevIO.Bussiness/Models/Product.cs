using System;

namespace DevIO.Bussiness.Models
{
    public class Product : Entity
    {
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Value { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }

        public Supplier Supplier { get; set; }
    }
}