using HW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HW.Controllers
{
    public class InlineKeyboardController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly IStorage _comandHistory;

        public InlineKeyboardController (ITelegramBotClient telegramClient, IStorage comandHistory)
        {
            _telegramClient = telegramClient;
            _comandHistory = comandHistory;
        }

        public async Task Handle (CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == "/textLenght")
            {
                await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, "Пришлите текст, длинну которого нужно посчитать.", cancellationToken: ct);
            }
            if (callbackQuery?.Data == "/numSum")
            {
                await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, "Выбрана функция подсчета суммы чисел.\nВведите числа через пробел.", cancellationToken: ct);
            }
            if (callbackQuery?.Data== null)
                return;

            _comandHistory.GetComand(callbackQuery.From.Id).Comand = callbackQuery.Data;

            string actionTyppe = callbackQuery.Data switch
            {
                "/textLenght" => "подсчета количества символов в тексте.\nВведите текст.",
                "/numSum" => "подсчета суммы чиселю.\nВведите числа чеерез пробел.",
                _ => String.Empty
            };
            
            
        }
    }
}
