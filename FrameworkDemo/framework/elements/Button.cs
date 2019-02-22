using System;
using OpenQA.Selenium;

namespace FrameworkDemo.framework.elements
{
    public class Button : BaseElement
    {
        public Button(By locator, string name) : base(locator, string.Format("\"{0}\" button", name))
        {
        }
    }
}
