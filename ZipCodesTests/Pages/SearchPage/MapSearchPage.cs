using OpenQA.Selenium;

namespace ZipCodesTests.Pages.SearchPage
{
    public class MapSearchPage : BaseMap
    {
        public MapSearchPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement AdvanceSearchButton => WaitAndFindElement(By.XPath("//*[@id='ui-id-7']"));
        public IWebElement TownCityInputBox => WaitAndFindElement(By.Name("fld-city"));

        public IWebElement ZipCodeInResultTable(int lineNumber)
        {
            return WaitAndFindElement(By.XPath($"//table[@class='statTable']//tbody/tr[{lineNumber + 2}]/td[1]/a"));
            
        }
    }
}
