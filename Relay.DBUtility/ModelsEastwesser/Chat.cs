namespace Relay.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsGroupChat { get; set; } // Определяет, является ли чат групповым
        public List<User> Members { get; set; } = new List<User>(); // Пользователи в чате
        public List<Message> Messages { get; set; } = new List<Message>(); // Сообщения в чате
    }
}
