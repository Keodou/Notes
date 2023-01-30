using Keodou.Notes.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Keodou.Notes.Web.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
