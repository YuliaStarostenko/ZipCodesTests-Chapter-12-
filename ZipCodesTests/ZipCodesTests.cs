using NUnit.Framework;
using WebDriverManager.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using ZipCodesTests.Pages.MainPage;
using ZipCodesTests.Pages.SearchPage;
using ZipCodesTests.Pages.DetailsPage;
using ZipCodesTests.Pages;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ZipCodesTests
{
   
    [TestFixture]
    public class DetailsPageTests : BaseTest
    {
        private static IWebDriver _driver;
        private static MainPage _mainPage;
        private static SearchPage _searchPage;
        private static DetailsPage _detailPage;
    
        [SetUp]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = new ChromeDriver();
            _mainPage = new MainPage(_driver);
            _searchPage = new SearchPage(_driver);
            _detailPage = new DetailsPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        List<TownDTO> listOfTowns = new List<TownDTO>();

        [Test]
        public void SreenshotsAreTakenOnFirstTenTowns_When_WordIsSubmittedToAdvanceSearch()
        {
            _mainPage.ClickOnSearchButton();
            GetPageWithListofTownStartingWithWord("jul");
            CollectInfoAboutNeededNumberOfTowns(10);
            MakeScreenShotsofNeededNumberOfTowns(listOfTowns);
        }

        public void GetPageWithListofTownStartingWithWord(string word)
        {
            _searchPage.MapSearchPage.AdvanceSearchButton.Click();
            _searchPage.MapSearchPage.TownCityInputBox.SendKeys(word + Keys.Enter);
        }

        public void MakeScreenShotsofNeededNumberOfTowns(List<TownDTO> listOfTowns)
        {
            var numberOfTowns = listOfTowns.Count();    

            for (int i = 0; i < numberOfTowns; i++)
            {
                 string originalWindow = _driver.CurrentWindowHandle;
                _driver.SwitchTo().NewWindow(WindowType.Tab);
                _driver.Navigate().GoToUrl(listOfTowns[i].GoogleMapLink());
                if (i == 0)
                {
                    _detailPage.MapDetailsPage.GoogleAcceptanceButton.Click();
                }
                var directory = Environment.CurrentDirectory;
                TakeFullScreenshot(_driver, $@"{directory}\..\..\..\{listOfTowns[i].TownName}-{listOfTowns[i].State}-{listOfTowns[i].ZipCode}.jpeg");
                _driver.Close();
                _driver.SwitchTo().Window(originalWindow);
                //_driver.Navigate().Back();
            }
        }

        public void CollectInfoAboutNeededNumberOfTowns(int numberOfTowns)
        {
            for (int i = 0; i < numberOfTowns; i++)
            {
                _searchPage.MapSearchPage.ZipCodeInResultTable(i).Click();
                var town = _detailPage.GetInfoAboutTown();
                listOfTowns.Add(town);
                _driver.Navigate().Back();
            }
        }
    }
}