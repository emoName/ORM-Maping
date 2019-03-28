using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreModeling.Model
{
    public class Adrres
    {
        [Key]
        [Required]
        [InverseProperty(nameof(User))]
        public int AdrresId { get; set; }
        [Required]
        public string Adrress { get; set; }
        public List<User> User { get; set; } = new List<User>();
        public byte[] RowVersion { get; set; }

    }
}