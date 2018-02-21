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

namespace UITesting.Framework.Core
{
    public class Driver
    {
 
        private static Dictionary<String, IWebDriver> driverThreadMap = new Dictionary<string, IWebDriver>();
        private Driver()
        {
        }

        private static Dictionary<String, Type> driverMap = new Dictionary<String, Type>()
        {
            {"chrome", typeof(ChromeDriver)},
            {"firefox", typeof(FirefoxDriver)},
            {"ie", typeof(InternetExplorerDriver)},
            {"opera", typeof(OperaDriver)},
            {"safari", typeof(SafariDriver)},
        };

        private static Dictionary<String, Type> optionsMap = new Dictionary<String, Type>()
        {
            {"chrome", typeof(ChromeOptions)},
            {"firefox", typeof(FirefoxOptions)},
            {"ie", typeof(InternetExplorerOptions)},
            {"opera", typeof(OperaOptions)},
            {"safari", typeof(SafariOptions)},
        };


        private static String _getThreadName() {
            return Thread.CurrentThread.Name + Thread.CurrentThread.ManagedThreadId;
        }

        public static void Add(String browser, String path, ICapabilities capabilities)
        {
            Type driverType = driverMap[browser];
            DriverOptions options = (DriverOptions)optionsMap[browser].GetConstructor(new Type[] { }).Invoke(new Object[] { });
            IWebDriver driver;
            if (browser == "firefox")
            {
                driver = new FirefoxDriver((FirefoxOptions)options);

            }
            else
            {
                driver = (IWebDriver)driverType.GetConstructor(new Type[] { typeof(String), optionsMap[browser] }).Invoke(new Object[] { path, options });
            }
            String threadName = _getThreadName();
            driverThreadMap.Add(threadName, driver);
                                                                      
        }

        public static IWebDriver Current()
        {
            String threadName = _getThreadName();
            return driverThreadMap[threadName];
        }

        public static void Quit() 
        {
            String threadName = _getThreadName();
            Current().Quit();
            driverThreadMap.Remove(threadName);
        }
    }
}
