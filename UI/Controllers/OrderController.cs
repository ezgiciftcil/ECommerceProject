using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Checkout(string json)
        {
            var model = new OrderModel();
            model.Cart= Newtonsoft.Json.JsonConvert.DeserializeObject<CartModel>(json);
            return View(model);
        }
    }
}
