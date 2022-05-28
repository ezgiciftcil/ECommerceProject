using BusinessLayer.Services.Interfaces;
using EntityLayer;
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
        private readonly ICityService cityService;
        public OrderController(IAddressService _addressService, ICityService _cityService)
        {
            addressService = _addressService;
            cityService = _cityService;
        }
        public IActionResult Checkout(string json)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if (userId == 0)
                return RedirectToAction("Index", "Login", new { Message = "You need to login before create an order." });

            var model = new OrderModel();
            model.Cart= Newtonsoft.Json.JsonConvert.DeserializeObject<CartModel>(json);
            model.Cart.CartModelJson = json;

            var defaultAddress = addressService.GetUserDefaultAddress(userId);
            model.IsDefaultAddressExists = defaultAddress.Success;
            if (model.IsDefaultAddressExists)
                model.Address = defaultAddress.Data;

            var cityList = new CityList(cityService);
            var cities = cityList.GetCities();
            ViewBag.cities = cities;


            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(OrderModel orderModel)
        {
            orderModel.Cart = Newtonsoft.Json.JsonConvert.DeserializeObject<CartModel>(orderModel.Cart.CartModelJson);
            return View();
        }

    }
}
