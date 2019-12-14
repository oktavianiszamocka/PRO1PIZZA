using System;
using System.Collections.Generic;

namespace PIZZA.Models
{
    public partial class OrderPizza
    {
        public int IdOrderPizza { get; set; }
        public int? Pizza { get; set; }
        public string Size { get; set; }
        public string Crust { get; set; }
        public int? Amount { get; set; }
        public int? Order { get; set; }
        public decimal? Price { get; set; }

        public Order OrderNavigation { get; set; }
        public Pizza PizzaNavigation { get; set; }
    }
}
