using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace ZipCodesTests.Pages
{
    public class BaseMap
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;
        private WebDriverWait _webDriverWait;

        public BaseMap(IWebDriver driver)
        {
            _webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }

        protected IWebElement WaitAndFindElement(By locator)
        {
            return _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
        }

    }
}
