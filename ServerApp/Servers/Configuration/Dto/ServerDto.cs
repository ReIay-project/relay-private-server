using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using ServerApp.Servers.Chats.Dto;
using ServerApp.Servers.Commands.Dto;
using ServerApp.Servers.Permissions.Dto;
using ServerApp.Servers.Roles.Dto;

namespace ServerApp.Servers.Configuration.Dto;

public class ServerDto
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Address { get; set; }
    [Required] public int Port { get; set; }
    public string? Password { get; set; }
    public ListResultDto<CommandDto> Commands { get; set; }
    public ListResultDto<RoleDto> ServerRoles { get; set; }
    public ListResultDto<PermissionDto> ServerPermissions { get; set; }
    public ListResultDto<ChatDto> Chats { get; set; }
}