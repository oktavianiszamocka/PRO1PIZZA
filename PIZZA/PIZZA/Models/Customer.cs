using System;
using System.Collections.Generic;

namespace PIZZA.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int IdCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
