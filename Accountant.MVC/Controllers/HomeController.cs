using Accountant.BL;
using Accountant.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Accountant.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersManager _usersManager;


        public HomeController(ILogger<HomeController> logger,IUsersManager usersManager)
        {
            _logger = logger;
            _usersManager = usersManager;
        }

        public IActionResult Index()
        {
            IEnumerable<UserReadVM> users = _usersManager.GetAll();
            return View(users);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
