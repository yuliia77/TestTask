using FrameworkDemo.framework;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkDemo.pages
{
    public class TopMenu
    {
        string lblMenuItemLocator = "//header/nav/ul//a[text()='{0}']";


        public void ClickOnMenuItem(string item)
        {
            new Label(By.XPath(string.Format(lblMenuItemLocator, item)), item).Click();
        }

    }
}
