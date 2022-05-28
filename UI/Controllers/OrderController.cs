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
        private readonly IOrderService orderService;
        public OrderController(IAddressService _addressService, ICityService _cityService,IOrderService _orderService)
        {
            addressService = _addressService;
            cityService = _cityService;
            orderService = _orderService;
        }
        public IActionResult Checkout(string json, bool isSucceed = true, string message = null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
                ViewBag.IsSucceed = isSucceed;
            }

            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if (userId == 0)
                return RedirectToAction("Index", "Login", new { Message = "You need to login before create an order." });

            var model = new OrderModel();
            model.Cart= Newtonsoft.Json.JsonConvert.DeserializeObject<CartModel>(json);
            model.Cart.CartModelJson = json;

            if(model.Cart.Products.Count()==0)
                return RedirectToAction("Index", "Cart", new { isSucceed = false, message = "The card is empty." });

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

            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if (userId == 0)
                return RedirectToAction("Index", "Login", new { Message = "You need to login before create an order." });

            var json = orderModel.Cart.CartModelJson;
            orderModel.Cart = Newtonsoft.Json.JsonConvert.DeserializeObject<CartModel>(json);
            var result = orderService.CompleteOrder(userId, orderModel.Cart.Products, orderModel.Address, orderModel.Cart.TotalAmount);
            
            if(!result.Success)
                return RedirectToAction("Checkout", "Order", new { json=json, isSucceed = result.Success, message = result.Message });
            return RedirectToAction("Index", "Cart", new { isSucceed = result.Success, message = result.Message });
        }

    }
}
