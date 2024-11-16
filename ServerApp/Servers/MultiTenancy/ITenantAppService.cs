using Abp.Application.Services;
using ServerApp.Servers.MultiTenancy.Dto;

namespace ServerApp.Servers.MultiTenancy
{
    public interface
        ITenantAppService : IAsyncCrudAppService<TenantDto, int, TenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}