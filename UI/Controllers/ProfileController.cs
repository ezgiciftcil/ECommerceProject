using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UI.Models;

namespace UI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IOrderService orderService;
        public ProfileController(IOrderService _orderService)
        {
            orderService = _orderService;
        }
        public IActionResult Index()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            var model = new UserOrderModel();
            model.Orders = orderService.GetAllUserOrderToPage(userId).Data;
            return View(model);
        }
    }
}
