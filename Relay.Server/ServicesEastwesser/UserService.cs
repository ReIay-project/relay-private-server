using System.Collections.Generic;
using System.Threading.Tasks;
using Relay.Models;
using Relay.DTOs;
using Relay.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Relay.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(ApplicationDbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Регистрация нового пользователя.
        /// </summary>
        public async Task<User> RegisterAsync(UserCreateDto userDto)
        {
            _logger.LogInformation("Регистрация нового пользователя с именем {Username}", userDto.Username);
            var user = new User { Username = userDto.Username!, Password = userDto.Password! };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Пользователь зарегистрирован, ID {UserId}", user.Id);
            return user;
        }

        /// <summary>
        /// Получение пользователя по ID.
        /// </summary>
        public async Task<User?> GetUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"Пользователь с ID {id} не найден.");
            }
            return user;
        }

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// Получение всех пользователей.
        /// </summary>
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
