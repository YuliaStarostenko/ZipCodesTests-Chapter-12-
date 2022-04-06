using OpenQA.Selenium;

namespace ZipCodesTests.Pages.MainPage
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
            MapMainPage = new MapMainPage(driver);
        }
        public MapMainPage MapMainPage { get; }
        protected override string Url => "https://www.zip-codes.com/";
        public void ClickOnSearchButton()
        {
            GoTo();
            MapMainPage.HeaderNavigationButton("Search").Click();
        }
    }
}
