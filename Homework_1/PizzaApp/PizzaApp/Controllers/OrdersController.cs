using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Controllers
{
    public class OrdersController : Controller
    {
        [Route("Orders")]
        public IActionResult Index()
        {
            List<Order> orders = StaticDb.Orders;
            return View(orders);
        }
        [Route("Orders/Details/{id?")]
        public IActionResult Details(int? id)
        {
            if(id == 0)
            {
                return new EmptyResult();
            }
            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(order == null)
            {
                return new EmptyResult();
            }
            return View(order);
        }
        [Route("Orders/JsonData")]
        public IActionResult JsonReturns()
        {
            return new JsonResult(StaticDb.Orders);
        }
        public IActionResult RedictToHome()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
