using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;

namespace ServerApp.Servers.Permissions.Dto;

[AutoMapFrom(typeof(Permission))]
public class PermissionDto : EntityDto<long>
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
}