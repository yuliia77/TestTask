using System;
using FrameworkDemo.framework.browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkDemo.framework.elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator, string name) : base(locator, string.Format("\"{0}\" textbox", name))
        {
        }

        public void SetText(string text)
        {
            WaitForElementIsPresent().Clear();
            Logger.Info(string.Format("Type \"{0}\" text in \"{1}\"", text, name));
            WaitForElementIsPresent().SendKeys(text);
        }
    }
}
