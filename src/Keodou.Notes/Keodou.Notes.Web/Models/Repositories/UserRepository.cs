using Keodou.Notes.Web.Data;
using Keodou.Notes.Web.Models.Entities;

namespace Keodou.Notes.Web.Models.Repositories
{
    public class UserRepository
    {
        private readonly NotesDbContext _context;

        public UserRepository(NotesDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetUsers() => _context.Users;
    }
}
