using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace FrameworkDemo.framework.browser
{
    public class BrowserFactory
    {
        //static string driverPath = System.IO.Path.GetFullPath("./resources");

        public static IWebDriver SetupBrowser(string browser)
        {
            if (browser.ToLower().Equals("firefox"))
            {
                return SetupFirefox();
            }

            return SetupChrome();
        }

        static IWebDriver SetupFirefox()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig(), "Latest", Architecture.X64);
            //return new FirefoxDriver(driverPath);
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.SetPreference("browser.download.dir", System.IO.Path.GetFullPath(ConfigurationReader.GetValue("DownloadPath")));
            firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream doc xls pdf txt");
            firefoxOptions.SetPreference("browser.download.folderList", 2);
            return new FirefoxDriver(firefoxOptions);
            
            
        }

        static IWebDriver SetupChrome()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
            chromeOptions.AddUserProfilePreference("download.default_directory", System.IO.Path.GetFullPath(ConfigurationReader.GetValue("DownloadPath")));
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", "false");

            //return new ChromeDriver(driverPath, chromeOptions);
            return new ChromeDriver(chromeOptions);


        }

    }
}
