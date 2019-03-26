namespace EfCoreModeling.Model
{
    public class Email
    {
        public long EmailId { get; set; }
        public string UserEmail { get; set; }
        public User User { get; set; }

    }
}