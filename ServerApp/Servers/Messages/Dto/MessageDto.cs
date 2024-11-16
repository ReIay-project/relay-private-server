using System.ComponentModel.DataAnnotations;

namespace ServerApp.Servers.Messages.Dto;

public class MessageDto
{
    [Required] public int Id { get; set; }
    [Required] public DateTime Timestamp { get; set; }
    [Required] public string Content { get; set; }
}