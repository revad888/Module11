using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HW.Controllers
{
    public class DefaultMessageController
    {
        private readonly ITelegramBotClient _telegramClient;

        public DefaultMessageController(ITelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            Console.WriteLine($"Для сообщений типа {message.Type} нет обработчика");
            await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Сообщения выбранного типа не поддерживаются. Отправьте текст", cancellationToken: ct);
        }
    }
}
