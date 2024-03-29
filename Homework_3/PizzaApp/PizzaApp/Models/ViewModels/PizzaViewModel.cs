﻿using PizzaApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public decimal Price { get; set; }
        public PizzaSize PizzaSize  { get; set; }
        public bool IsOnPromotion { get; set; }
    }
}
