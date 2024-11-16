using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ServerApp.Servers.Permissions.Dto;
using ServerApp.Servers.Roles.Dto;

namespace ServerApp.Servers.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, RoleResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

        Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);
    }
}