using FrameworkDemo.framework.browser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FrameworkDemo.framework.Utils
{
    class FileUtils
    {
        public static void WaitForFileDownload(string filename)
        {
            Browser.GetInstance().GetWait().Until(driver =>
            {
                if (ConfigurationReader.GetValue("Browser") == "chrome")
                {
                    return File.Exists((ConfigurationReader.GetValue("DownloadPath") + "/" + filename)) && new System.IO.FileInfo(ConfigurationReader.GetValue("DownloadPath") + "/" + filename).Length > 0 && Directory.GetFiles(ConfigurationReader.GetValue("DownloadPath"), "*.tmp").Length == 0 && Directory.GetFiles(ConfigurationReader.GetValue("DownloadPath"), "*.crdownload").Length == 0;
                }

                return File.Exists((ConfigurationReader.GetValue("DownloadPath") + "/" + filename)) && new System.IO.FileInfo(ConfigurationReader.GetValue("DownloadPath") + "/" + filename).Length > 0 && Directory.GetFiles(ConfigurationReader.GetValue("DownloadPath"), "*.tmp").Length == 0 && Directory.GetFiles(ConfigurationReader.GetValue("DownloadPath"), "*.part").Length == 0;

            });
        }
    }
}
