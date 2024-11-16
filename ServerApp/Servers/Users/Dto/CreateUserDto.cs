using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using ServerApp.Servers.Chats.Dto;
using ServerApp.Servers.Configuration.Dto;

namespace ServerApp.Servers.Users.Dto;

[AutoMapTo(typeof(UserDto))]
public class CreateUserDto : IShouldNormalize
{
    [Required] public int Id { get; set; }

    [Required]
    [StringLength(AbpUserBase.MaxNameLength)]
    public string Name { get; set; }

    public bool IsActive { get; set; }
    public List<ChatDto>? Chats { get; set; }
    public List<ServerDto>? Servers { get; set; }
    public List<string>? UserRolesNames { get; set; }

    [Required]
    [StringLength(AbpUserBase.MaxPlainPasswordLength)]
    [DisableAuditing]
    public string Password { get; set; }

    public void Normalize()
    {
        if (UserRolesNames == null)
        {
            UserRolesNames = new();
        }
    }
}