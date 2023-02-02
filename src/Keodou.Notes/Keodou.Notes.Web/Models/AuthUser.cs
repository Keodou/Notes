namespace Keodou.Notes.Web.Models
{
    public class AuthUser
    {
        public static Guid Id { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }

        public AuthUser(Guid id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }
    }
}