using HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Services
{
    public interface IStorage
    {
        Session GetComand(long chatId);
    }
}
