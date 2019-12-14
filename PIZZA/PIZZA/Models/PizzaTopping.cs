using System;
using System.Collections.Generic;

namespace PIZZA.Models
{
    public partial class PizzaTopping
    {
        public int IdPizzaTopping { get; set; }
        public int? Pizza { get; set; }
        public int? Topping { get; set; }

        public Pizza PizzaNavigation { get; set; }
        public Topping ToppingNavigation { get; set; }
    }
}
