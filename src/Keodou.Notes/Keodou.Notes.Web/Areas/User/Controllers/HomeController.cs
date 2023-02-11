using Keodou.Notes.Web.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keodou.Notes.Web.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly NoteRepository _noteRepository;

        public HomeController(NoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public IActionResult Notes()
        {
            var idString = Request.Cookies["UserId"];
            var id = new Guid(idString);
            var model = _noteRepository.GetNotesById(id).ToList();
            return View(model);
        }

        public async Task<IActionResult> CreateNote()
        {

        }
    }
}
