using System;
using System.Collections.Generic;

namespace PIZZA.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderPizza = new HashSet<OrderPizza>();
            PizzaSauce = new HashSet<PizzaSauce>();
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int IdPizza { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public ICollection<OrderPizza> OrderPizza { get; set; }
        public ICollection<PizzaSauce> PizzaSauce { get; set; }
        public ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
