using System.Collections.Generic;
using System.Threading.Tasks;
using Relay.Models;
using Relay.Data;
using Microsoft.EntityFrameworkCore;

namespace Relay.Services
{
    public class PrivateServerService : IPrivateServerService
    {
        private readonly ApplicationDbContext _context;

        public PrivateServerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PrivateServer?> GetPrivateServerAsync(int id)
        {
            var server = await _context.PrivateServers.FindAsync(id);
            if (server == null)
            {
                throw new KeyNotFoundException($"Сервер с ID {id} не найден.");
            }
            return server;
        }

        public async Task<PrivateServer> CreatePrivateServerAsync(PrivateServer server)
        {
            _context.PrivateServers.Add(server);
            await _context.SaveChangesAsync();
            return server;
        }

        public async Task<IEnumerable<PrivateServer>> GetAllPrivateServersAsync()
        {
            return await _context.PrivateServers.ToListAsync();
        }
    }
}
