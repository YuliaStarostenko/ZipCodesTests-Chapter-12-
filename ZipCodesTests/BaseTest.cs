using OpenQA.Selenium;
using System;


namespace ZipCodesTests
{
    public class BaseTest
    {
        public void TakeFullScreenshot(IWebDriver driver, String filename)

        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);

        }
    }
}


