using System.Collections.Generic;
using System.Threading.Tasks;
using Relay.Models;
using Relay.Data;
using Microsoft.EntityFrameworkCore;

namespace Relay.Services
{
    public class ChannelService : IChannelService
    {
        private readonly ApplicationDbContext _context;

        public ChannelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Channel?> GetChannelAsync(int id)
        {
            var channel = await _context.Channels.Include(c => c.Messages).FirstOrDefaultAsync(c => c.Id == id);
            if (channel == null)
            {
                throw new KeyNotFoundException($"Канал с ID {id} не найден.");
            }
            return channel;
        }

        public async Task<Channel> CreateChannelAsync(Channel channel)
        {
            _context.Channels.Add(channel);
            await _context.SaveChangesAsync();
            return channel;
        }

        public async Task<IEnumerable<Channel>> GetAllChannelsAsync()
        {
            return await _context.Channels.ToListAsync();
        }
    }
}
