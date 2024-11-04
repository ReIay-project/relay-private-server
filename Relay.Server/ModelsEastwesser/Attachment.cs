namespace Relay.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty; // Тип файла (image, video, document)
        public int MessageId { get; set; }
        public Message Message { get; set; } = null!;
    }
}
