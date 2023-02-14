using Keodou.Notes.Web.Models.Entities;
using Keodou.Notes.Web.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Keodou.Notes.Web.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class NotesController : Controller
    {
        private readonly NoteRepository _noteRepository;

        public NotesController(NoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IActionResult> NotesList()
        {
            var model = await _noteRepository.GetNotesByUserIdAsync(GetUserIdCookie());
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var note = await _noteRepository.GetNoteByIdAsync(id);
            if (note is null)
                return NotFound();
            return View(note);
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
                    await _noteRepository.SaveAsync(note);
                    return RedirectToAction(nameof(NotesList));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Изменения не были сохранены, попробуйте еще раз");
            }
            return View(note);
        }

        public async Task<IActionResult> EditNote(Guid id)
        {
            var note = await _noteRepository.GetNoteByIdAsync(id);
            if (note is not null)
                return View(note);
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNote(Note note)
        {
            try
            {
                await _noteRepository.SaveAsync(note);
                return RedirectToAction(nameof(NotesList));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Изменения не были сохранены, попробуйте еще раз");
            }
            return View(note);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var note = await _noteRepository.GetNoteByIdAsync(id);
            try
            {
                if (note is not null)
                {
                    await _noteRepository.DeleteAsync(note);
                    return RedirectToAction(nameof(NotesList));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Изменения не были сохранены, попробуйте еще раз");
            }
            return NotFound();
        }

        private Guid GetUserIdCookie()
        {
            var idString = Request.Cookies["UserId"];
            return new Guid(idString);
        }
    }
}
