using ChatBot.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.DataAccess.Abstract
{
    public interface IAccess
    {
        void GetReady(string url,int delay);
        void Done();
        void SendMessage(string message);
        IMessage GetResult();
        List<string> getUserList();

    }
}
