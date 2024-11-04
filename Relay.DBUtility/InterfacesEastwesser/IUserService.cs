using System.Collections.Generic;
using System.Threading.Tasks;
using Relay.Models;
using Relay.DTOs;

namespace Relay.Services
{
    public interface IUserService
    {
        Task<User> RegisterAsync(UserCreateDto userDto); // Регистрация нового пользователя
        Task<User?> GetUserAsync(int id); // Возможен возврат null, если пользователя нет
        Task<User> CreateUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}