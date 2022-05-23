using BusinessLayer.Services.Interfaces;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class Test : Controller
    {
        private readonly IUserTypeService userTypeService;
        private readonly IUserService userService;
        public Test(IUserTypeService _userTypeService,IUserService _userService)
        {
            userTypeService = _userTypeService;
            userService = _userService;
        }
        public IActionResult UserTypeAdd()
        {
            return View();
        }

      
        [HttpPost]
        public IActionResult UserTypeAdd(Text text)
        {
            var userType = new UserType()
            {
                TypeName = text.TextString
            };
            userTypeService.AddUserType(userType);
            return View();
        }

        public IActionResult UserAdd()
        {
            return View();

        }
        [HttpPost]
        public IActionResult UserAdd(User user)
        {
            user.UserTypeId = 1;
            userService.AddUser(user);
            return View();

        }
    }
}
