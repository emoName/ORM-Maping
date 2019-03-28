using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCoreModeling.Model
{

    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }

        [ForeignKey(nameof(Email))]
        public int? EmailId { get; set; }
        public Email Email { get; set; }

        [ForeignKey(nameof(Adrres))]
        public int? AdrresId { get; set; }
        public Adrres Adrres { get; set; }

        public List<Message> Message { get; set; } = new List<Message>();

        [ForeignKey(nameof(Role))]
        public int? RoleID { get; set; }
        public Role Role { get; set; }



    }
}
