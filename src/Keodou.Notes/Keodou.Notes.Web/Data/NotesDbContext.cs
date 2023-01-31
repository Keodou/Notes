using Keodou.Notes.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Keodou.Notes.Web.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = new Guid("decb6c0d-7369-43a7-ad39-769039b9241d"),
                Head = "Завтрак",
                Text = "Приготовить яичницу и сварить кофе",
                UserId = new Guid("dcda2ef5-4727-4be4-839f-bbc351a755e0")
            });
            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = new Guid("921eca58-a972-46bc-8e40-b4236ba0cfba"),
                Head = "Обед",
                Text = "Сьесть суп и купить чипсы",
                UserId = new Guid("dcda2ef5-4727-4be4-839f-bbc351a755e0")
            });
            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = new Guid("8f1c9edb-252e-4abb-90c8-5601940d9e8a"),
                Head = "Резюме",
                Text = "Составить резюме для поиска вакансии на джуна",
                UserId = new Guid("845d105e-1943-40af-b7f1-c76ece311183")
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
