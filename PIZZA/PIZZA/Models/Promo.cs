using System;
using System.Collections.Generic;

namespace PIZZA.Models
{
    public partial class Promo
    {
        public Promo()
        {
            Order = new HashSet<Order>();
        }

        public int IdPromo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
