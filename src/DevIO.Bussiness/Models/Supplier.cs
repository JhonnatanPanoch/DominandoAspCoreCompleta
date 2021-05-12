using DevIO.Bussiness.Enumerators;
using System.Collections.Generic;

namespace DevIO.Bussiness.Models
{
    public class Supplier : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public SupplierType SupplierType { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}