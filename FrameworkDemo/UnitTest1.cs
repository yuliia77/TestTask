using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using FrameworkDemo.framework;
using FrameworkDemo.framework.browser;
using FrameworkDemo.framework.elements;
using FrameworkDemo.framework.Utils;
using FrameworkDemo.pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace FrameworkDemo
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        const string day = "10";
        const string month = "May";
        const string year = "2000";
        const string filename = "SteamSetup.exe";

        [TestCategory("Smoke")]
        [TestMethod]
        public void TestMethod1()
        {
            Logger.Step(1);
            HomePage homePage = new HomePage();
            homePage.NavigateToMenuItem("Games", "Action");

            Logger.Step(2);
            ActionPage actionPage = new ActionPage();
            actionPage.GoToAllSpecials();

            Logger.Step(3);
            SpecialsPage specialsPage = new SpecialsPage();
            var maxDiscount = specialsPage.FindMaxDiscount();
            var maxDiscounttext = specialsPage.GetMaxDiscountText(maxDiscount);
            var maxFinalPricetext = specialsPage.GetFinalPriceTextForMaxDiscount(maxDiscount);            
            specialsPage.ClickMaxDiscount(maxDiscount);

            Logger.Step(4);
            if (Browser.GetInstance().GetDriver().Url.Contains("agecheck"))
            {
                AgeCheckPage ageCheckPage = new AgeCheckPage();
                ageCheckPage.SelectDateMonthYear(day, month, year);
                ageCheckPage.ClickViewPage();
            }

            Logger.Step(5);
            GameDetailsPage gamesDetailsPage = new GameDetailsPage();
            var currentDiscounttext = gamesDetailsPage.GetCurrentDiscountText();

            Logger.Step(6);
            var finalPricetext = gamesDetailsPage.GetFinalPriceText();
            Assert.AreEqual(maxDiscounttext, currentDiscounttext, "Values of max discount on Specials and Game Details pages don't match");
            Assert.IsTrue(maxFinalPricetext.EndsWith(finalPricetext), "Values of final price on Specials and Game Details pages don't match");

            Logger.Step(7);
            gamesDetailsPage.ClickInstallSteam();

            Logger.Step(8);
            AboutPage aboutPage = new AboutPage();
            aboutPage.ClickInstallSteamNow();

            Logger.Step(9, "Wait until exe file is downloaded");
            FileUtils.WaitForFileDownload(filename);
           
        }

        [TestCategory("Smoke")]
        [TestMethod]
        public void TestMethod2()
        {
            Logger.Step(1);
            HomePage homePage = new HomePage();
            homePage.NavigateToMenuItem("Games", "Action");

            Logger.Step(2);
            ActionPage actionPage = new ActionPage();
            actionPage.GoToAllSpecials();

        }

        [TestCategory("Mat")]
        [TestMethod]
        public void TestMethod3()
        {
            Logger.Step(1);
            HomePage homePage = new HomePage();
            homePage.NavigateToMenuItem("Games", "Action");

            Logger.Step(2);
            ActionPage actionPage = new ActionPage();
            actionPage.GoToAllSpecials();

            Assert.IsFalse(true);

        }



        [TestCleanup]
        public void CleanDownloads()
        {
            Logger.Info("Delete downloaded file from the folder");
            DirectoryInfo dir = new DirectoryInfo(ConfigurationReader.GetValue("DownloadPath"));
            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }
        }
}
}
