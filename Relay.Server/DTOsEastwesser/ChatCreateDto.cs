namespace Relay.DTOs
{
    public class ChatCreateDto
    {
        public string Title { get; set; } = string.Empty; // Название чата
        public List<int> MemberIds { get; set; } = new(); // Список ID участников чата
    }
}
