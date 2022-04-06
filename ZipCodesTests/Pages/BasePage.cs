using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ZipCodesTests.Pages
{
    public abstract class BasePage
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            WebDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }
        protected IWebDriver Driver { get; set; }
        protected WebDriverWait WebDriverWait { get; set; }
        protected abstract string Url { get; }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(Url);
            WaitForPageToLoad();
            Driver.Manage().Window.Maximize();
        }
        protected virtual void WaitForPageToLoad()
        {
        }
        protected IWebElement WaitAndFindElement(By locator)
        {
            return WebDriverWait.Until(ExpectedConditions.ElementExists(locator));
        }

        protected void WaitForAjax()
        {
            var js = (IJavaScriptExecutor)Driver;
            WebDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");

        }

        protected void WaitUntilPageLoadsCompletely()
        {
            var js = (IJavaScriptExecutor)Driver;
            WebDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
