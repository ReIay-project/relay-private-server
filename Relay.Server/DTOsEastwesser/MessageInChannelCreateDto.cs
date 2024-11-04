namespace Relay.DTOs
{
    public class MessageInChannelCreateDto
    {
        public int ChannelId { get; set; } // ID канала, в котором создается сообщение
        public string Content { get; set; } = string.Empty; // Содержимое сообщения
        public int UserId { get; set; } // ID пользователя, отправившего сообщение
    }
}
