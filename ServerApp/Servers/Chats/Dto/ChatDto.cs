using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using ServerApp.Servers.Messages.Dto;
using ServerApp.Servers.Users.Dto;

namespace ServerApp.Servers.Chats.Dto;

public class ChatDto
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
    public ListResultDto<MessageDto>? Messages { get; set; }
    public ListResultDto<UserDto>? Users { get; set; }
}