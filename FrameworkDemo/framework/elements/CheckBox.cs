using FrameworkDemo.framework.browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDemo.framework.elements
{
    class CheckBox : BaseElement
    {
        public CheckBox(By locator, string name) : base(locator, string.Format("\"{0}\" checkbox", name))
        {
        }

        public bool IsChecked()
        {
            Logger.Info(string.Format("Get state of the checkbox \"{0}\"", name));
            return WaitForElementIsPresent().Selected;
        }

        public void CheckAll(bool state)
        {
            Logger.Info(string.Format("Check all unchecked checkboxes if true or uncheck all checked if false for \"{0}\"", name));
            IReadOnlyCollection<IWebElement> checkboxes = Browser.GetInstance().GetDriver().FindElements(locator);
            foreach (IWebElement checkbox in checkboxes)
            {
                if (!state && checkbox.Selected)
                {
                    checkbox.Click();
                }
                else if (state && !checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }

        public void Check(bool state)
        {
            if (!state && WaitForElementIsPresent().Selected)
            {
                Logger.Info(string.Format("Uncheck the checked checkbox \"{0}\"", name));
                WaitForElementIsPresent().Click();
            }
            else if (state && !WaitForElementIsPresent().Selected)
            {
                Logger.Info(string.Format("Check the unchecked checkbox \"{0}\"", name));
                WaitForElementIsPresent().Click();
            }
        }
    }
}
