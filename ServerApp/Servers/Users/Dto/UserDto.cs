using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ServerApp.Servers.Chats.Dto;
using ServerApp.Servers.Configuration.Dto;
using ServerCore.Server.Users;

namespace ServerApp.Servers.Users.Dto;

[AutoMapFrom(typeof(User))]
public class UserDto : EntityDto<long>
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
    public bool IsActive { get; set; }
    public ListResultDto<ChatDto>? Chats { get; set; }
    public ListResultDto<ServerDto>? Servers { get; set; }
    public List<string>? UserRolesNames { get; set; }
    [Required] public string Password { get; set; }
    public DateTime? LastLoginTime { get; set; }
    public DateTime CreationTime { get; set; }
}