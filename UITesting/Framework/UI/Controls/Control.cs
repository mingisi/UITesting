using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;
using NUnit.Framework;

namespace UITesting.Framework.UI.Controls
{
    public class Control
    {
        private Page page;
        private By locator;

        public Page Page
        {
            get
            {
                return page;
            }
        }

        public IWebDriver Driver
        {
            get
            {
                return Page.Driver;
            }
        }

        public By Locator 
        {
            get
            {
                return locator;
            }
        }

        public String Text
        {
            get 
            {
                Assert.True(this.Exists(), "Unable to find the element: " + this.locator);
                return this.Element.Text;
            }
        }

        public void Click()
        {
            Assert.True(this.Exists(), "Unable to find the element: " + this.locator);
            Assert.True(this.Visible(), "Unable to wait for visible element: " + this.locator);
            this.Element.Click();
        }

        public IWebElement Element
        {
            get
            {
                return this.Driver.FindElement(this.locator);
            }
        }

        public Control(Page pageValue, By locatorValue)
        {
            page = pageValue;
            locator = locatorValue;
        }

        public bool Exists(int timout)
        {
            return WaitUntil(ExpectedConditions.ElementExists(this.locator), timout);
        }

        public bool Exists(){
            return Exists(Configuration.Timeout);
        }

        public bool Visible(int timout)
        {
            return WaitUntil(ExpectedConditions.ElementIsVisible(this.locator), timout);
        }

        public bool Visible()
        {
            return Visible(Configuration.Timeout);
        }

        public bool Enabled(int timout)
        {
            return WaitUntil<bool>(c => { return this.Element.Enabled; }, timout);
        }

        public bool WaitUntil<T>(Func<IWebDriver , T> condition, int timout)
        {
            try
            {
                new WebDriverWait(this.Driver, TimeSpan.FromSeconds(timout))
                    .Until(condition);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

    }
}
