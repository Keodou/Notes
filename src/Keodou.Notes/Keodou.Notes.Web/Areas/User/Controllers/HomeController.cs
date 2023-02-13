using Keodou.Notes.Web.Models.Entities;
using Keodou.Notes.Web.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Notes()
        {
            var model = await _noteRepository.GetNotesByUserId(GetUserIdCookie());
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Note note)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    note.UserId = GetUserIdCookie();
                    await _noteRepository.Save(note);
                    return RedirectToAction(nameof(Notes));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Изменения не были сохранены, попробуйте еще раз");
            }
            return View(note);

            //if (ModelState.IsValid)
            //{
            //    await _noteRepository.Save(note);
            //    return RedirectToAction(nameof(Notes));
            //}
            //return View(note);
        }

        private Guid GetUserIdCookie()
        {
            var idString = Request.Cookies["UserId"];
            return new Guid(idString);
        }
    }
}
