using System;
using System.Collections.Generic;

namespace PIZZA.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderPizza = new HashSet<OrderPizza>();
        }

        public int IdOrder { get; set; }
        public int? Customer { get; set; }
        public int? Promo { get; set; }
        public double? Total { get; set; }
        public DateTime? Date { get; set; }
        public int? Driver { get; set; }

        public Customer CustomerNavigation { get; set; }
        public Staff DriverNavigation { get; set; }
        public Promo PromoNavigation { get; set; }
        public ICollection<OrderPizza> OrderPizza { get; set; }
    }
}
