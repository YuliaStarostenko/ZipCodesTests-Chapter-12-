using OpenQA.Selenium;

namespace ZipCodesTests.Pages.DetailsPage
{
    public class MapDetailsPage : BaseMap
    {
        public MapDetailsPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement TownInfo(string rowName)
        {
            return WaitAndFindElement(By.XPath($"//td[preceding-sibling::td[contains(.,'{rowName}')]]"));
        }
        public IWebElement GoogleAcceptanceButton => WaitAndFindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div/div/div[2]/div[1]/div[4]/form/div/div/button"));
    }
}
