namespace Relay.Models
{
    public class PrivateServer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int OwnerId { get; set; } // Поле OwnerId для владельца
    }
}