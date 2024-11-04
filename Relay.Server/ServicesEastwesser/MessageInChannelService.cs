using System.Collections.Generic;
using System.Threading.Tasks;
using Relay.Models;
using Relay.Data;
using Microsoft.EntityFrameworkCore;

namespace Relay.Services
{
    public class MessageInChannelService : IMessageInChannelService
    {
        private readonly ApplicationDbContext _context;

        public MessageInChannelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MessageInChannel?> GetMessageInChannelAsync(int id)
        {
            var messageInChannel = await _context.MessageInChannels.FindAsync(id);
            if (messageInChannel == null)
            {
                throw new KeyNotFoundException($"Сообщение с ID {id} не найдено в канале.");
            }
            return messageInChannel;
        }

        public async Task<MessageInChannel> CreateMessageInChannelAsync(MessageInChannel message)
        {
            _context.MessageInChannels.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<IEnumerable<MessageInChannel>> GetAllMessagesInChannelAsync(int channelId)
        {
            return await _context.MessageInChannels
                .Where(m => m.ChannelId == channelId)
                .ToListAsync();
        }
    }
}
