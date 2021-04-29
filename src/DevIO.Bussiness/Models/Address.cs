using System;

namespace DevIO.Bussiness.Models
{
    public class Address : Entity
    {
        public Guid SupplierId { get; set; }
        public string PublicPlace { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Cep { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Supplier Supplier { get; set; }
    }
}