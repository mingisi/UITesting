using System;
using UITesting.Framework.ODT;
namespace UITesting.ODTSteps
{
    public class SetupStep : ODTTestStep
    {
        public override void StepBody() {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("app", "/Users/salim/mtk_projects/ED/shoot/shootapp-xamarin/src/ShootApp.Droid/bin/Release/com.gunsandgame.ShootApp.apk");
            capabilities.SetCapability("platformVersion", "7.1.1");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("deviceName", "Any");

            Driver.Add(Configuration.Platform, Configuration.DriverPath, capabilities);
        }
    }

    public class GotBankingStep : ODTTestStep
    {
        public override void StepBody()
        {

        }
    }

    public class AfterStep : ODTTestStep
    {
        public override void StepBody()
        {

        }
    }
}
