using Keodou.Notes.Web.Data;
using Keodou.Notes.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Keodou.Notes.Web.Models.Repositories
{
    public class NoteRepository
    {
        private readonly NotesDbContext _context;

        public NoteRepository(NotesDbContext context)
        {
            _context = context;
        }

        public IQueryable<Note> GetNotes() => _context.Notes;

        public async Task<List<Note>> GetNotesByUserIdAsync(Guid id)
        {
            return await Task.Run(() => _context.Notes.Where(n => n.UserId == id).ToListAsync());
        }

        public async Task<Note> GetNoteByIdAsync(Guid id)
        {
            return await Task.Run(() => _context.Notes.SingleAsync(n => n.Id == id));
        }

        public async Task SaveAsync(Note note)
        {
            if (note.Id == default)
            {
                _context.Add(note);
            }
            else
            {
                _context.Update(note);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Note note)
        {
            _context.Remove(note);
            await _context.SaveChangesAsync();
        }
    }
}
