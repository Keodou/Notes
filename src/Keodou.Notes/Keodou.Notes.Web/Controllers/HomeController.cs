using Microsoft.AspNetCore.Mvc;

namespace Keodou.Notes.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult WelcomePage()
        {
            return View();
        }
    }
}
