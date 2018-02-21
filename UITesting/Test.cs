using NUnit.Framework;
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using UITesting.Framework.Core;
using UITesting.Framework.UI.Controls;
using UITesting.Framework.UI;
using UITesting.Framework.Pages;

namespace UITesting
{
    [TestFixture()]
    public class Test
    {
        private SearchPage searchPage;
        private SearchResultsPage searchResultsPage;

        [SetUp]
        public void Setup() {
            
            ChromeOptions options = new ChromeOptions();
            DesiredCapabilities capabilities = new DesiredCapabilities();
            Driver.Add(Configuration.Get("Browser"),
                       Path.GetFullPath("/Users/salim/mtk_projects/ED/UITesting/UITesting"),
                       capabilities);
            
            searchPage = PageFactory.Init<SearchPage>();
            searchPage.Navigate();
 
        }

        [TearDown]
        public void TearDown(){
            Driver.Quit();    
        }

        [Test()]
        public void TestCase()
        {

            searchPage.editDestination.Text = "London";
            searchPage.autoCompleteItem.Click();
            searchPage.checkoutDayToday.Click();
            searchPage.radioWork.Click();
            searchPage.selectAdultNumber.Text = "1 adult";
            searchPage.buttonSearch.Click();

            searchResultsPage = PageFactory.Init <SearchResultsPage>();
            searchResultsPage.editDestination.Click();
            Assert.True(searchResultsPage.IsTextPresent("London"));

            searchPage.CaptureScreenShot(Path.GetFullPath("/Users/salim/mtk_projects/ED/UITesting/image001.png"));
        }
    }
}
