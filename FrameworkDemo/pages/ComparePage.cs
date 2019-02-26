using FrameworkDemo.Entities;
using FrameworkDemo.framework;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDemo.pages
{
    public class ComparePage : BaseCarsPage
    {
        DropDownList drdMake = new DropDownList(By.CssSelector("select#make-dropdown"), "Make");
        DropDownList drdModel = new DropDownList(By.CssSelector("select#model-dropdown"), "Model");
        DropDownList drdYear = new DropDownList(By.CssSelector("select#year-dropdown"), "Year");
        Button btnStartComparing = new Button(By.XPath("//button[@class='done-button']"), "Start Comparing");

        public ComparePage() : base("Compare Cars Side-by-Side", "Trims Page") { }


        public void SelectMakeModelYearByText(string make, string model, string year)
        {
            drdMake.SelectByText(make);
            drdModel.SelectByText(model);
            drdYear.SelectByText(year);
        }

        public void ClickStartComparing()
        {
            btnStartComparing.Click();
        }

        public void SelectCar(Car car)
        {
            SelectMakeModelYearByText(car.Make, car.Model, car.Year);
        }
    }

    
}
