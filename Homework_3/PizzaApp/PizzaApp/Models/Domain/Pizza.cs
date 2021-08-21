using PizzaApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.Domain
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsOnPromotion { get; set; }
        public PizzaSize PizzaSize { get; internal set; }
        public bool HasExtras { get; internal set; }
    }
}
