using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;
using UITesting.Framework.UI.Controls;
using NUnit.Framework;

namespace UITesting.Framework.UI
{
    public class Page
    {
        private IWebDriver driver;

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public Page(IWebDriver driverValue)
        {
            driver = driverValue;
        }

        public virtual Page  Navigate() {
            return this;
        }

        public bool IsTextPresent(String text)
        {
            String locateText = String.Format("//*[text()='{0}' or contains(text(), '{1}')]", text, text);
            Control element = new Control(this, By.XPath(locateText));
            return element.Exists();
        }

        public byte[] CaptureScreenShot() {
            Screenshot screen = ((ITakesScreenshot)Driver).GetScreenshot();
            return screen.AsByteArray;
        }

        public void CaptureScreenShot(String path)
        {
            Screenshot screen = ((ITakesScreenshot)Driver).GetScreenshot();
            screen.SaveAsFile(path, OpenQA.Selenium.ScreenshotImageFormat.Png);
        }
    }
}
