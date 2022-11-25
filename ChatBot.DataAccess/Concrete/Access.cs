using ChatBot.DataAccess.Abstract;
using ChatBot.Entities.Abstract;
using ChatBot.Entities.Concrete;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WebDriverCore;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;


//using SeleniumExtras.WaitHelpers;

namespace ChatBot.DataAccess.Concrete
{
    public class Access : IAccess
    {
        private ChromeDriver _driver;
        DriverCore driverCore = new DriverCore();
        bool stop = false;
        int locY = 0;
        string id = "";
        List<string> MessageIDList = new List<string>();


        
        public void Done()
        {
            if (_driver != null)
            {
                stop = true;
                Thread.Sleep(300);
                _driver.Quit();
            }
            
        }

        public ChromeDriver GetDriver()
        {
            
            if (_driver == null)
            {
                ChromeConfig config = new ChromeConfig();
                new DriverManager().SetUpDriver(config, VersionResolveStrategy.MatchingBrowser, Architecture.X32);

                string appPath = AppDomain.CurrentDomain.BaseDirectory;      //buraya bak
                string vers = config.GetMatchingBrowserVersion();
                string path = appPath + string.Format(@"\Chrome\{0}\X32", vers);
                var options = new ChromeOptions();
                ChromeDriverService service = ChromeDriverService.CreateDefaultService(path);


                options.AddArgument("--window-position=-1000,-1000");
                options.AddArgument("allow-file-access-from-files");
                options.AddArgument("use-fake-device-for-media-stream");
                options.AddArgument("use-fake-ui-for-media-stream");
                options.AddArgument("mute-audio");

                service.HideCommandPromptWindow = true; // Hide Chrome Driver
                service.SuppressInitialDiagnosticInformation = true;

                
                _driver = new ChromeDriver(service, options);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
               


            }
            return _driver;
        }
        public void TakeScreenShot()
        {
            
        }
        public void GetReady(string url,int delay)
        {
            try
            {
                _driver.Url = url;
                Thread.Sleep(delay);
                //var input = _driver.FindElementByCssSelector("#guest-name");
                var input = _driver.FindElement(By.CssSelector("#guest-name"));
                Thread.Sleep(1000);
                input.Click();
                Thread.Sleep(delay);
                input.SendKeys("chat service");
                Thread.Sleep(delay);
                //_driver.FindElementByCssSelector("#launch-html-guest").Click();
                _driver.FindElement(By.CssSelector("#launch-html-guest")).Click();

                //Thread.Sleep(delay);
                //_driver.FindElementByCssSelector("#techcheck-modal > button").Click();
                Thread.Sleep(delay);
                //_driver.FindElementByCssSelector("#techcheck-modal > div.modal-content-wrap.techcheck-audio-wrapper > div > button").Click();
                _driver.FindElement(By.CssSelector("#techcheck-modal > div.modal-content-wrap.techcheck-audio-wrapper > div > button")).Click();
                Thread.Sleep(delay);
                //_driver.FindElementByCssSelector("#announcement-modal-page-wrap > button").Click();
                _driver.FindElement(By.CssSelector("#announcement-modal-page-wrap > button")).Click();

                Thread.Sleep(delay);
                //_driver.FindElementByCssSelector("#side-panel-open").Click();
                _driver.FindElement(By.CssSelector("#side-panel-open")).Click();

                Thread.Sleep(delay);
                //_driver.FindElementByCssSelector("#chat-channel-scroll-content > ul > li > ul > li").Click();
                _driver.FindElement(By.CssSelector("#chat-channel-scroll-content > ul > li > ul > li")).Click();

                Thread.Sleep(delay);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            }
            catch (WebDriverException)
            {

                throw new Exception("Bağlantı zaman aşımına uğradı lütfen tekrar deneyin");
            }
            
        }
        string elementID = "";
        List<IWebElement> elementList;
        List<IWebElement> LastThree = new List<IWebElement>();

        public IMessage GetResult()
        {
            IMessage message = Message.MessageHandle();
            //Thread.Sleep(100);

            
            if (!stop)
            {

                //var parentElement = _driver.FindElementById("chat-channel-history");
                
                var parentElement = _driver.FindElement(By.Id("chat-channel-history"));
                elementList = parentElement.FindElements(By.XPath("//*[@id='chat-channel-history']/li[last()]")).ToList();

                if (parentElement.FindElements(By.XPath("//*[@id='chat-channel-history']/li")).Count < 3)
                {

                    if (elementList.Count != 0)
                        if (!MessageIDList.Contains(((WebElement)elementList[0]).Coordinates.AuxiliaryLocator.ToString()))
                            MessageIDList.Add(((WebElement)elementList[0]).Coordinates.AuxiliaryLocator.ToString());
                        

                        



                }
                else
                {
                    if (!MessageIDList.Contains(((WebElement)elementList[0]).Coordinates.AuxiliaryLocator.ToString()))
                    {
                        LastThree.Clear();
                        List<IWebElement> AllLi = parentElement.FindElements(By.XPath("//*[@id='chat-channel-history']/li")).ToList();
                        for (int i = AllLi.Count - 3; i < AllLi.Count; i++)
                        {
                            LastThree.Add(AllLi[i]);
                        }
                        elementList.Clear();
                        foreach (var element in LastThree)
                        {
                            if (!MessageIDList.Contains(((WebElement)element).Coordinates.AuxiliaryLocator.ToString()))
                            {
                                MessageIDList.Add(((WebElement)element).Coordinates.AuxiliaryLocator.ToString());
                                elementList.Add(element);
                            }
                        }
                    }
  

                }
                
                

                //IReadOnlyCollection<IWebElement> elementList = parentElement.FindElements(By.XPath("//*[@id='chat-channel-history']/li[last()]"));


                ////*[@id="chat-channel-history"]/li[3]
                //*[@id="chat-channel-history"]

                //var elementId = parentElement.FindElements(By.XPath(".//*")).Count;

                foreach (var element in elementList)
                {
                    id = ((WebElement)element).Coordinates.AuxiliaryLocator.ToString();

                    if (elementID != id)
                    {
                        string text = element.GetAttribute("innerText");
                        var resultnew = Regex.Split(text, "\r\n\r\n");

                        



                        if (resultnew.Length == 3)
                        {
                            message.Name = resultnew[0];
                            message.Hour = resultnew[1];
                            message.Title = resultnew[2];
                            message.Id = 1;
                            message.ElementID = id;

                            Console.WriteLine("{0} : {1} - {2}", message.Name, message.Title, message.Hour);
                        }
                        else
                        {
                            message.Name = "";
                            message.Hour = resultnew[0];
                            message.Title = resultnew[1];
                            message.Id = 1;
                            message.ElementID = id;

                            Console.WriteLine("      {0} - {1} ", message.Title, message.Hour);
                        }
                        locY = element.Location.Y;
                        

                        elementID = id;
                        //liCount = parentElement.FindElements(By.XPath("//*[@id='chat-channel-history']/li")).Count;
                        return message;

                    }
                    else
                    {
                        message.Id = 0;
                    }
                    
                }


            }
            Thread.Sleep(250);

            return message;




        }

        public void SendMessage(string message)
        {
            //var imputSend = _driver.FindElementByCssSelector("#chat-input-container > bb-chat-input-rich-text-editor > div > div > div.quill.rich-text-editor__input > div > div.ql-editor.ql-blank");
            var imputSend = _driver.FindElement(By.CssSelector("#chat-input-container > bb-chat-input-rich-text-editor > div > div > div.quill.rich-text-editor__input > div > div.ql-editor.ql-blank"));

            imputSend.Click();
            Thread.Sleep(300);
            imputSend.SendKeys(message);
            Thread.Sleep(400);
            imputSend.SendKeys(Keys.Enter);
        }

        public List<string> getUserList()
        {
            //var container = _driver.FindElementById("//*[@id='inner-scroll-container']/div/md-virtual-repeat-container/div/div[2]/div[3]");
            return new List<string>();
        }
    }
}
