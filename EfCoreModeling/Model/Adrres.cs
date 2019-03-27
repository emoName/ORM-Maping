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
        public long AdrresId { get; set; }
        [Required]
        public string Adrress { get; set; }
        public List<User> User { get; set; } = new List<User>();

    }
}