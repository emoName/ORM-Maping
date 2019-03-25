namespace EfCoreModeling.Model
{
    public class Message
    {
        public long MessageId { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}