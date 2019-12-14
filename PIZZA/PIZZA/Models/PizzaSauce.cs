using System;
using System.Collections.Generic;

namespace PIZZA.Models
{
    public partial class PizzaSauce
    {
        public int IdPizzaSauce { get; set; }
        public int? Pizza { get; set; }
        public int? Sauce { get; set; }

        public Pizza PizzaNavigation { get; set; }
        public Sauce SauceNavigation { get; set; }
    }
}
