using System.Collections.Generic;
using System.Threading.Tasks;
using Relay.Models;

namespace Relay.Services
{
    public interface IMessageInChannelService
    {
        Task<MessageInChannel?> GetMessageInChannelAsync(int id); // Возможен возврат null, если сообщение не найдено
        Task<MessageInChannel> CreateMessageInChannelAsync(MessageInChannel message);
        Task<IEnumerable<MessageInChannel>> GetAllMessagesInChannelAsync(int channelId);
    }
}
