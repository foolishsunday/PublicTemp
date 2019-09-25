using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

namespace XPCar.Common
{
    public class Log
    {
        private static ILog m_Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static Log()
        {
            //XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));

        }
        public static void Debug(object message)
        {
            m_Log.Debug(message);
        }
        public static void Debug(object message, Exception exception)
        {
            m_Log.Debug(message, exception);
        }
        public static void DebugFormatted(string format, params object[] args)
        {
            if (m_Log != null)
                m_Log.DebugFormat(format, args);
        }
        public static void DebugFormat(string format, object arg0)
        {
            if (m_Log != null)
                m_Log.DebugFormat(format, arg0);
        }
        public static void Info(object message)
        {
            if (m_Log != null)
                m_Log.Info(message);
        }

        public static void InfoFormatted(string format, params object[] args)
        {
            if (m_Log != null)
                m_Log.InfoFormat(format, args);
        }

        public static void Warn(string functionName, string message)
        {
            if (m_Log != null)
                m_Log.Warn(functionName + "()" + message);
        }
        public static void Warn(object message, Exception exception)
        {
            if (m_Log != null)
                m_Log.Warn(message, exception);
        }

        public static void WarnFormatted(string format, params object[] args)
        {
            if (m_Log != null)
                m_Log.WarnFormat(format, args);
        }

        public static void Error(string functionName, string message)
        {
            if (m_Log != null)
                m_Log.Error(functionName + "()" + message);
        }

        public static void Error(object message, Exception exception)
        {
            if (m_Log != null)
                m_Log.Error(message, exception);
        }

        public static void ErrorFormatted(string format, params object[] args)
        {
            if (m_Log != null)
                m_Log.ErrorFormat(format, args);
        }

        public static void Fatal(object message)
        {
            if (m_Log != null)
                m_Log.Fatal(message);
        }

        public static void Fatal(object message, Exception exception)
        {
            if (m_Log != null)
                m_Log.Fatal(message, exception);
        }

        public static void FatalFormatted(string format, params object[] args)
        {
            if (m_Log != null)
                m_Log.FatalFormat(format, args);
        }
    }
}
