using System.Collections.Generic;

namespace EfCoreModeling.Model
{
    public class Adrres
    {
        public long AdrresId { get; set; }
        public string Adrress { get; set; }
        public List<User> User { get; set; } = new List<User>();

    }
}