using BusinessLayer.Auth.Interfaces;
using BusinessLayer.Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService authService;
        public LoginController(IAuthService _authService)
        {
            authService = _authService;
        }
        public IActionResult Index(string Message=null)
        {
            ViewBag.ErrorMessage = Message;
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginForm form)
        {
            var result = authService.Login(form);
            if (result.Success)
            {
                HttpContext.Session.SetInt32(SessionService.SessionUserId, authService.GetUserIdForSession(form.Email));
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMessage = result.Message;
            return View();
        }
    }
}
