using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Utility
    {
        public class Log
        {
            private static readonly Log _instance = new Log();

            ILog monitorlogging;
            static ILog debuggerlogging;

            private Log()
            {

                monitorlogging = LogManager.GetLogger("MonitoringLogger");
                debuggerlogging = LogManager.GetLogger("DebuggerLogger");

            }

            public static void Debug(string message)
            {
                debuggerlogging.Debug(message);
            }

            public static void Info(string message)
            {
                _instance.monitorlogging.Info(message);
            }

            public static void Info(string message, Exception ex)
            {
                _instance.monitorlogging.Info(message, ex);
            }

            public static void Warn(string message)
            {
                _instance.monitorlogging.Warn(message);
            }
            public static void Warn(string message, Exception ex)
            {
                _instance.monitorlogging.Warn(message, ex);
            }

            public static void Error(string message)
            {
                _instance.monitorlogging.Error(message);
            }

            public static void Error(string message, Exception ex)
            {
                _instance.monitorlogging.Error(message, ex);
            }

            public static void Fatal(string message)
            {
                _instance.monitorlogging.Fatal(message);
            }

            public static void Fatal(string message, Exception ex)
            {
                _instance.monitorlogging.Fatal(message, ex);
            }


        }
    }
