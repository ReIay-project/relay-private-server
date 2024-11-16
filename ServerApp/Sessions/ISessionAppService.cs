using Abp.Application.Services;
using ServerApp.Sessions.Dto;

namespace ServerApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}