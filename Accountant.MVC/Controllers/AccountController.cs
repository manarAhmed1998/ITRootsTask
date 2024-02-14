using Accountant.BL;
using Accountant.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace Accountant.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager _usersManager;
        public AccountController(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserAddVM userToAdd)
        {
            if (ModelState.IsValid)
            {
                _usersManager.Add(userToAdd);
                return RedirectToAction("Login");
            }
            else
            {
                //UserReadVM userToView = _usersManager.map(userToAdd);
                return View(userToAdd);
            }

        }
    }
}
