using FrameworkDemo.framework;
using FrameworkDemo.framework.browser;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkDemo.pages
{
    public class ResearchPage : BasePage
    {
        Button btnSearch = new Button(By.XPath("//*[@class='_3fqWH']//input"), "Search");
        string drd = "//select[contains(@name, '{0}')]";
        Label lblCompareCars = new Label(By.XPath("//a[@data-linkname='compare-cars']"), "Compare Side-by-Side");

        public ResearchPage() : base("Research", "Research Page") { }


        public void SelectOptionByRandomIndexInDrd(string drdName)
        {
            new DropDownList(By.XPath(string.Format(drd, drdName)), drdName).SelectByRandomIndex();
        }

        public string GetSelectedOptionsText(string drdName)
        {
            return new DropDownList(By.XPath(string.Format(drd, drdName)), drdName).GetSelectedOptionText();
        }

        public void ClearSelectedOption(string drdName)
        {
            new DropDownList(By.XPath(string.Format(drd, drdName)), drdName).ClearSelectedValue();
        }
    
        public void ClickSearch()
        {
            btnSearch.Click();
        }

        public void ClickCompareCars()
        {
            lblCompareCars.Click();
        
        }


    }
}
