﻿using SEDC.PizzaApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.ViewModels.PizzaViewModels
{
    public class PizzaDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Pizza Name")]
        public string Name { get; set; }
        [Display(Name = "Pizza Price")]
        public double Price { get; set; }
        [Display(Name = "Pizza Size")]
        public PizzaSizeEnum PizzaSizeEnum { get; set; }
        [Display(Name = "Is On Promotion")]
        public bool IsOnPromotion { get; set; }
    }
}