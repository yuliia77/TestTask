using FrameworkDemo.framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDemo.pages
{
    public class BaseCarsPage : BasePage
    {
        public TopMenu topMenu = new TopMenu();

        protected BaseCarsPage(By locator, string name) : base(locator, name)
        {
            
        }

        protected BaseCarsPage(string pageTitle, string name) : base(pageTitle, name)
        {
        }
    }
}
