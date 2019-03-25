using System.Collections.Generic;

namespace EfCoreModeling.Model
{
    public class Role
    {
        public long RoleId { get; set; }
        public string UserRole { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}