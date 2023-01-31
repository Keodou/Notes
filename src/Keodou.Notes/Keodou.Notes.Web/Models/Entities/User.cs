using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keodou.Notes.Web.Models.Entities
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым, введите логин")]
        [Column(TypeName = "nvarchar(50)")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым, введите пароль")]
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }

        public IEnumerable<Note> Notes { get; set; }
    }
}
