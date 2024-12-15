# Relay Project

## Описание
Relay использует **ASP.NET Core** и **Abp Framework** для создания веб-приложений с поддержкой многопользовательского режима (аналог Discord), аутентификации и авторизации. 
Этот проект использует **PostgreSQL** в качестве базы данных и **SignalR** для работы с WebSocket.

## Установка и запуск

### 1. Установите необходимые инструменты
Убедитесь, что на вашем компьютере установлены следующие инструменты:
- [**.NET SDK 9.0**](https://dotnet.microsoft.com/download/dotnet)
- [**PostgreSQL**](https://www.postgresql.org/download/)
- [**Visual Studio**](https://visualstudio.microsoft.com/) или любой другой редактор для работы с .NET.

### 2. Настройка PostgreSQL

1. Убедитесь, что **PostgreSQL** запущен на вашем компьютере. Вы можете скачать и установить его с официального сайта [PostgreSQL](https://www.postgresql.org/download/).
2. Откройте PostgreSQL и создайте новую базу данных:
   ```bash
   psql -U postgres -h 127.0.0.1 -p 5433 -d relay
Убедитесь, что база данных создана:
   ```bash
   \dt
   ```
3. Настройка строки подключения
   В файле appsettings.json проверьте строку подключения:

```json
"ConnectionStrings": {
"Default": "User ID=postgres;Password=example_pwd;Host=127.0.0.1;Port=5433;Database=relay;Pooling=true;"
}
```
Если вы меняете порт или другие параметры подключения, не забудьте обновить строку подключения и пароль в соответствующих файлах.

4. Применение миграций
   Перейдите в директорию проекта и выполните команду для применения миграций:
   ```bash
   dotnet ef database update --project C:\path\to\your\project\DataBaseService\DataBaseService.csproj --context RelayDbContext --connection "User ID=postgres;Password=example_pwd;Host=127.0.0.1;Port=5433;Database=relay;Pooling=true;"
   ```
5. Запуск приложения
   После того как все миграции будут применены и база данных настроена, вы можете запустить сервер:
   ```bash
   dotnet run --project C:\path\to\your\project\ServerWeb\ServerWeb.csproj
   ```

   ServerWeb\ServerWeb.csproj - это исполняемый файл.   

6. Проверка работы приложения
   Откройте браузер и перейдите по адресу:

   ```bash
   https://localhost:44311/
   ```

Если вы настроили Swagger, вы сможете увидеть доступные API эндпоинты на странице:

   ```bash
   Копировать код
   https://localhost:44311/swagger/
   ```

Тестируйте API и взаимодействие с базой данных через Postman или другие инструменты для тестирования HTTP-запросов.

### 3. Проблемы и их решения

#### Ошибка ConnectionString property has not been initialized:

Проблема заключалась в том, что строка подключения не была передана в DbContext. 
Мы исправили это, указав строку подключения в конфигурации и проверив её в коде.

#### Ошибки миграции:

После обновления зависимостей и правильной настройки строки подключения миграции были успешно применены.

#### Ошибка с несовместимостью версий:

Мы обновили dotnet-ef и другие зависимости до актуальных версий, что решило проблемы с миграциями.
