using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keodou.Notes.Web.Models.Entities
{
    public class Note
    {
        [Required]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string Head { get; set; }

        [Required]
        public string Text { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
