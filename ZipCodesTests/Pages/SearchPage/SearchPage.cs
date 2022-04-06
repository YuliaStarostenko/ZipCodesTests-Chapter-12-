using OpenQA.Selenium;

namespace ZipCodesTests.Pages.SearchPage
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
            MapSearchPage = new MapSearchPage(driver);
        }
        public MapSearchPage MapSearchPage { get; }
        protected override string Url => "https://www.zip-codes.com/search.asp";

    }
}
