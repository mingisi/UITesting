using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using UITesting.Framework.UI;

namespace UITesting.Framework.Core
{
    public class Driver
    {
 
        private static Dictionary<String, IWebDriver> driverThreadMap = new Dictionary<string, IWebDriver>();
        private Driver()
        {
        }

        private static Dictionary<TargetPlatform, Type> driverMap = new Dictionary<TargetPlatform, Type>()
        {
            {TargetPlatform.CHROME, typeof(ChromeDriver)},
            {TargetPlatform.FIREFOX, typeof(FirefoxDriver)},
            {TargetPlatform.IE, typeof(InternetExplorerDriver)},
            {TargetPlatform.OPERA, typeof(OperaDriver)},
            {TargetPlatform.SAFARI, typeof(SafariDriver)},
            {TargetPlatform.ANDROID_NATIVE, typeof(AndroidDriver<AppiumWebElement>)},
            {TargetPlatform.IOS_NATIVE, typeof(IOSDriver<AppiumWebElement>)},
        };

        private static Dictionary<TargetPlatform, Type> optionsMap = new Dictionary<TargetPlatform, Type>()
        {
            {TargetPlatform.CHROME, typeof(ChromeOptions)},
            {TargetPlatform.FIREFOX, typeof(FirefoxOptions)},
            {TargetPlatform.IE, typeof(InternetExplorerOptions)},
            {TargetPlatform.OPERA, typeof(OperaOptions)},
            {TargetPlatform.SAFARI, typeof(SafariOptions)},

        };


        public static String GetThreadName() {
            return Thread.CurrentThread.Name + Thread.CurrentThread.ManagedThreadId;
        }

        public static void Add(TargetPlatform platform, String path, ICapabilities capabilities)
        {
            Type driverType = driverMap[platform];

            IWebDriver driver;
            if (platform.IsWeb())
            {
                DriverOptions options = (DriverOptions)optionsMap[platform].GetConstructor(new Type[] { }).Invoke(new Object[] { });
                if (platform == TargetPlatform.FIREFOX)
                {
                    driver = new FirefoxDriver((FirefoxOptions)options);

                }
                else
                {
                    driver = (IWebDriver)driverType.GetConstructor(new Type[] { typeof(String), optionsMap[platform] }).Invoke(new Object[] { path, options });
                }
            }
            else 
            {
                driver = (IWebDriver)driverType.GetConstructor(new Type[] { typeof(Uri), typeof(DesiredCapabilities) }).Invoke(new Object[] { new Uri(path), capabilities });
            }
            String threadName = GetThreadName();
            driverThreadMap.Add(threadName, driver);
                                                                      
        }

        public static IWebDriver Current()
        {
            String threadName = GetThreadName();
            return driverThreadMap[threadName];
        }

        public static void Quit() 
        {
            String threadName = GetThreadName();
            Current().Quit();
            driverThreadMap.Remove(threadName);
        }
    }
}
