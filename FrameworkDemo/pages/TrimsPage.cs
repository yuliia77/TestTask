using FrameworkDemo.framework;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDemo.pages
{
    public class TrimsPage : BasePage
    {
        Button btnViewPage = new Button(By.XPath("//a[@onclick='ViewProductPage()']"), "View Page");
        Label lblCompareTrimsHeader = new Label(By.XPath("//h1[@class='cui-heading-1']"), "Compare Trims header");
        Label lblCharacteristics = new Label(By.XPath("//div[@class='cui-accordion-section'][1]//div[@id='labels-row']/div"), "Characteristics headers");
        Label lblCharacteristicValues = new Label(By.XPath("//div[@class='cui-accordion-section'][1]//div[@class='trim-details']/div[@class='trim-card']/div"), "Characteristic values");

        public TrimsPage() : base(By.XPath("//h1[contains(text(), 'Trims')]"), "Trims Page") { }

        public string GetHeaderText()
        {
            return lblCompareTrimsHeader.GetText();
        }

        public int GetIndexByCharacteristic(string characteristic)
        {
            return lblCharacteristics.GetIndex(characteristic);
        }

        public string GetCharacteristicByIndex(int index)
        {
            return lblCharacteristicValues.GetTextByIndex(index);
        }



    }
}
