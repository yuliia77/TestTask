using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using FrameworkDemo.Entities;
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
            int i = 0;
            int n = 2;
            Car[] cars = new Car[n];
            Logger.Step(2, "Search for 2 data sets of car models");

            while (i <= n-1)
            {
                homePage.topMenu.ClickOnMenuItem("Research");
                
                ResearchPage researchPage = new ResearchPage();
                cars[i] = researchPage.SelectRandomCar();
                researchPage.ClickSearch();

                CarDetailsPage carDetailsPage = new CarDetailsPage();
                Assert.IsTrue((carDetailsPage.GetHeaderText().Contains(cars[i].Model) && carDetailsPage.GetHeaderText().Contains(cars[i].Make)), "Found car doesn't match the characteristics selected on Home page ");
                while (!carDetailsPage.IsLinkPresent("trim-compare"))
                    {
                        carDetailsPage.topMenu.ClickOnMenuItem("Research");
                        cars[i] = researchPage.SelectRandomCar();
                        researchPage.ClickSearch();
                        Assert.IsTrue((carDetailsPage.GetHeaderText().Contains(cars[i].Model) && carDetailsPage.GetHeaderText().Contains(cars[i].Make)), "Found car doesn't match the characteristics selected on Home page ");
                    }
                
                carDetailsPage.ClickLink("trim-compare");

                TrimsPage trimsPage = new TrimsPage();
                Assert.IsTrue((trimsPage.GetHeaderText().Contains(cars[i].Model) && trimsPage.GetHeaderText().Contains(cars[i].Make)), "Found car doesn't match the characteristics selected on Home page ");
                trimsPage.UpdateCharacteristics(cars[i]);
                i++;

            }
            Logger.Step(3, "Click on Research");

            homePage.topMenu.ClickOnMenuItem("Research");
            ResearchPage researchPage2 = new ResearchPage();

            Logger.Step(4);
            researchPage2.ClickCompareCars();

            Logger.Step(5);
            ComparePage comparePage = new ComparePage();
            comparePage.SelectCar(cars[0]);
            comparePage.ClickStartComparing();

            Logger.Step(6);
            CompareDetailsPage compareDetailsPage = new CompareDetailsPage();
            compareDetailsPage.ClickAddAnotherCar();
            comparePage.SelectCar(cars[1]);
            compareDetailsPage.ClickDoneToAddCar();

            Logger.Step(7, "Compare selected cars characteristics on the current page to the ones from Trims pages");
            for (int j=0; j<2; j++)
            {
                Assert.IsTrue(compareDetailsPage.GetCharacteristicValue("Engine", j + 1).Contains(cars[j].Engine));
                Assert.IsTrue(compareDetailsPage.GetCharacteristicValue("Transmission", j + 1).Contains(cars[j].Transmission));
                Assert.IsTrue(compareDetailsPage.GetHeaderText(j + 1).Contains(cars[j].Make) && compareDetailsPage.GetHeaderText(j + 1).Contains(cars[j].Year));
            }

        }
    }

}

