using System.Threading.Tasks;
using Relay.Models;
using System.Collections.Generic;

namespace Relay.Services
{
    public interface IChatService
    {
        Task<Chat> GetChatAsync(int id); // Получение чата по ID, возможен возврат null, если чат не найден
        Task<Chat> CreateChatAsync(Chat chat); // Создание нового чата
        Task<IEnumerable<Chat>> GetAllChatsAsync(); // Получение всех чатов
    }
}
