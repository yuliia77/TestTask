using FrameworkDemo.framework.browser;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDemo.framework
{
    public class BasePage
    {
        private string name;
        private By locator;
        private string pageTitle;

        protected BasePage(By locator, string name)
        {
            this.name = name;
            this.locator = locator;
            AssertIsPresent();
        }

        protected BasePage(string pageTitle, string name)
        {
            this.name = name;
            this.pageTitle = pageTitle;
            AssertTitleIsPresent(this.pageTitle);
        }

        public void AssertIsPresent()
        {
            Logger.Info(string.Format("\"{0}\" is found", name));
            new Label(locator, name).WaitForElementIsPresent();
        }

        public void AssertTitleIsPresent(string pageTitle)
        {
            Logger.Info(string.Format("Page that contains \"{0}\" title is found", pageTitle));
            Browser.GetInstance().GetWait().Until(ExpectedConditions.TitleContains(pageTitle));
        }

        
    }
}
