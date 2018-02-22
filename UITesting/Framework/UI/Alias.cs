using System;
namespace UITesting.Framework.UI
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class)]
    public class Alias : Attribute
    {
        public String Name
        {
            get; set;
        }

        public Alias(String nameValue)
        {
            this.Name = nameValue;
        }
    }
}
