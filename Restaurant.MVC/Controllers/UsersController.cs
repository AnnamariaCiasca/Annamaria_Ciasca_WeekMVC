using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.BusinessLayer;
using Restaurant.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restaurant.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBusinessLayer BL;

        public UsersController(IBusinessLayer BL)
        {
            this.BL = BL;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserLoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginViewModel userLoginViewModel)
        {
            if (userLoginViewModel == null)
            {
                return View();
            }

            var user = BL.GetUser(userLoginViewModel.Username);
            if (user != null && ModelState.IsValid)
            {
                if (user.Password == userLoginViewModel.Password)
                {

                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, user._Role.ToString())
                    };

                    var properties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1), 
                        RedirectUri = userLoginViewModel.ReturnUrl
                    };
                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                        );
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(userLoginViewModel.Password), "Password errata");
                    return View(userLoginViewModel);
                }
            }

            return View();
        }

        
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Forbidden() => View();

    }
}
