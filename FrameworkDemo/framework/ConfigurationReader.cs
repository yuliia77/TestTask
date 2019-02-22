using System;
using System.Configuration;

namespace FrameworkDemo.framework
{
    public class ConfigurationReader
    {
        static Configuration cofiguration = ConfigurationManager.OpenExeConfiguration("FrameworkDemo.dll");

        public static String GetValue(string key)
        {
            return cofiguration.AppSettings.Settings[key].Value;
        }

    }
}
