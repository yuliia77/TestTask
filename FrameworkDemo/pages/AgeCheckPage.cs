using FrameworkDemo.framework;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDemo.pages
{
    public class AgeCheckPage : BasePage
    {
        Button btnViewPage = new Button(By.XPath("//a[@onclick='ViewProductPage()']"), "View Page");
        DropDownList drdAgeDay = new DropDownList(By.CssSelector("select#ageDay"), "Age Day");
        DropDownList drdAgeMonth = new DropDownList(By.CssSelector("select#ageMonth"), "Age Month");
        DropDownList drdAgeYear = new DropDownList(By.CssSelector("select#ageYear"), "Age Year");

        public AgeCheckPage() : base(By.ClassName("agegate_birthday_selector"), "Age Check Page") { }

        public void SelectDateMonthYear(string day, string month, string year)
        {
            drdAgeDay.SelectByText(day);
            drdAgeMonth.SelectByText(month);
            drdAgeYear.SelectByText(year);
        }

        public void ClickViewPage()
        {
            btnViewPage.Click();
        }

    }
}
