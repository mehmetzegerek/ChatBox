using ChatBot.Entities.Abstract;
using ChatBot.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Business.ChatBot.Manager.Abstract
{
    public abstract class  SenderManager
    {
       
        public abstract IStudent GetData();
        public abstract void BrowserReady(string url,int delay);
        public abstract void IsDone();
        public abstract void SendMessage(string message);

    }
}
