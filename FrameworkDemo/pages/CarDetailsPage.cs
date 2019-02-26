using FrameworkDemo.framework;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

using System.Text;

namespace FrameworkDemo.pages
{
    public class CarDetailsPage : BaseCarsPage
    {
        Label lblHeader = new Label(By.XPath("//h1[@class='cui-page-section__title']"), "Car name title");
        //Label lblTrims = new Label(By.XPath("//*[@data-linkname='trim-compare']"), "Compare Trims");
        string lblLink = "//*[@data-linkname='{0}']";

        public CarDetailsPage() : base(By.XPath("//a[@data-linkname='bc-research']"), "Car Details Page") { }

        public string GetHeaderText()
        {
            return lblHeader.GetText();
        }

        public void ClickLink(string linkData)
        {
            new Label(By.XPath(string.Format(lblLink, linkData)), linkData).Click();

        }

        public bool IsLinkPresent(string linkData)
        {
            return new Label(By.XPath(string.Format(lblLink, linkData)), linkData).GetAllElements().Count != 0;
            

        }

    }

        }
   