// Подключаем пространства имен для работы с культурами, HTTP-запросами и логированием
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Relay.Middlewares
{
    // Middleware для логирования информации о выбранной культуре и ее сохранения в текущем контексте
    public class LocalizationMiddleware
    {
        // Поля для хранения делегата следующего middleware, провайдера культуры и логгера
        private readonly RequestDelegate _next;
        private readonly RequestCultureProvider _requestCultureProvider;
        private readonly ILogger<LocalizationMiddleware> _logger;

        // Конструктор инициализирует параметры
        public LocalizationMiddleware(
            RequestDelegate next,
            RequestCultureProvider requestCultureProvider,
            ILogger<LocalizationMiddleware> logger
        )
        {
            _next = next;
            _requestCultureProvider = requestCultureProvider;
            _logger = logger;
        }

        // Метод для обработки входящего запроса и установки культуры
        public async Task InvokeAsync(HttpContext context)
        {
            // Определяем культуру запроса, используя RequestCultureProvider
            var culture = _requestCultureProvider.DetermineRequestCulture(context);

            // Сохраняем информацию о культуре в контексте запроса
            context.Items["RequestCulture"] = culture;

            // Логируем установленную культуру для текущего запроса
            _logger.LogInformation("Культура запроса установлена: {Culture}", culture.Name);

            // Передача управления следующему middleware
            await _next(context);
        }
    }
}
