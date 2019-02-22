using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using log4net;

namespace FrameworkDemo.framework
{
    public class Logger
    {
        ILog logger;
        static Logger instance;

        private Logger()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            logger = LogManager.GetLogger(GetType());
        }

        private static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        public static void Info(string message)
        {
            GetInstance().logger.Info(message);
        }

        public static void Step(int number)
        {
            GetInstance().logger.Info(string.Format("== Step {0} ==", number));
        }

        public static void Step(int number, string message)
        {
            GetInstance().logger.Info(string.Format("== Step {0} {1} ==", number, message));
        }



    }
}
