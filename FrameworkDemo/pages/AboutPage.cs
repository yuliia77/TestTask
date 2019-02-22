using FrameworkDemo.framework;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDemo.pages
{
    public class AboutPage : BasePage
    {
        Button btnInstallSteamNow = new Button(By.XPath("//*[@id='about_header_area']//a[@class='about_install_steam_link']"), "Install Steam Now");

        public AboutPage() : base(By.Id("about_monitor_video_gradient"), "About Page") { }

        public void ClickInstallSteamNow()
        {
            btnInstallSteamNow.Click();
        }
    }
}
