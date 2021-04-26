using System.Threading.Tasks;
using MCMDirect.Areas.Store.Models;
using MCMDirect.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MCMDirect.Controllers {
    public class AccountController : Controller {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private readonly ILogger<AccountController> _logger;
        
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            _logger.Log(LogLevel.Information, "Getting registration page");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    bool isPersistent = false;
                    await signInManager.SignInAsync(user, isPersistent);
                    _logger.Log(LogLevel.Information, "Registed user: " + model.Email);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.Log(LogLevel.Information,
                            "Errors while registering user: " + model.Email + ": " + error);
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            _logger.Log(LogLevel.Information, "Invalid registration for user: " + model.Email);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            _logger.Log(LogLevel.Information, "Logging out user: " + User.Identity.Name);
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel {ReturnUrl = returnURL};
            _logger.Log(LogLevel.Information, "Getting log in page");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email
                    , model.Password, isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.Log(LogLevel.Information, "Successfully logged in user: " + User.Identity.Name);

                    if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                        Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            _logger.Log(LogLevel.Information, "Invalid credentials for user: " + User.Identity.Name);
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }
    }
}