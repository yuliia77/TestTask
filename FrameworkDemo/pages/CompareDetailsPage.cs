using FrameworkDemo.framework;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkDemo.pages
{
    public class CompareDetailsPage : BaseCarsPage
    {
        public CompareDetailsPage() : base(By.XPath("//h1[@id='main-headline'][contains(text(), 'Model Compare')]"), "Model Compare Page") { }
        Label lblAddAnotherCar = new Label(By.XPath("//div[@class='add-car-icon']"), "Add Another Car");
        DropDownList drdMake = new DropDownList(By.CssSelector("select#make-dropdown"), "Make");
        DropDownList drdModel = new DropDownList(By.CssSelector("select#model-dropdown"), "Model");
        DropDownList drdYear = new DropDownList(By.CssSelector("select#year-dropdown"), "Year");
        Button btnDone = new Button(By.XPath("//button[@data-linkname='add-car-select']"), "Done");
        //Label lblCarHeaders = new Label(By.XPath("//h4[@class='listing-name']"), "Car name headers");
        string lblCarHeader = "//div[@id='sticky-header']//span[@format='research-car-mmyt'][{0}]";
        string lblCharacteristicValue = "//cars-compare-compare-info[@header='{0}']//span[{1}]";

        public void ClickAddAnotherCar()
        {
            lblAddAnotherCar.Click();
        }

        public void SelectMakeModelYearByText(string make, string model, string year)
        {
            drdMake.SelectByText(make);
            drdModel.SelectByText(model);
            drdYear.SelectByText(year);
        }

        public void ClickDoneToAddCar()
        {
            btnDone.Click();
        }

        public string GetHeaderText(int order)
        {
            return new Label(By.XPath(string.Format(lblCarHeader, order)), "Car header #" + order).GetText();
        }

        public string GetCharacteristicValue(string characteristicName, int order)
        {
            return new Label(By.XPath(string.Format(lblCharacteristicValue, characteristicName, order)), characteristicName).GetText();
        }


    }
}
