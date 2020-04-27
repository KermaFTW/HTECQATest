using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;

namespace HTECQATest
{
    public static class Browser
    {
        static ChromeOptions options = new ChromeOptions();
        static IWebDriver webDriver = new ChromeDriver(".\\", addChromeOption(), TimeSpan.FromSeconds(180));

        static ChromeOptions addChromeOption()
        {
            return options;
        }

        public static IWebDriver Driver
        {
            get
            {
                return webDriver;
            }
        }
        internal static void GoTo(string url)
        {
            webDriver.Url = url;
            webDriver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        }

        public static void Close()
        {
            webDriver.Quit();
        }

        public static void Wait(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitInSec(int seconds)
        {
            Task.Delay(seconds * 1000).Wait();
        }

        public static string CountChar(IWebElement element)
        {
            string elementText = element.GetAttribute("value");
            int noOfCharacters = elementText.Length;
            string text = "This field previously had " + noOfCharacters + " characters";
            return text;
        }
    }
}