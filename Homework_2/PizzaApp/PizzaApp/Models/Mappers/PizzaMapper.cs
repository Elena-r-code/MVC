﻿using PizzaApp.Models.ViewModels;
using SEDC.PizzaApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel PizzaToPizzaDetailsViewModel(Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                PizzaSize = pizza.PizzaSize,
                Price = pizza.HasExtras ? pizza.Price + 10 : pizza.Price
            };

        }

        public static PizzaViewModel PizzaToPizzaViewModelExtensionMethod(this Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                PizzaSize = pizza.PizzaSize,
                Price = pizza.HasExtras ? pizza.Price + 10 : pizza.Price
            };
        }

    }
}
