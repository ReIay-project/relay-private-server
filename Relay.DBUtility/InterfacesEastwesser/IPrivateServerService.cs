using System.Collections.Generic;
using System.Threading.Tasks;
using Relay.Models;

namespace Relay.Services
{
    public interface IPrivateServerService
    {
        Task<PrivateServer?> GetPrivateServerAsync(int id);
        Task<PrivateServer> CreatePrivateServerAsync(PrivateServer server);
        Task<IEnumerable<PrivateServer>> GetAllPrivateServersAsync();
    }
}
