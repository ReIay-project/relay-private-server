// MessageCreateDto.cs
namespace Relay.DTOs
{
    public class MessageCreateDto
    {
        public string Content { get; set; } = string.Empty; // Содержимое сообщения
        public int UserId { get; set; } // ID пользователя, создавшего сообщение
    }
}
