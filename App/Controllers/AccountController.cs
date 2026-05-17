using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class AccountController : Controller
    {
        UserService userService;

        public AccountController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterDTO());
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO u)
        {
            if (ModelState.IsValid)
            {
                var res = userService.Register(u);

                if (res == true)
                {
                    return RedirectToAction("Login");
                }
            }

            return View(u);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDTO());
        }

        [HttpPost]
        public IActionResult Login(LoginDTO u)
        {
            if (ModelState.IsValid)
            {
                var data = userService.Login(u);

                if (data != null)
                {
                    HttpContext.Session.SetString("UserName", data.Name!);

                    HttpContext.Session.SetString("Role", data.Role!);

                    HttpContext.Session.SetInt32("UserId", data.Id);

                    if (data.Role != null && data.Role.Equals("Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }

                    return RedirectToAction("Index", "Event");
                }

                TempData["msg"] = "Invalid Email or Password";
            }

            return View(u);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}