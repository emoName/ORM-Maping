using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreModeling.Model
{
    public class Role
    {
        [Key]
        [Required]
        [InverseProperty(nameof(User))]
        public int RoleId { get; set; }
        [Required]
        public string UserRole { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public byte[] RowVersion { get; set; }
    }
}