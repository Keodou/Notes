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

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = new Guid("e859f530-c911-4a70-9e94-9c16042ba884"),
                Login = "sa",
                Password = "sa"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = new Guid("2b5944b6-3e64-4904-a74e-c2b93e598d0f"),
                Login = "sa2",
                Password = "sa2"
            });
            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = new Guid("decb6c0d-7369-43a7-ad39-769039b9241d"),
                Head = "Завтрак",
                Text = "Приготовить яичницу и сварить кофе",
                UserId = new Guid("e859f530-c911-4a70-9e94-9c16042ba884")
            });
            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = new Guid("921eca58-a972-46bc-8e40-b4236ba0cfba"),
                Head = "Обед",
                Text = "Сьесть суп и купить чипсы",
                UserId = new Guid("e859f530-c911-4a70-9e94-9c16042ba884")
            });
            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = new Guid("8f1c9edb-252e-4abb-90c8-5601940d9e8a"),
                Head = "Резюме",
                Text = "Составить резюме для поиска вакансии на джуна",
                UserId = new Guid("2b5944b6-3e64-4904-a74e-c2b93e598d0f")
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
