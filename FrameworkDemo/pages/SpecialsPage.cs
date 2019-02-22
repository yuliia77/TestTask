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
    public class SpecialsPage : BasePage
    {
        Label lblDiscounts = new Label(By.XPath("//*[contains(@class, 'search_discount')]/span"), "Discounts");
        string lblDiscount = "//*[contains(@class, 'search_discount')]/span[text()='{0}']";   
        string lblFinalPrice = "//div[contains(@class, 'search_price_discount_combined')][.//*[contains(@class, 'search_discount')]/span[text()='{0}']]//div[contains(@class, 'search_price')]";

        public SpecialsPage() : base(By.XPath("//h2[contains(text(), 'Specials')]"), "Specials Page") { }

        public string FindMaxDiscount()
        {
            return lblDiscounts.GetAllElementsText().Max();
        }

        public string GetMaxDiscountText(string maxDiscount)
        {
            Label lblMaxDiscount = new Label(By.XPath(string.Format(lblDiscount, maxDiscount)), maxDiscount);
            return lblMaxDiscount.GetText();

        }

        public string GetFinalPriceTextForMaxDiscount(string maxDiscount)
        {
            Label lblFinalPriceForMax = new Label(By.XPath(string.Format(lblFinalPrice, maxDiscount)), maxDiscount);
            return lblFinalPriceForMax.GetText();
        }
    

        public void ClickMaxDiscount(string maxDiscount)
        {
            Label lblMaxDiscount = new Label(By.XPath(string.Format(lblDiscount, maxDiscount)), maxDiscount);
            lblMaxDiscount.Click();
        }


    }
}
