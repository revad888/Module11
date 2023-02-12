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
    public class NumberSum : INumberSum
    {

        public double GetResoult(Message message)
        {
            Console.WriteLine(message.Text);
            string[] numbers = message.Text.Split(" ");
            double sum = 0;
            foreach (var number in numbers)
            {

                sum += double.Parse(number);

            }
            return sum;
        }
    }
}
