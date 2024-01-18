# Email Service
Инструмент предоставляет удобный и эффективный способ отправки персонализированных сообщений пользователям.

# Запуск
## Docker Support
1. Изменить appsettings.json. Строку подключения к базе даненых, а так же настройку SMPT сервера.
2. Зайти в корневую папку проекта и написать следующие команды.
   ~~~
   1. docker compose build 
   2. docker compose up
   ~~~
3. Миграция базы данных произойдёте автоматически при первом запуске приложения.
4. Если не была изменена переменная "ASPNETCORE_ENVIRONMENT=Development" в файле dockercompos.yml, то можно протестировать приложение при помощи Swagger

## Локально
1. Установить зависимости PostgreSQL и .NET 8+.
2. Изменить appsettings.json. Строку подключения к базе даненых, а так же настройку SMPT сервера.
3. Запустить приложения.
4. Миграция базы данных произойдёте автоматически при первом запуске приложения.

# Технологии

- .NET 8
- ASP .NET Core Web API
- PostgreSQL

## Библиотеки

- Entity Framework
- Npgsql.EntityFrameworkCore.PostgreSQL
- FluentValidation 
- MailKit
- MimeKit

# Endpoints
~~~
POST /api/mails
{
  "subject": "Сбор на митинг",
  "body": "Всех ждем в 10:00 20.01.2024 для обсуждения важных дел",
  "recipients": [
    "dev@gmail.com", "nickper@mail.com", "jackli@yandex.ru"
  ]
}

GET /api/mails

Response: 
[
  {
    "messageId": "57a3ee22-a01d-495f-a97d-04e210b719d9",
    "sendedLogs": [
      {
        "logId": "dbcb320b-ee06-4a96-9aa7-9b49ca09f1b1",
        "email": "dev@gmail.com",
        "createdDate": "2024-01-18T17:35:40.782032Z",
        "result": "OK",
        "failedMessage": ""
      },
      {
        "logId": "0fedcfe5-c94f-4fd1-922e-f37fa103c289",
        "email": "jackli@yandex.ru",
        "createdDate": "2024-01-18T17:35:40.283812Z",
        "result": "OK",
        "failedMessage": ""
      },
      {
        "logId": "3cf3821b-9682-4b9d-8cef-bd16eba8c87f",
        "email": "nickper@mail.com",
        "createdDate": "2024-01-18T17:35:42.183534Z",
        "result": "OK",
        "failedMessage": ""
      }
    ]
]
~~~

# Тестирование
> Тестирование проводилось при помощи сайта https://ethereal.email/.
> ![image](https://github.com/Denis-A1zek/EmailService/assets/130150382/2bdbcece-9d72-4247-85bd-c1447492f22d). 



 
