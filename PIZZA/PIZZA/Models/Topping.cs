using System;
using System.Collections.Generic;

namespace PIZZA.Models
{
    public partial class Topping
    {
        public Topping()
        {
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int IdTopping { get; set; }
        public string Name { get; set; }
        public double? PriceItem { get; set; }

        public ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
