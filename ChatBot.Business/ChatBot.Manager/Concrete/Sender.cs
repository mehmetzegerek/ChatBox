using ChatBot.Business.ChatBot.Manager.Abstract;
using ChatBot.DataAccess.Concrete;
using ChatBot.Entities.Abstract;
using ChatBot.Entities.Concrete;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace ChatBot.Business.ChatBot.Manager.Concrete
{
    public class Sender : SenderManager
    {
        Access _access = new Access();
        List<Student> students = new List<Student>();
        List<string> images = new List<string>() 
        {"./Icons/Avatars/avatar1.png","./Icons/Avatars/avatar2.png","./Icons/Avatars/avatar3.png","./Icons/Avatars/avatar4.png","./Icons/Avatars/avatar5.png","./Icons/Avatars/avatar6.png","./Icons/Avatars/avatar7.png","/Icons/Avatars/avatar8.png"
        ,"./Icons/Avatars/avatar9.png","./Icons/Avatars/avatar10.png","./Icons/Avatars/avatar11.png","./Icons/Avatars/avatar12.png"};
        List<string> colors = new List<string>() 
        {"#7289DA","#99AAB5","#7D6B7D","#FF8C64","#FF665A","#506AD4","#BAB7AC","#EAAD39","#936CE6","#3EB595","#D30BDE","#BF9F93"};
        Random random = new Random();


        public override void BrowserReady(string url,int delay)
        {
            _access.GetDriver();
            _access.GetReady(url,delay);
        }

        public void TakeScreenShot()
        {
            _access.TakeScreenShot();
        }

        string lastName = "";
        Student stdn = new Student();
        //int Id = 0;
        public override IStudent GetData()
        {
            var message = _access.GetResult();

            
            if (message.Id != 0)
            {
                stdn = students.Find(o => o.Username == message.Name);
                if (message.Name != "" && message.Name != null)
                {
                    if (!students.Any(student => student.Username == message.Name))
                    {
                        students.Add(new Student { Username = message.Name, UsernameColor = colors[random.Next(colors.Count)], ImageSource = images[random.Next(images.Count)] });
                        stdn = students.Find(o => o.Username == message.Name);
                    }

                    stdn.Message = message.Title;
                    stdn.Time = DateTime.Now;
                    stdn.Id = message.Id;
                    stdn.FirstMessage = true;

                    //Id = message.Id;
                    lastName = stdn.Username;


                }
                else if (message.Name == "")
                {
                    stdn = students.FirstOrDefault(o => o.Username == lastName);
                    stdn.Message = message.Title;
                    stdn.Time = DateTime.Now;
                    stdn.FirstMessage = false;
                    //Id = message.Id;
                }
                return stdn;
            }
            else
            {
                stdn = null;
            }
            
            
                
            

                

            
            return stdn;

        }


        
                
      

        public override void IsDone()
        {
            _access.Done();
        }

        public override void SendMessage(string message)
        {
            _access.SendMessage(message);
        }
    }
}
