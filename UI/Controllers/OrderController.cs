using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
        private readonly IAddressService addressService;
        public OrderController(IAddressService _addressService)
        {
            addressService = _addressService;
        }
        public IActionResult Checkout(string json)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if (userId == 0)
                return RedirectToAction("Index", "Login", new { Message = "You need to login before create an order." });

            var model = new OrderModel();
            model.Cart= Newtonsoft.Json.JsonConvert.DeserializeObject<CartModel>(json);

            var defaultAddress = addressService.GetUserDefaultAddress(userId);
            model.IsDefaultAddressExists = defaultAddress.Success;

            return View(model);
        }
    }
}
