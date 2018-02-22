using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;
using UITesting.Framework.UI.Controls;
using NUnit.Framework;

namespace UITesting.Framework.UI
{
    public class Page
    {
        private IWebDriver driver;
        private static Dictionary<String, Page> currentPage = new Dictionary<String, Page>();

        public static Page Current
        {
            get {
                return currentPage[UITesting.Framework.Core.Driver.GetThreadName()];
            }
            set
            {
                currentPage[UITesting.Framework.Core.Driver.GetThreadName()] = value;
            }
        }

        public Control this[String name]
        {
            get
            {
                foreach(FieldInfo field in this.GetType().GetFields())
                {
                    if (typeof(Control).IsAssignableFrom(field.FieldType))
                    {
                        Alias alias = field.GetCustomAttribute<Alias>();
                        if (alias != null && name.Equals((alias.Name)))
                        {
                            return (Control)field.GetValue(this);
                        }
                    }
                }
                return null;
            }
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public Page(IWebDriver driverValue)
        {
            driver = driverValue;
        }

        public virtual Page  Navigate() {
            return this;
        }

        public bool IsTextPresent(String text)
        {
            String locateText = String.Format("//*[text()='{0}' or contains(text(), '{1}')]", text, text);
            Control element = new Control(this, By.XPath(locateText));
            return element.Exists();
        }

        public byte[] CaptureScreenShot() {
            Screenshot screen = ((ITakesScreenshot)Driver).GetScreenshot();
            return screen.AsByteArray;
        }

        public void CaptureScreenShot(String path)
        {
            Screenshot screen = ((ITakesScreenshot)Driver).GetScreenshot();
            screen.SaveAsFile(path, OpenQA.Selenium.ScreenshotImageFormat.Png);
        }

        public static Page Screen(String name) 
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            Type pageType = types.Where<Type>(t => (typeof(Page)).IsAssignableFrom(t)
                                              && t.GetCustomAttribute<Alias>() != null
                                              && t.GetCustomAttribute<Alias>().Name.Equals(name))
                                 .First<Type>();
            return (Page)typeof(PageFactory).GetMethod("init").MakeGenericMethod(new Type[] { pageType }).Invoke(null, new Object[] { });
        }
    }
}
