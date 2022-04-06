using OpenQA.Selenium;
using System;

namespace ZipCodesTests.Pages.DetailsPage
{
    public class DetailsPage : BasePage
    {
        public DetailsPage(IWebDriver driver) : base(driver)
        {
            MapDetailsPage = new MapDetailsPage(driver);
        }
        public MapDetailsPage MapDetailsPage { get; }
        
        protected override string Url => throw new NotImplementedException();
        public TownDTO GetInfoAboutTown()
        {
            var town = new TownDTO();

            town.ZipCode = MapDetailsPage.TownInfo(ZipCodeTableLine.ZipCode()).Text;
            town.TownName = MapDetailsPage.TownInfo(ZipCodeTableLine.TownName()).Text;
            town.State = MapDetailsPage.TownInfo(ZipCodeTableLine.State()).Text;
            town.Latitude = MapDetailsPage.TownInfo(ZipCodeTableLine.Latitude()).Text;
            town.Longitude = MapDetailsPage.TownInfo(ZipCodeTableLine.Longitude()).Text;

            return town;
        }

    }
        public class ZipCodeTableLine
        {
        public static string ZipCode() { return "Zip Code:"; }
        public static string TownName() { return "City:"; }
        public static string State() { return "State:"; }
        public static string Latitude() { return "Latitude:"; }
        public static string Longitude() { return "Longitude:"; }
        }
}
