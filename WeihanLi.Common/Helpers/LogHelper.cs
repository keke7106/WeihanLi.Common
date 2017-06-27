using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace WeihanLi.Common.Helpers
{
    public interface ILogHelper
    {

        #region Info

        void Info(string msg);

        void InfoFormat(string msgFormat, params object[] args);
        #endregion

        #region Debug

        void Debug(string msg);

        void DebugFormat(string msgFormat, params object[] args);

        void Debug(string msg, Exception ex);

        void Debug(Exception ex);
        #endregion

        #region Warn

        void Warn(string msg);

        void WarnFormat(string msgFormat, params object[] args);

        void Warn(string msg, Exception ex);

        void Warn(Exception ex);
        #endregion

        #region Error

        void Error(string msg);

        void ErrorFormat(string msgFormat, params object[] args);

        void Error(string msg, Exception ex);

        void Error(Exception ex);

        #endregion
    }

    public class LogHelper:ILogHelper
    {
        private readonly ILog logger = null;

        public LogHelper(Type t)
        {
            logger = LogManager.GetLogger(t);
        }

#if  NET45
        
        /// <summary>
        /// web.config 默认配置
        /// </summary>
        public static void LogInit()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// 独立文件配置
        /// </summary>
        /// <param name="filePath">log4net配置文件路径</param>
        public static void LogInit(string filePath)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(filePath));
        }
        
#endif

        /// <summary>
        /// 独立文件配置
        /// </summary>
        /// <param name="repositoryName">repository名称</param>
        /// <param name="filePath">log4net配置文件路径</param>
        public static void LogInit(string repositoryName,string filePath)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(LogManager.CreateRepository(repositoryName), new System.IO.FileInfo(filePath));
        }

        #region Info
        public void Info(string msg)
        {
            logger.Info(msg);
        }

        public void InfoFormat(string msgFormat, params object[] args)
        {
            Info(String.Format(msgFormat, args));
        }

        public void Info(string msg, Exception ex)
        {
            logger.Info(msg, ex);
        }
        #endregion

        #region Debug
        public void Debug(string msg)
        {
            logger.Debug(msg);
        }

        public void DebugFormat(string msgFormat, params object[] args)
        {
            Debug(String.Format(msgFormat, args));
        }

        public void Debug(string msg, Exception ex)
        {
            logger.Debug(msg, ex);
        }

        public void Debug(Exception ex)
        {
            logger.Debug(ex.Message, ex);
        }
        #endregion
        
        #region Warn
        public void Warn(string msg)
        {
            logger.Warn(msg);
        }

        public void WarnFormat(string msgFormat, params object[] args)
        {
            Warn(String.Format(msgFormat, args));
        }

        public void Warn(string msg, Exception ex)
        {
            logger.Warn(msg, ex);
        }

        public void Warn(Exception ex)
        {
            logger.Warn(ex.Message, ex);
        }
        #endregion

        #region Error
        public void Error(string msg)
        {
            logger.Error(msg);
        }

        public void ErrorFormat(string msgFormat, params object[] args)
        {
            Error(String.Format(msgFormat, args));
        }

        public void Error(string msg, Exception ex)
        {
            logger.Error(msg, ex);
        }

        public void Error(Exception ex)
        {
            logger.Error(ex.Message, ex);
        }
        #endregion
    }
}
