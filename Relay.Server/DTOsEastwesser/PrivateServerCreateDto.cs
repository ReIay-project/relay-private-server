namespace Relay.DTOs
{
    public class PrivateServerCreateDto
    {
        public string Name { get; set; } = string.Empty; // Название сервера
        public int OwnerId { get; set; } // ID владельца сервера
    }
}
