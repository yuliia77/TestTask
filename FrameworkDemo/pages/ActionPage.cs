using FrameworkDemo.framework;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkDemo.pages
{
    public class ActionPage : BasePage
    {
        Button btnSeeAllSpecials = new Button(By.XPath("//a/span[text()='See All Specials']"), "See All Specials");

        public ActionPage() : base(By.XPath("//h2[contains(text(), 'Action')]"), "Action Page") { }

        public void GoToAllSpecials()
        {
            btnSeeAllSpecials.Click();
        }
    }
}
