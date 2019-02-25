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

        [TestCategory("Smoke")]
        [TestMethod]
        public void TestMethod1()
        {
            Logger.Step(1);
            HomePage homePage = new HomePage();
            TopMenu topMenu = new TopMenu();
            int i = 0;
            int n = 2;
            string[] engine = new string[n];
            string[] transmission = new string[n];
            string[] make = new string[n];
            string[] model = new string[n];
            string[] year = new string[n];
            Logger.Step(2, "Search for 2 data sets of car models");

            while (i <= n-1)
            {
                topMenu.ClickOnMenuItem("Research");
                
                ResearchPage researchPage = new ResearchPage();
                researchPage.SelectOptionByRandomIndexInDrd("make");
                make[i] = researchPage.GetSelectedOptionsText("make");
                researchPage.SelectOptionByRandomIndexInDrd("model");
                model[i] = researchPage.GetSelectedOptionsText("model");
                researchPage.SelectOptionByRandomIndexInDrd("year");
                year[i] = researchPage.GetSelectedOptionsText("year");
                researchPage.ClickSearch();

                CarDetailsPage carDetailsPage = new CarDetailsPage();
                Assert.IsTrue((carDetailsPage.GetHeaderText().Contains(model[i]) && carDetailsPage.GetHeaderText().Contains(make[i])), "Found car doesn't match the characteristics selected on Home page ");
                while (!carDetailsPage.CheckIfLinkIsPresent("trim-compare"))
                    {
                        topMenu.ClickOnMenuItem("Research");
                        researchPage.SelectOptionByRandomIndexInDrd("make");
                        make[i] = researchPage.GetSelectedOptionsText("make");
                        researchPage.SelectOptionByRandomIndexInDrd("model");
                        model[i] = researchPage.GetSelectedOptionsText("model");
                        researchPage.SelectOptionByRandomIndexInDrd("year");
                        year[i] = researchPage.GetSelectedOptionsText("year");
                        researchPage.ClickSearch();
                        Assert.IsTrue((carDetailsPage.GetHeaderText().Contains(model[i]) && carDetailsPage.GetHeaderText().Contains(make[i])), "Found car doesn't match the characteristics selected on Home page ");
                    }
                
                carDetailsPage.ClickLink("trim-compare");

                TrimsPage trimsPage = new TrimsPage();
                Assert.IsTrue((trimsPage.GetHeaderText().Contains(model[i]) && trimsPage.GetHeaderText().Contains(make[i])), "Found car doesn't match the characteristics selected on Home page ");
                engine[i] = trimsPage.GetCharacteristicByIndex(trimsPage.GetIndexByCharacteristic("Engine"));
                transmission[i] = trimsPage.GetCharacteristicByIndex(trimsPage.GetIndexByCharacteristic("Trans"));
                i++;

            }
            Logger.Step(3, "Click on Research");
            topMenu.ClickOnMenuItem("Research");            
            ResearchPage researchPage2 = new ResearchPage();

            Logger.Step(4);
            researchPage2.ClickCompareCars();

            Logger.Step(5);
            ComparePage comparePage = new ComparePage();
            comparePage.SelectMakeModelYearByText(make[0], model[0], year[0]);
            comparePage.ClickStartComparing();

            Logger.Step(6);
            CompareDetailsPage compareDetailsPage = new CompareDetailsPage();
            compareDetailsPage.ClickAddAnotherCar();
            comparePage.SelectMakeModelYearByText(make[1], model[1], year[1]);
            compareDetailsPage.ClickDoneToAddCar();

            Logger.Step(7, "Compare selected cars characteristics on the current page to the ones from Trims pages");
            for (int j=0; j<2; j++)
            {
                Assert.IsTrue(compareDetailsPage.GetCharacteristicValue("Engine", j + 1).Contains(engine[j]));
                Assert.IsTrue(compareDetailsPage.GetCharacteristicValue("Transmission", j + 1).Contains(transmission[j]));
                Assert.IsTrue(compareDetailsPage.GetHeaderText(j + 1).Contains(make[j]) && compareDetailsPage.GetHeaderText(j + 1).Contains(year[j]));
            }
           
        }
    }

}

