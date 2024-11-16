using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ServerApp.Servers.Roles.Dto;
using ServerApp.Servers.Users.Dto;

namespace ServerApp.Servers.Users
{
    public interface
        IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}