using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.BLL.DTO;
using WebApp.BLL.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {

        private IUserService userService;
        private IMapper mapper;

        public AccountController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map<UserDTO>(model);
                userService.Register(user);

                return RedirectToAction("Login");
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userService.Login(model.Email, model.Password);

                if (user != null)
                {
                    await SignIn(user);

                    return RedirectToAction("List", "Todo");
                }

                ModelState.AddModelError("", "Email or password is incorrect");
                return View(model);
            }

            return View(model);
        }

        private async Task SignIn(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "User"),
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            await HttpContext.SignInAsync(claimPrincipal);
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("login", "account");
        }
    }
}
