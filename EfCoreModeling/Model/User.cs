using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCoreModeling.Model
{
  public  class User
    {
        [Key]
        long UserId
        {
            get; set;
        }
        public string UserName
        {
            get; set;
        }
        public long EmailId
        {
            get; set;
        }
        public Email Email
        {
            get; set;
        }
        public long AdrresId
        {
            get; set;
        }
        public Adrres Adrres { get; set; }
        public List<Message> Message { get; set; } = new List<Message>();
        public long RoleID
        {
            get; set;
        }
        public Role Role { get; set; }



    }
}
