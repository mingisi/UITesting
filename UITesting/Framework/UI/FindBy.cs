using System;
namespace UITesting.Framework.UI.Controls
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FindByAttribute : Attribute
    {
        private readonly String locator;

        public String Locator
        {
            get
            {
                return locator;
            }
        }


        public FindByAttribute(String locatorString)
        {
            this.locator = locatorString;
        }
    }
}
