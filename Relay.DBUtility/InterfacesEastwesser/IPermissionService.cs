using System.Collections.Generic;
using System.Threading.Tasks;
using Relay.Models;

namespace Relay.Services
{
    public interface IPermissionService
    {
        Task<Permission?> GetPermissionAsync(int id); // Возможен возврат null, если разрешение не найдено
        Task<Permission> CreatePermissionAsync(Permission permission);
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
    }
}
