using Hotel_menu.Data;
using Hotel_menu.Models;
using Hotel_menu.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Controllers
{
    public class AccountController1 : Controller
    {
        private readonly MyDbContext _db;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController1(MyDbContext db,SignInManager<ApplicationUser> signIn, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _signInManager = signIn;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

           if (ModelState.IsValid)
           {
               var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                    if (user != null)
                    {
                        var result =
                            await _signInManager.PasswordSignInAsync
                            (user.Email, loginViewModel.Password,
                                loginViewModel.RememberMe, false);

                        if (result.Succeeded)
                        {                          
                            return RedirectToAction("Index", "Menu");
                        }

                    }
                }
                ModelState.AddModelError("","Invalid login");
                return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Name,
                    Email = model.Email,
                    EmailConfirmed = true

                };

                var userObj = await _userManager.FindByEmailAsync(model.Email);
                if (userObj == null)
                {
                    var result = await _userManager.CreateAsync(user,model.Password);
                    if (result.Succeeded)
                    {
                        //await _userManager.AddToRoleAsync(user, "Menu");

                        return RedirectToAction("Index", "Home");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login","AccountController1");
        }
    }
}

