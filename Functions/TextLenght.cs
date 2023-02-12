using HW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HW.Functions
{
    public class TextLenght : ITextLenght
    {
        public string GetResoult(Message message)
        {
            int textLenght = message.Text.Length;
            return textLenght.ToString();
        }

    }
}
