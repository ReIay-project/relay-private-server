// Подключаем необходимые пространства имен для работы с культурами и HTTP-запросами
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace Relay.Middlewares
{
    // Middleware для установки культуры на основе запроса
    public class CultureMiddleware
    {
        // Поля для хранения ссылки на следующий middleware и провайдера культуры
        private readonly RequestDelegate _next;
        private readonly RequestCultureProvider _cultureProvider;

        // Конструктор принимает делегат для передачи управления следующему middleware и провайдер культуры
        public CultureMiddleware(RequestDelegate next, RequestCultureProvider cultureProvider)
        {
            _next = next;
            _cultureProvider = cultureProvider;
        }

        // Метод для обработки входящего запроса и установки текущей культуры
        public async Task InvokeAsync(HttpContext context)
        {
            // Определяем культуру для текущего запроса, используя провайдер культуры
            var culture = _cultureProvider.DetermineRequestCulture(context);

            // Устанавливаем выбранную культуру как текущую для выполнения запроса
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            // Передаем управление следующему middleware в конвейере
            await _next(context);
        }
    }
}
