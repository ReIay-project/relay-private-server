namespace Relay.Models
{
    public class MessageInChannel
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public int ChannelId { get; set; }
        public Channel Channel { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
