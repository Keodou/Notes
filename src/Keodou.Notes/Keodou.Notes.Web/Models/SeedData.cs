using Keodou.Notes.Web.Data;
using Keodou.Notes.Web.Models.Entities;

namespace Keodou.Notes.Web.Models
{
    public class SeedData
    {
        public static NotesDbContext _context;

        public SeedData(NotesDbContext context)
        {
            _context = context;
        }

        public static void EnsurePopulated()
        {
            _context.Users.AddRange(
                new User() { Id = new Guid("845d105e-1943-40af-b7f1-c76ece311183"), Login = "sa", Password = "sa" },
                new User() { Id = new Guid("dcda2ef5-4727-4be4-839f-bbc351a755e0"), Login = "sa2", Password = "sa2" }
            );
            _context.SaveChanges();
        }
    }
}
