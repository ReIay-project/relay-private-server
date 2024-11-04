using Relay.DTOs;
using Relay.Models;
using System.Threading.Tasks;

namespace Relay.Services
{
    public interface IMessageService
    {
        Task<Message> GetMessageAsync(int id); // Получение сообщения по ID
        Task<Message> CreateMessageAsync(MessageCreateDto messageDto); // Создание нового сообщения
        Task<IEnumerable<Message>> GetAllMessagesAsync(); // Метод для получения всех сообщений
    }
}
