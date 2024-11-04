using System.Threading.Tasks;
using Relay.Models;
using Relay.DTOs;

namespace Relay.Services
{
    public interface IRoleService
    {
        Task<Role> GetRoleAsync(int id); // Получение роли по ID
        Task<Role> CreateRoleAsync(RoleCreateDto roleDto); // Создание новой роли
        Task<IEnumerable<Role>> GetAllRolesAsync();
    }
}
