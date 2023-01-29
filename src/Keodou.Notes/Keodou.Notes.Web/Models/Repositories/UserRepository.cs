namespace Keodou.Notes.Web.Models.Repositories
{
    public class UserRepository
    {
        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User() { Id = 1, Login = "sa", Password = "sa"},
                new User() { Id = 2, Login = "sa2", Password = "sa2"}
            };
        }
    }
}
