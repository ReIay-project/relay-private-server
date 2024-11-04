namespace Relay.DTOs
{
    public class PermissionCreateDto
    {
        public string Name { get; set; } = string.Empty; // Название разрешения
        public string Description { get; set; } = string.Empty; // Описание разрешения
    }
}