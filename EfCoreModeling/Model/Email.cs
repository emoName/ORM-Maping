using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreModeling.Model
{
    public class Email
    {
        [Key]
        [Required]
        [InverseProperty(nameof(User))]
        public long EmailId { get; set; }
        [Required]
        public string UserEmail { get; set; }
        public User User { get; set; }

    }
}