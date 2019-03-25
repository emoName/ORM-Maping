namespace EfCoreModeling.Model
{
    public class Email
    {
        public long EmailId { get; set; }
        public string UserMeil { get; set; }
        public User User { get; set; }

    }
}