using BusinessLayer.Auth.Interfaces;
using BusinessLayer.Auth.Models;
using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ICityService cityService;
        private readonly IAuthService authService;
        public RegisterController(ICityService _cityService, IAuthService _authService)
        {
            cityService = _cityService;
            authService = _authService;
        }
        public IActionResult Index()
        {
            var cityList = new CityList(cityService);
            var cities = cityList.GetCities();
            ViewBag.cities = cities;
            return View();
        }
        [HttpPost]
        public IActionResult Index(NewAccountForm newAccount)
        {
            var result = authService.Register(newAccount);
            if (result.Success)
            {
                HttpContext.Session.SetInt32(SessionService.SessionUserId, authService.GetUserIdForSession(newAccount.Email));
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMessage = result.Message;
            var cityList = new CityList(cityService);
            var cities = cityList.GetCities();
            ViewBag.cities = cities;
            return View();
        }

    }
}
