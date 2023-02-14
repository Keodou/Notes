using Keodou.Notes.Web.Data;
using Keodou.Notes.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Keodou.Notes.Web.Models.Repositories
{
    public class UserRepository
    {
        private readonly NotesDbContext _context;

        public UserRepository(NotesDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<User>> GetUsersAsync()
        {
            return await Task.Run(() => _context.Users);
        }

        public async Task<User> GetUserAsync(string login, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);
        }
    }
}
