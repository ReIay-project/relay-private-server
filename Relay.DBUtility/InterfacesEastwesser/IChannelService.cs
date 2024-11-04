using System.Collections.Generic;
using System.Threading.Tasks;
using Relay.Models;

namespace Relay.Services
{
    public interface IChannelService
    {
        Task<Channel?> GetChannelAsync(int id); // Возможен возврат null, если канал не найден
        Task<Channel> CreateChannelAsync(Channel channel);
        Task<IEnumerable<Channel>> GetAllChannelsAsync();
    }
}
