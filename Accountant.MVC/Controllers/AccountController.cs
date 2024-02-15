using Accountant.BL;
using Accountant.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using System.Diagnostics.Eventing.Reader;

namespace Accountant.MVC.Controllers;

public class AccountController : Controller
{
    private readonly IUsersManager _usersManager;
    public AccountController(IUsersManager usersManager)
    {
        _usersManager = usersManager;
    }

    #region Registration
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

    #endregion

    #region Login

    [HttpGet]
         public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
         public IActionResult Login(UserLoginVM user)
        {
            if (user != null)
            {
                //1. Check if User Exists in DB 
                User? userCheck = _usersManager.getByUserName(user.UserName);
                //2. Check Correct Password and correct user type
                if (userCheck.Password == user.Password && userCheck.UserType == user.UserType)
                {
                    MyTempData.CurrentUser = userCheck;
                    return RedirectToAction("Index", "Home");
                }

            }
            return View(user);
       
        }
    #endregion

    #region Edit User

    #endregion

    #region Delete User
    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        User? userToRemove = _usersManager.getUserById(id);

        _usersManager.Delete(userToRemove);

        return RedirectToAction("Index","Account");
    }
    #endregion

}
