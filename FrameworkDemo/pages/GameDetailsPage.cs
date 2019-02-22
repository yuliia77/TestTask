using FrameworkDemo.framework;
using FrameworkDemo.framework.elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

using System.Text;

namespace FrameworkDemo.pages
{
    public class GameDetailsPage : BasePage
    {
        Button btnInstallSteam = new Button(By.XPath("//a[@class='header_installsteam_btn_content']"), "Install Steam");
        Label lblCurrentDiscount = new Label(By.XPath("//div[@id='game_area_purchase'][1]//div[@class='discount_pct']"), "Current Discount");
        Label lblFinalPrice = new Label(By.XPath("//div[@id='game_area_purchase'][1]//div[@class='discount_final_price']"), "Final Price");

        public GameDetailsPage() : base(By.ClassName("package_header"), "Game Details Page") { }

        public string GetCurrentDiscountText()
        {
            return lblCurrentDiscount.GetText();
        }

        public string GetFinalPriceText()
        {
            return lblFinalPrice.GetText();
        }

        public void ClickInstallSteam()
        {
            btnInstallSteam.Click();
        }

    }

    
}
