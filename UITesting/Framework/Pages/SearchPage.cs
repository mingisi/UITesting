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

        [FindBy("css=#ss")]
        public Edit editDestination;

        [FindBy("xpath=(//li[contains(@class, 'autocomplete__item')])[1]")]
        public Control autoCompleteItem;

        [FindBy("css=i.sb-date-field__chevron.bicon-downchevron")]
        public Control checkoutDayToday;

        [FindBy("xpath=//input[@name='sb_travel_purpose']")]
        public Control radioWork;

        [FindBy("group_adults")]
        public SelectList selectAdultNumber;

        [FindBy("css=.sb-searchbox__button")]
        public Control buttonSearch;

        public SearchPage(IWebDriver driver): base(driver)
        {
        }

        public override Page Navigate()
        {
            String baseURL = Configuration.Get("BaseURL");
            Driver.Navigate().GoToUrl(baseURL);
            return this;
        }
    }
}
