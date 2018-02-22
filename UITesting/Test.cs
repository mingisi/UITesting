//using NUnit.Framework;
//using System;
//using System.IO;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Remote;
//using OpenQA.Selenium.Chrome;
//using UITesting.Framework.Core;
//using UITesting.Framework.UI.Controls;
//using UITesting.Framework.UI;
//using UITesting.Framework.Pages;

//namespace UITesting
//{
//    //[TestFixture()]
//    public class Test
//    {
//        private SearchPage searchPage;
//        private SearchResultsPage searchResultsPage;
//        private GameCard gameCard;

//        //[SetUp]
//        public void Setup() {
            
//            //ChromeOptions options = new ChromeOptions();
//            DesiredCapabilities capabilities = new DesiredCapabilities();
//            capabilities.SetCapability("app","/Users/salim/mtk_projects/ED/shoot/shootapp-xamarin/src/ShootApp.Droid/bin/Release/com.gunsandgame.ShootApp.apk");
//            capabilities.SetCapability("platformVersion", "7.1.1");
//            capabilities.SetCapability("platformName", "Android");
//            capabilities.SetCapability("deviceName", "Any");

//            Driver.Add(Configuration.Platform, Configuration.DriverPath, capabilities);
            
//            //searchPage = PageFactory.Init<SearchPage>();
//            //searchPage.Navigate();
 
//        }

//        //[TearDown]
//        public void TearDown(){
//            Driver.Quit();    
//        }

//        //[Test()]
//        //public void TestCase()
//        //{

//        //    searchPage.editDestination.Text = "London";
//        //    searchPage.autoCompleteItem.Click();
//        //    searchPage.checkoutDayToday.Click();
//        //    searchPage.radioWork.Click();
//        //    searchPage.selectAdultNumber.Text = "1 adult";
//        //    searchPage.buttonSearch.Click();

//        //    searchResultsPage = PageFactory.Init <SearchResultsPage>();
//        //    searchResultsPage.editDestination.Click();
//        //    Assert.True(searchResultsPage.IsTextPresent("London"));

//        //    searchPage.CaptureScreenShot(Path.GetFullPath("/Users/salim/mtk_projects/ED/UITesting/image001.png"));
//        //}

//        //[Test()]
//        public void login()
//        {
//            gameCard = PageFactory.Init<GameCard>();

//            Assert.AreEqual(gameCard.title.Text, "Game card");


//            gameCard.btnLogin.Click();
//        }

//    }
//}
