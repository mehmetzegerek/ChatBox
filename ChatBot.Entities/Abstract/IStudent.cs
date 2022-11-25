using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Entities.Abstract
{
    public interface IStudent
    {
        string Username { get; set; }
        string UsernameColor { get; set; }
        string ImageSource { get; set; }
        string Message { get; set; }
        DateTime Time { get; set; }
        bool IsNativeOrigin { get; set; }
        bool? FirstMessage { get; set; }
        int Id { get; set; }

    }
}
