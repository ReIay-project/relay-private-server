using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Relay.Middlewares
{
    // Middleware для обработки и установки культуры в зависимости от запроса.
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LocalizationMiddleware> _logger;

        // Конструктор принимает следующий middleware и логгер.
        public LocalizationMiddleware(RequestDelegate next, ILogger<LocalizationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // Основной метод, обрабатывающий запросы и задающий культуру.
        public async Task InvokeAsync(HttpContext context)
        {
            // Определяем культуру на основе строки запроса или заголовков.
            var culture = DetermineRequestCulture(context);

            // Устанавливаем выбранную культуру в текущий поток.
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            // Логируем информацию о выбранной культуре.
            _logger.LogInformation("Установлена культура: {Culture}", culture.Name);

            // Передача управления следующему middleware.
            await _next(context);
        }

        // Метод для определения культуры на основе строки запроса или заголовка Accept-Language.
        private CultureInfo DetermineRequestCulture(HttpContext context)
        {
            // Проверка параметра "lang" в строке запроса.
            var langQuery = context.Request.Query["lang"].ToString();
            if (!string.IsNullOrEmpty(langQuery) && IsCultureValid(langQuery))
            {
                _logger.LogInformation("Культура из параметра запроса: {LangQuery}", langQuery);
                return new CultureInfo(langQuery);
            }

            // Проверка заголовка Accept-Language.
            var acceptLanguage = context.Request.Headers["Accept-Language"].FirstOrDefault();
            if (!string.IsNullOrEmpty(acceptLanguage))
            {
                var cultures = acceptLanguage.Split(',');
                if (cultures.Length > 0 && IsCultureValid(cultures[0]))
                {
                    _logger.LogInformation("Культура из заголовка: {HeaderCulture}", cultures[0]);
                    return new CultureInfo(cultures[0]);
                }
            }

            // Возвращаем культуру по умолчанию, если запрос не содержит корректных данных.
            _logger.LogWarning("Культура не указана или недействительна. Установлена культура по умолчанию: 'ru'");
            return new CultureInfo("ru");
        }

        // Метод для проверки валидности культуры.
        private bool IsCultureValid(string cultureName)
        {
            try
            {
                CultureInfo.GetCultureInfo(cultureName);
                return true;
            }
            catch (CultureNotFoundException)
            {
                _logger.LogWarning("Некорректная культура: {InvalidCulture}", cultureName);
                return false;
            }
        }
    }
}
