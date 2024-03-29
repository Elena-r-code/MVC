﻿using PizzaApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public string PizzaName { get; set; }
        public string UserFullName { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Price { get; set; }
        public bool Delivered { get; set; }
    }
}
