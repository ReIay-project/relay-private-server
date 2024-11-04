using System.Threading.Tasks;
using Relay.Models;
using Relay.DTOs;
using Relay.Data;
using Microsoft.Extensions.Logging;

namespace Relay.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RoleService> _logger;

        public RoleService(ApplicationDbContext context, ILogger<RoleService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Получение роли по ID.
        /// </summary>
        public async Task<Role> GetRoleAsync(int id)
        {
            _logger.LogInformation("Запрос на получение роли ID {RoleId}", id);
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                _logger.LogWarning("Роль ID {RoleId} не найдена", id);
                throw new InvalidOperationException("Роль не найдена");
            }
            return role;
        }

        /// <summary>
        /// Создание новой роли.
        /// </summary>
        public async Task<Role> CreateRoleAsync(RoleCreateDto roleDto)
        {
            _logger.LogInformation("Создание новой роли именем {RoleName}", roleDto.Name);
            var role = new Role { Name = roleDto.Name };
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Роль создана ID {RoleId}", role.Id);
            return role;
        }
    }
}
