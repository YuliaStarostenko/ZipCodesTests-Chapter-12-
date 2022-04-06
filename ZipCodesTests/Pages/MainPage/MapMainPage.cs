using OpenQA.Selenium;

namespace ZipCodesTests.Pages.MainPage
{
    public class MapMainPage : BaseMap
    {
        public MapMainPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement HeaderNavigationButton(string buttonName)
        {
            return WaitAndFindElement(By.XPath($"//*[@class='header']//*[text()='{buttonName}']"));
        }
    }
}
