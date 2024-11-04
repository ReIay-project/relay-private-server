using Relay.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Relay.Data;
using Relay.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Relay.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MessageService> _logger;

        public MessageService(ApplicationDbContext context, ILogger<MessageService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Message> GetMessageAsync(int id)
        {
            _logger.LogInformation("Запрос на получение сообщения ID {MessageId}", id);
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                _logger.LogWarning("Сообщение ID {MessageId} не найдено", id);
                throw new InvalidOperationException("Сообщение не найдено");
            }
            return message;
        }

        public async Task<Message> CreateMessageAsync(MessageCreateDto messageDto)
        {
            _logger.LogInformation("Создание нового сообщения");
            var message = new Message
            {
                Content = messageDto.Content,
                UserId = messageDto.UserId,
                Timestamp = DateTime.UtcNow // Используем UTC-время
            };
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Сообщение создано с ID {MessageId}", message.Id);
            return message;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesAsync() // Реализация метода для получения всех сообщений
        {
            _logger.LogInformation("Получение всех сообщений");
            return await _context.Messages.ToListAsync();
        }
    }
}
