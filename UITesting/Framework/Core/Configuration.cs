﻿using System;
using System.IO;
using UITesting.Framework.UI;

namespace UITesting.Framework.Core
{
    public class Configuration
    {
        private Configuration()
        {
        }

        public static TargetPlatform Platform
        {
            get
            {
                return TargetPlatformMethods.Value(Get("Browser"));
            }
        }

        public static String DriverPath
        {
            get
            {
                String path = Get("DriverPath");

                if (!path.StartsWith("http:"))
                {
                    return Path.GetFullPath(path);
                }
                return path;
            }
        }

        public static int Timeout 
        {
            get
            {
                return Int32.Parse(Get("timeout"));
            }
        }
        public static String Get(String value){
            return System.Configuration.ConfigurationManager.AppSettings[value];   
        }
    }
}
