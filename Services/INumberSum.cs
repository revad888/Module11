﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace HW.Services
{
    public interface INumberSum
    {
        public double GetResoult(Message message);
    }
}
