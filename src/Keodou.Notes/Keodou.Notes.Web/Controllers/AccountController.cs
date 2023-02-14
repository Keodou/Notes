using Keodou.Notes.Web.Models.Repositories;
using Keodou.Notes.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Keodou.Notes.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository;

        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userRepository.GetUserAsync(model.Login, model.Password);
            if (user is null)
                return View(model);

            // Add auth. cookie
            var claims = new List<Claim>()
            {
                new Claim(model.Login, model.Password)
            };
            var claimIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookies", claimPrincipal);
            Response.Cookies.Append("UserId", $"{user.Id}");

            return Redirect(model.ReturnUrl);
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("WelcomePage", "Home");
        }
    }
}
