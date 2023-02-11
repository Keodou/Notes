using Keodou.Notes.Web.Data;
using Keodou.Notes.Web.Models.Entities;

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

        public IQueryable<Note> GetNotesById(Guid id) => _context.Notes.Where(n => n.UserId == id);

        public async Task Save(Note note)
        {
            if (note == default)
            {
                _context.Notes.Add(note);
            }
            else
            {
                _context.Notes.Update(note);
            }
            await _context.SaveChangesAsync();
        }
    }
}
