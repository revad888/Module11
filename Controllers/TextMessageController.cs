using HW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using HW.Services;
using HW.Functions;
using Microsoft.VisualBasic;
using System.Threading;

namespace HW.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly ITextLenght _textLenght;
        private readonly INumberSum _numSum;
        private readonly IStorage _comandHistory;


        public TextMessageController(ITelegramBotClient telegramClient,IStorage comandhistory, ITextLenght textLenght, INumberSum numSum)
        {
            _telegramClient = telegramClient;
            _textLenght = textLenght;
            _numSum = numSum;
            _comandHistory = comandhistory;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            var mes = message.Text;
            string comand = _comandHistory.GetComand(message.Chat.Id).Comand;
            if (message.Text != null)
            {
                switch (comand)
                {
                    case "/textLenght":
                        string textL = _textLenght.GetResoult(message);
                        await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Длинна сообщения {textL} символов", cancellationToken: ct);
                        _comandHistory.GetComand(message.Chat.Id).Comand = "default";
                        return;

                    case "/numSum":
                        double numS = _numSum.GetResoult(message);
                        await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Ответ: {numS}", cancellationToken: ct);
                        _comandHistory.GetComand(message.Chat.Id).Comand = "default";
                        return;
                }
            }
            switch (message.Text)
            {
                case "/start":
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($"Длина символов", $"/textLenght"),
                        InlineKeyboardButton.WithCallbackData($"Сумма чисел", $"/numSum")
                    });
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, "Выбирете одну из функций", cancellationToken: ct, replyMarkup: new  InlineKeyboardMarkup(buttons));
                    break;
                    
                default:
                    await _telegramClient.SendTextMessageAsync(message.From.Id, $"Данный тип сообщений не поддерживается. Пожалуйста отправьте текст.", cancellationToken: ct);
                    return;
            }


        }
    }
}
