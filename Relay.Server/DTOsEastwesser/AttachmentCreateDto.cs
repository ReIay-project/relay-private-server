namespace Relay.DTOs
{
    public class AttachmentCreateDto
    {
        public string FileName { get; set; } = string.Empty; // Имя файла
        public string FileType { get; set; } = string.Empty; // Тип файла (например, "image/png")
        public int MessageId { get; set; } // ID сообщения, к которому прикреплено вложение
    }
}
