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
    public class HomePage : BaseCarsPage
    {
        public HomePage() : base(By.XPath("//a[@data-linkname='header-home']"), "Home Page") { }


    }
}
