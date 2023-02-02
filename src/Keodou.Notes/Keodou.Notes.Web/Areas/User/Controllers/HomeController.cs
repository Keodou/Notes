using Keodou.Notes.Web.Models;
using Keodou.Notes.Web.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keodou.Notes.Web.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly NoteRepository _noteRepository;

        public HomeController(UserRepository userRepository, NoteRepository noteRepository)
        {
            _userRepository = userRepository;
            _noteRepository = noteRepository;
        }

        public IActionResult Notes()
        {
            var model = _noteRepository.GetNotes(AuthUser.Id).ToList();
            return View(model);
        }
    }
}
