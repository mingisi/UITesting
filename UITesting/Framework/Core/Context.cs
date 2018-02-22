using System;
using System.Collections.Generic;

namespace UITesting.Framework.Core
{
    public class Context
    {
        private static Dictionary<String, Dictionary<String, Object>> contextVarible = new Dictionary<string, Dictionary<string, object>>();

        public Context()
        {
        }

        public static void Put(String name, Object value)
        {
            Dictionary<String, Object> dataMap = new Dictionary<string, object>();
            String thereadName = Driver.GetThreadName();
            if (contextVarible.ContainsKey(thereadName))
            {
                dataMap = contextVarible[thereadName];
            }
            dataMap.Add(name, value);
            contextVarible.Add(thereadName, dataMap);
        }

        public static Object get(String name)
        {
            String thereadName = Driver.GetThreadName();
            if (contextVarible.ContainsKey(thereadName))
            {
                return contextVarible[thereadName][name];

            }
            return null;
        }

        public static void ClearCurrent() 
        {
            String thereadName = Driver.GetThreadName();
            if (contextVarible.ContainsKey(thereadName))
            {
                contextVarible.Remove(thereadName);
            }
            contextVarible.Add(thereadName, new Dictionary<string, object>());
        }
    }
}
