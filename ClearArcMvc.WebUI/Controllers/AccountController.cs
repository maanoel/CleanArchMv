using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CleanArchMvc.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticate _authenticate;

        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authenticate.Authenticate(model.Email, model.Password);

            if (result)
            {

                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction(nameof(Index), "Home");
                }

                return Redirect(model.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attepmpt. (password must be strong).");

            return View(model);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _authenticate.RegisterUser(model.Email, model.Password);

            if (result)
            {
                return Redirect("/");
            }

            ModelState.AddModelError(string.Empty, "Invalid register attempet");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await _authenticate.Logout();
            return Redirect("/Account/Login");
        }
    }
}
