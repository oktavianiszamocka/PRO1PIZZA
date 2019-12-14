using System;
using System.Collections.Generic;

namespace PIZZA.Models
{
    public partial class Sauce
    {
        public Sauce()
        {
            PizzaSauce = new HashSet<PizzaSauce>();
        }

        public int IdSauce { get; set; }
        public string Name { get; set; }

        public ICollection<PizzaSauce> PizzaSauce { get; set; }
    }
}
