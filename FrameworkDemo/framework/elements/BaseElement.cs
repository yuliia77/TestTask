using System;
using FrameworkDemo.framework.browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FrameworkDemo.framework.elements
{
    public class BaseElement
    {

        protected By locator;
        protected string name;

        protected BaseElement(By locator, string name)
        {
            this.locator = locator;
            this.name = name;
        }

        public void Click()
        {
            Logger.Info(string.Format("Click on \"{0}\"", name));
            WebDriverWait wait = Browser.GetInstance().GetWait();
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }

        public void MoveToElement()
        {
            Logger.Info(string.Format("Move to \"{0}\"", name));
            WebDriverWait wait = Browser.GetInstance().GetWait();
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            Actions action = new Actions(Browser.GetInstance().GetDriver());
            action.MoveToElement(element).Build().Perform();
        }

        public IWebElement WaitForElementIsPresent()
        {
            return Browser.GetInstance().GetWait().Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void ClickJS()
        {
            Logger.Info(string.Format("Click on \"{0}\"", name));
            WebDriverWait wait = Browser.GetInstance().GetWait();
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(locator));
            ((IJavaScriptExecutor) Browser.GetInstance().GetDriver()).ExecuteScript("arguments[0].click()", element);
        }
    }
}
