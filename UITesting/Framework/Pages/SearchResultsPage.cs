using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;
using UITesting.Framework.UI.Controls;
using UITesting.Framework.UI;

namespace UITesting.Framework.Pages
{
    public class SearchResultsPage : Page
    {
        [FindBy("css=#ss", Platform = TargetPlatform.ANY_WEB)]
        public Edit editDestination;

        public SearchResultsPage(IWebDriver driver):base(driver)
        {
        }
    }
}
