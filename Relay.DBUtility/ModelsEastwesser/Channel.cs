namespace Relay.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ServerId { get; set; }
        public int ChatId { get; set; } // Идентификатор чата, к которому принадлежит канал
        public Chat Chat { get; set; } = null!;
        public List<MessageInChannel> Messages { get; set; } = new List<MessageInChannel>(); // Сообщения в канале
    }
}
