using ChatBot.Entities.Abstract;
using ChatBot.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace DataAccessTest
{
    [TestClass]
    public class UnitTest1
    {
        RemoteWebDriver _driver ;

        private RemoteWebDriver _myDriver;

        [TestMethod]       
        public void SetUp() 
        {

            ChromeConfig config = new ChromeConfig();
            new DriverManager().SetUpDriver(config, VersionResolveStrategy.MatchingBrowser, Architecture.X32);

            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string vers = config.GetMatchingBrowserVersion();
            string path = appPath + string.Format(@"\Chrome\{0}\X32", vers);

            _myDriver = new ChromeDriver(path);
        }

        [TestMethod]
        public void deneme2()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.google.com");

        }


        [TestMethod]
        public void deneme()
        {
            SetUp();
            _myDriver.Navigate().GoToUrl("https://www.google.com");
        }


        public void GetReady(string url)
        {
            _driver.Url = url;
            Thread.Sleep(5000);
            var input = _driver.FindElementByCssSelector("#guest-name");
            input.Click();
            Thread.Sleep(300);
            input.SendKeys("chat bot");
            Thread.Sleep(1000);
            _driver.FindElementByCssSelector("#launch-html-guest").Click();
            Thread.Sleep(8000);
            _driver.FindElementByCssSelector("#techcheck-modal > button").Click();
            Thread.Sleep(5000);
            _driver.FindElementByCssSelector("#announcement-modal-page-wrap > button").Click();
            Thread.Sleep(500);
            _driver.FindElementByCssSelector("#side-panel-open").Click();
            Thread.Sleep(1000);
            _driver.FindElementByCssSelector("#chat-channel-scroll-content > ul > li > ul > li").Click();
            Thread.Sleep(1000);
        }
        public IMessage GetValue()
        {
            var parentElement = _driver.FindElementById("chat-channel-history");
            var elementList = parentElement.FindElements(By.XPath("//*[@id='chat-channel-history']/li[last()]"));
            IMessage message = Message.MessageHandle();
            var elementId = parentElement.FindElements(By.XPath(".//*")).Count;
            foreach (var element in elementList)
            {

                string text = element.GetAttribute("innerText");
                var resultnew = Regex.Split(text, "\r\n\r\n");




                if (resultnew.Length == 3)
                {
                    message.Name = resultnew[0];
                    message.Hour = resultnew[1];
                    message.Title = resultnew[2];
                    message.Id = elementId;
                    Console.WriteLine("{0} : {1} - {2}", message.Name, message.Title, message.Hour);
                }
                else
                {
                    message.Name = "";
                    message.Hour = resultnew[0];
                    message.Title = resultnew[1];
                    message.Id = elementId;
                    Console.WriteLine("      {0} - {1} ", message.Title, message.Hour);
                }





            }

            return message;
        }

        [TestMethod]
        public void getUserList()
        {
            GetReady("https://eu.bbcollab.com/guest/eabba7b5af384c09835a336b05cba311");
            
        }

        [TestMethod]
        public void GetValueReturnsAValue()
        {

            //IMessage message = Message.MessageHandle();
            //while (true)
            //{
            //    message = GetValue();
            //    Console.WriteLine("{0} - {1} - {2}", message.Name, message.Title, message.Hour);
            //    Thread.Sleep(2000);
            //}
            _driver.Url = "https://eu.bbcollab.com/guest/eabba7b5af384c09835a336b05cba311";
            Thread.Sleep(5000);
            var input = _driver.FindElementByCssSelector("#guest-name");
            input.Click();
            Thread.Sleep(300);
            input.SendKeys("chat bot");
            Thread.Sleep(1000);
            _driver.FindElementByCssSelector("#launch-html-guest").Click();
            Thread.Sleep(8000);
            _driver.FindElementByCssSelector("#techcheck-modal > button").Click();
            Thread.Sleep(5000);
            _driver.FindElementByCssSelector("#announcement-modal-page-wrap > button").Click();
            Thread.Sleep(500);
            _driver.FindElementByCssSelector("#side-panel-open").Click();
            Thread.Sleep(1000);
            _driver.FindElementByCssSelector("#chat-channel-scroll-content > ul > li > ul > li").Click();
            Thread.Sleep(1000);
            var parentElement = _driver.FindElementById("chat-channel-history");
            var elementList = parentElement.FindElements(By.XPath("//*[@id='chat-channel-history']/li[last()]"));
            IMessage message = Message.MessageHandle();
            var elementId = parentElement.FindElements(By.XPath(".//*")).Count;
            foreach (var element in elementList)
            {

                string text = element.GetAttribute("innerText");
                var resultnew = Regex.Split(text, "\r\n\r\n");




                if (resultnew.Length == 3)
                {
                    message.Name = resultnew[0];
                    message.Hour = resultnew[1];
                    message.Title = resultnew[2];
                    message.Id = elementId;
                    Console.WriteLine("{0} : {1} - {2}", message.Name, message.Title, message.Hour);
                }
                else
                {
                    message.Name = "";
                    message.Hour = resultnew[0];
                    message.Title = resultnew[1];
                    message.Id = elementId;
                    Console.WriteLine("      {0} - {1} ", message.Title, message.Hour);
                }





            }

            Assert.IsNotNull(message);

        }
    }
}
