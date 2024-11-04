namespace Relay.DTOs
{
    public class ChannelCreateDto
    {
        public string Name { get; set; } = string.Empty; // Название канала
        public int ServerId { get; set; } // ID сервера, к которому принадлежит канал
    }
}
