using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;
using UITesting.Framework.UI.Controls;
using UITesting.Framework.UI;

namespace UITesting.Framework.Pages
{
    [Alias("On Boarding")]
    public class GameCard : Page
    {
        [Alias("Register Button")]
        [FindBy("btn_register", Platform = TargetPlatform.ANDROID_NATIVE)]
        public Control btnRegister;

        [Alias("Login Button")]
        [FindBy("btn_login", Platform = TargetPlatform.ANDROID_NATIVE)]
        public Control btnLogin;

        [Alias("Title")]
        [FindBy("tv_on_board_title", Platform = TargetPlatform.ANDROID_NATIVE)]
        public Control title;

        [Alias("Description")]
        [FindBy("tv_on_board_description", Platform = TargetPlatform.ANDROID_NATIVE)]
        public Control description;

        public GameCard(IWebDriver driver): base(driver)
        {
        }

    }
}
