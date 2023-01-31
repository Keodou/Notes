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
    }
}
