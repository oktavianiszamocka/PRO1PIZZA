using System;
using System.Collections.Generic;

namespace PIZZA.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Order = new HashSet<Order>();
        }

        public int IdStaff { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal? Salary { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
