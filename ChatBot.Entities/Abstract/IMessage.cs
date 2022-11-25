using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Entities.Abstract
{
    public interface IMessage
    {
        int Id { get; set; }
        string Name { get; set; }
        string Hour { get; set; }
        string Title { get; set; }
        string ElementID { get; set; }
    }
}
