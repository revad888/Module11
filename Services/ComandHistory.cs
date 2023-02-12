using HW.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW.Models;

namespace HW.Services
{
    public class ComandHistory : IStorage
    {
        private readonly ConcurrentDictionary<long, Session> _sessions;

        public ComandHistory()
        {
            _sessions = new ConcurrentDictionary<long, Session>();
        }

        public Session GetComand(long chatId)
        {
            if (_sessions.ContainsKey(chatId))
                return _sessions[chatId];

            var newSessin = new Session() { Comand = "/default" };
            _sessions.TryAdd(chatId, newSessin);
            return newSessin;
        }
    }
}
