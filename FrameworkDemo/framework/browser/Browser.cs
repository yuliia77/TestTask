using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkDemo.framework.browser
{
    public class Browser
    {
        static Browser browser;

        static IWebDriver driver;

        static WebDriverWait wait;

        Browser()
        {
            Logger.Info(string.Format("Start \"{0}\" browser", ConfigurationReader.GetValue("Browser")));
            driver = BrowserFactory.SetupBrowser(ConfigurationReader.GetValue("Browser"));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(int.Parse(ConfigurationReader.GetValue("WaitingTimeout"))));
        }

        public static Browser GetInstance()
        {
            if (browser == null)
            {
                browser = new Browser();
            }
            return browser;
        }

        public void OpenURL(string url)
        {
            Logger.Info(string.Format("Navigate to \"{0}\"", url));
            driver.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            Logger.Info(string.Format("Close \"{0}\" browser", ConfigurationReader.GetValue("Browser")));
            driver.Quit();
            browser = null;
            driver = null;
        }

        public void Maximize()
        {
            Logger.Info(string.Format("Maximize \"{0}\" browser", ConfigurationReader.GetValue("Browser")));
            driver.Manage().Window.Maximize();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public WebDriverWait GetWait()
        {
            return wait;
        }
    }
}
