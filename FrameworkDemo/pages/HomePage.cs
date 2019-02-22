using System;
using System.Collections.Generic;
using FrameworkDemo.framework;
using FrameworkDemo.framework.browser;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FrameworkDemo.pages
{
    public class HomePage : BasePage
    {
        string lblMenuItemLocator = "//*[@class='pulldown_desktop'][text()='{0}']";
        string lblMenuSubItemLocator = "//div[@class='store_nav']//*[contains(@class, 'focus')]/following-sibling::div[1]//a[normalize-space(text()) = '{0}']";

        public HomePage() : base(By.XPath("//*[contains(@class, 'home_cluster_ctn')]"), "Home Page") { }

        public void NavigateToMenuItem(string category, string subcategory)
        {
            new Label(By.XPath(string.Format(lblMenuItemLocator, category)), category).MoveToElement();
            new Label(By.XPath(string.Format(lblMenuSubItemLocator, subcategory)), subcategory).ClickJS();
        }



    }
}
