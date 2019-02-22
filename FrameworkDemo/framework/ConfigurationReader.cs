using System;
using System.Configuration;

namespace FrameworkDemo.framework
{
    public class ConfigurationReader
    {
        static Configuration cofiguration = ConfigurationManager.OpenExeConfiguration("FrameworkDemo.dll");

        public static String GetValue(string key)
        {
            String env = Environment.GetEnvironmentVariable(key);
            return env != null ? env : cofiguration.AppSettings.Settings[key].Value;
        }


    }
}
