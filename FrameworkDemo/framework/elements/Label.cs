using System;
using System.Collections.Generic;
using FrameworkDemo.framework.browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkDemo.framework.elements
{
    public class Label : BaseElement
    {
        public Label(By locator, string name) : base(locator, string.Format("\"{0}\" label", name))
        {
        }

        public string GetText()
        {
            Logger.Info(string.Format("Get text from \"{0}\"", name));
            return WaitForElementIsPresent().Text;
        }

        public List<string> GetAllElementsText()
        {
            Logger.Info(string.Format("Get text from all elements \"{0}\"", name));
            IReadOnlyCollection<IWebElement> elements = Browser.GetInstance().GetDriver().FindElements(locator);
            List<string> texts = new List<string>();
            foreach (IWebElement element in elements)
            {
                texts.Add(element.Text);
            }
            return texts;
        }

        public int GetIndex(string element)
        {
            Logger.Info(string.Format("Get index of \"{0}\"", name));
            IReadOnlyCollection<IWebElement> elements = Browser.GetInstance().GetDriver().FindElements(locator);
            List<string> texts = new List<string>();
            foreach (IWebElement el in elements)
            {
                texts.Add(el.Text);
            }
            return texts.IndexOf(element);
        }

        public string GetTextByIndex(int index)
        {
            Logger.Info(string.Format("Get text from \"{0}\" by index \"{1}\"", name, index));
            IReadOnlyCollection<IWebElement> elements = Browser.GetInstance().GetDriver().FindElements(locator);
            List<string> texts = new List<string>();
            foreach (IWebElement el in elements)
            {
                texts.Add(el.Text);
            }
            return texts[index];
        }

        public List<string> GetAllElements()
        {
            Logger.Info(string.Format("Get all elements from \"{0}\"", name));
            IReadOnlyCollection<IWebElement> elements = Browser.GetInstance().GetDriver().FindElements(locator);
            List<string> texts = new List<string>();
            foreach (IWebElement element in elements)
            {
                texts.Add(element.ToString());
            }
            return texts;
        }


        }
    }
