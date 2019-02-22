using System;
using FrameworkDemo.framework.browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkDemo.framework
{
    public class BaseTest
    {
        [TestInitialize]
        public void StartBrowser()
        {
            Browser.GetInstance().Maximize();
            Browser.GetInstance().OpenURL(ConfigurationReader.GetValue("StartURL"));
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            Browser.GetInstance().Close();
        }
    }
}
