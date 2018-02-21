using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;
using NUnit.Framework;

namespace UITesting.Framework.UI.Controls
{
    public class SelectList : Control
    {
        public SelectList(Page pageValue, By locatorValue) : base(pageValue, locatorValue)
        {
        }

        public SelectElement Select
        {
            get
            {
                return new SelectElement(base.Element);  
            }
        }

        public new String Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                this.Select.SelectByText(value);
            }
        }
    }
}
