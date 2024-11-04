// Подключаем пространства имен для работы с культурами, HTTP-запросами и логированием
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Relay.Middlewares
{
    // Класс, отвечающий за выбор культуры для текущего запроса
    public class RequestCultureProvider
    {
        // Поле для логирования действий, связанных с выбором культуры
        private readonly ILogger<RequestCultureProvider> _logger;

        // Конструктор, принимающий логгер в качестве зависимости
        public RequestCultureProvider(ILogger<RequestCultureProvider> logger)
        {
            _logger = logger;
        }

        // Метод для определения культуры запроса на основе параметров запроса и заголовков
        public CultureInfo DetermineRequestCulture(HttpContext context)
        {
            // Проверка на наличие параметра "lang" в строке запроса
            var langQuery = context.Request.Query["lang"].ToString();
            _logger.LogInformation("Параметр lang из строки запроса: {LangQuery}", langQuery);

            if (!string.IsNullOrEmpty(langQuery))
            {
                // Проверка на допустимость указанной культуры
                if (IsCultureValid(langQuery))
                {
                    // Если культура допустима, возвращаем её
                    return new CultureInfo(langQuery);
                }
                else
                {
                    // Логируем сообщение, если указанная культура недопустима
                    _logger.LogWarning($"Запрашиваемая культура недействительна: {langQuery}. Устанавливается культура по умолчанию 'ru'.");
                }
            }

            // Если параметра "lang" нет, проверяем заголовок Accept-Language
            var acceptLanguage = context.Request.Headers["Accept-Language"].FirstOrDefault();
            _logger.LogInformation("Заголовок Accept-Language: {Header}", acceptLanguage);

            if (!string.IsNullOrEmpty(acceptLanguage))
            {
                // Разбиваем значение заголовка Accept-Language на список культур
                var cultures = acceptLanguage.Split(',');
                if (cultures.Length > 0)
                {
                    // Проверяем, является ли первая культура из списка допустимой
                    if (IsCultureValid(cultures[0]))
                    {
                        // Если культура допустима, возвращаем её
                        return new CultureInfo(cultures[0]);
                    }
                }
            }

            // Если ни параметр, ни заголовок не заданы или недействительны, возвращаем культуру по умолчанию "ru"
            _logger.LogWarning("Установлена культура по умолчанию 'ru'");
            return new CultureInfo("ru");
        }

        // Метод для проверки, является ли указанная культура допустимой
        private bool IsCultureValid(string cultureName)
        {
            try
            {
                // Пытаемся создать объект CultureInfo для указанной культуры
                CultureInfo.GetCultureInfo(cultureName);
                return true; // Если успешно, возвращаем true
            }
            catch (CultureNotFoundException)
            {
                // Если культура недопустима, возвращаем false
                return false;
            }
        }
    }
}
