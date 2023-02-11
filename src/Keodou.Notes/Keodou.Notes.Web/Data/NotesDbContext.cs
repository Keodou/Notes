using Keodou.Notes.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Keodou.Notes.Web.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {

        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
