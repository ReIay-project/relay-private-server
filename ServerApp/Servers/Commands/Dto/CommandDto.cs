using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using ServerApp.Servers.Permissions.Dto;

namespace ServerApp.Servers.Commands.Dto;

public class CommandDto
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public Action Execute { get; set; }
    [Required] public ListResultDto<PermissionDto> Permissions { get; set; }
}