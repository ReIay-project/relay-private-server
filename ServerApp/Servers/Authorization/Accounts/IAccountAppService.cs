using Abp.Application.Services;
using ServerApp.Servers.Authorization.Accounts.Dto;

namespace ServerApp.Servers.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}