using ChatBot.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Entities.Concrete
{
    public class Message : IMessage
    {
        private static IMessage _message;
        private Message()
        {

        }
        public static IMessage MessageHandle()
        {
            if (_message == null)
            {
                _message = new Message();
            }
            return _message;


        }
        public int Id { get; set; }
        public string Name { get ; set; }
        public string Hour { get; set; }
        public string Title { get; set; }
        public string ElementID { get; set; }
    }
}
