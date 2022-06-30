using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Extensions;
using WebShop.Models;
using WebShopServices.Managers;

namespace WebShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult SignIn()
        {
            var userModel = new SignInUserModel();
            return View(userModel);
        }

        [HttpPost]
        public IActionResult SignIn(SignInUserModel userModel)
        {
            var user = _userManager.GetUser(userModel.Email, userModel.Password);
            if (user is null)
            {
                ModelState.AddModelError("user", "email or password incorrect");
                return View(userModel);
            }
            else
            {
                HttpContext.SetSession(user);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            var userModel = new CreateUserModel();
            return View(userModel);
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(SignUp));
        }

        [HttpPost]
        public IActionResult SignUp(CreateUserModel model)
        {
            if (model.Password != model.RepeatPassword)
            {
                ModelState.AddModelError("password", "Password and repeat password are not the same");
            }

            if (ModelState.IsValid)
            {
                // We need to make sure e-mail isn't taken
                if (_userManager.CheckIfUserEmailExists(model.Email))
                {
                    ModelState.AddModelError("email", $"E-mail: {model.Email} is taken");
                    return View(model);
                }

                _userManager.AddUser(model.ToEntity());
                return RedirectToAction(nameof(SignIn));
                
            }
            else
            {
                return View(model);
            }
            
        }
    }
}
