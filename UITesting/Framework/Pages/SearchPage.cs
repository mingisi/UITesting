using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;
using UITesting.Framework.UI.Controls;
using UITesting.Framework.UI;

namespace UITesting.Framework.Pages
{
    public class SearchPage : Page
    {

        [FindBy("css=#ss", Platform = TargetPlatform.ANY_WEB)]
        public Edit editDestination;

        [FindBy("xpath=(//li[contains(@class, 'autocomplete__item')])[1]", Platform = TargetPlatform.ANY_WEB)]
        public Control autoCompleteItem;

        [FindBy("css=i.sb-date-field__chevron.bicon-downchevron", Platform = TargetPlatform.ANY_WEB)]
        public Control checkoutDayToday;

        [FindBy("xpath=//input[@name='sb_travel_purpose']", Platform = TargetPlatform.ANY_WEB)]
        public Control radioWork;

        [FindBy("group_adults", Platform = TargetPlatform.ANY_WEB)]
        public SelectList selectAdultNumber;

        [FindBy("css=.sb-searchbox__button", Platform = TargetPlatform.ANY_WEB)]
        public Control buttonSearch;

        public SearchPage(IWebDriver driver): base(driver)
        {
        }

        public override Page Navigate()
        {
            if (Configuration.Platform.IsWeb())
            {
                String baseURL = Configuration.Get("BaseURL");
                Driver.Navigate().GoToUrl(baseURL);
            }

            return this;
        }
    }
}
