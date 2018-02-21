using System;
using System.Reflection;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using UITesting.Framework.Core;
using UITesting.Framework.UI.Controls;



namespace UITesting.Framework.UI
{
    public class PageFactory
    {
        private PageFactory()
        {
        }

        private static By toLocator(String input)
        {
            if (Regex.IsMatch(input, "^(xpath=|/)(.*)")) 
            {
                return By.XPath(new Regex("^xpath=").Replace(input, ""));
            }
            else if(Regex.IsMatch(input, "^css=(.*)"))
            {
                return By.CssSelector(input.Substring("css=".Length));
            }
            else
            {
                return By.Id(input);
            }
        }

        public static T Init<T>() where T: Page
        {
            IWebDriver driver = Driver.Current();
            T page = (T)typeof(T).GetConstructor(new Type[] { typeof(IWebDriver) }).Invoke(new Object[] { driver });


            foreach ( FieldInfo field in typeof(T).GetFields() ){
                FindByAttribute locator = (FindByAttribute) field.GetCustomAttribute(typeof(FindByAttribute));
                if ( locator != null ) {
                    Control control = (Control) field.FieldType.GetConstructor(new Type[] { typeof(Page), typeof(By) }).Invoke(new Object[] { page, toLocator(locator.Locator) });
                
                    field.SetValue(page, control);
                }


            }
            return page;
        }
    }
}
