using TechTalk.SpecFlow;
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


namespace UITesting.Steps
{
    [Binding]
    public class BasicSteps
    {   
        [Before]
        public void Setup()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("app", "/Users/salim/mtk_projects/ED/shoot/shootapp-xamarin/src/ShootApp.Droid/bin/Release/com.gunsandgame.ShootApp.apk");
            capabilities.SetCapability("platformVersion", "7.1.1");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("deviceName", "Any");

            Driver.Add(Configuration.Platform, Configuration.DriverPath, capabilities);

        }

        [After]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Given(@"^I on the on boading page$")]
        public void startTheApp() 
        {
            Console.WriteLine("runnnnnning the test.....");
        }

        [Given("^I am on the \"(.*)\" (?:page|screen)$")]
        [When("^(?:I |)go to the \"(.*)\" (?:page|screen)$")]
        public void NavigateToPage(String name)
        {
            Page target = Page.Screen(name);
            Assert.NotNull(target, "Unable to find the '" + name + "' page.");
            this.VerifyCurrentPage(name);
        }

   

        [Then(@"^I should see the ""(.*)"" (?:page|screen)$")]
        public void VerifyCurrentPage(String name)
        {
            
        }
    }
}
