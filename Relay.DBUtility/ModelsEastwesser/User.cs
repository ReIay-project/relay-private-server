namespace Relay.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; } // Ссылка на аватар
        public string Status { get; set; } = "online"; // Статус пользователя (online, offline, busy и другие.)
        public string Language { get; set; } = "ru"; // Язык интерфейса по умолчанию
    }
}
