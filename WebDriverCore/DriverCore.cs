using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WebDriverCore
{
    public class DriverCore
    {

        public ChromeDriverService Service { get; set; }
        public ChromeOptions Options { get; set; }


        public void GetWebDriver()
        {
            ChromeConfig config = new ChromeConfig();
            new DriverManager().SetUpDriver(config, VersionResolveStrategy.MatchingBrowser, Architecture.X32);

            string appPath = AppDomain.CurrentDomain.BaseDirectory;      //buraya bak
            string vers = config.GetMatchingBrowserVersion();
            string path = appPath + string.Format(@"\Chrome\{0}\X32", vers);
            var options = new ChromeOptions();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(path);


            //options.AddArgument("--window-position=-1000,-1000");
            options.AddArgument("allow-file-access-from-files");
            options.AddArgument("use-fake-device-for-media-stream");
            options.AddArgument("use-fake-ui-for-media-stream");

            service.HideCommandPromptWindow = true; // Hide Chrome Driver
            service.SuppressInitialDiagnosticInformation = true;

            Service = service;
            Options = options;
            
            
            
        }

        public string GetId(WebElement element)
        {
            return ((WebElement)element).Coordinates.AuxiliaryLocator.ToString();
        }

    }
}
