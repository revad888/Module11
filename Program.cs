using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HW.Controllers;
using HW.Services;
using HW.Functions;
using HW.Configuration;
using System.Text;

namespace HW
{
    internal class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
                .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
                .Build(); // Собираем

            Console.WriteLine("Сервис запущен");
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");

        }

        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            // Подключаем контроллеры сообщений и кнопок
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddSingleton<InlineKeyboardController>();
            services.AddSingleton<ITextLenght, TextLenght>();
            services.AddSingleton<INumberSum, NumberSum>();
            services.AddSingleton<IStorage, ComandHistory>();
            //services.AddSingleton<IStorage, MemoryStorage>();

            // Регистрируем объект TelegramBotClient c токеном подключения
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));
            // Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
        }

        // Обьект конфигурации
        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                BotToken = "6100696763:AAFvS9dSSD9HvX-Wy08OtIh42mMZhWFvpkk"
            };
        }
    }
}