using FrameworkDemo.framework.browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDemo.framework.elements
{
    class DropDownList : BaseElement
    {
        public DropDownList (By locator, string name) : base(locator, string.Format("\"{0}\" dropdown", name))
        {
        }

        public void SelectByText(string text)
        {
            Logger.Info(string.Format("Select \"{0}\" in \"{1}\"", text, name));
            new SelectElement(WaitForElementIsPresent()).SelectByText(text);
        }

        public string GetText()
        {
            Logger.Info(string.Format("Get text in \"{0}\"", name));
            return WaitForElementIsPresent().Text;
        }

        public string GetSelectedOptionText()
        {
            Logger.Info(string.Format("Get selected option text in \"{0}\"", name));
            SelectElement list = new SelectElement(WaitForElementIsPresent());
            return list.SelectedOption.Text;
        }

        public void SelectByRandomIndex()
        {
            Logger.Info(string.Format("Select random option in \"{0}\"", name));
            Random rnd = new Random();
            SelectElement list = new SelectElement(WaitForElementIsPresent());
            int optionsCount = list.Options.Count;
            int rndOption = rnd.Next(1, optionsCount);
            list.SelectByIndex(rndOption);
        }

        public void ClearSelectedValue()
        {
            Logger.Info(string.Format("Clear selected option in \"{0}\"", name));
            SelectElement list = new SelectElement(WaitForElementIsPresent());
            list.SelectByValue("0");
        }



    }


}
