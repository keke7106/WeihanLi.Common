using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace WeihanLi.Common.Helpers
{
    public interface ILogProvider
    {
        #region Init

        /// <summary>
        /// init
        /// </summary>
        void LogInit();

        #endregion Init

        #region Info

        void Info(string msg);

        void InfoFormat(string msgFormat, params object[] args);

        void Info(string msg, Exception ex);

        #endregion Info

        #region Debug

        void Debug(string msg);

        void DebugFormat(string msgFormat, params object[] args);

        void Debug(string msg, Exception ex);

        #endregion Debug

        #region Warn

        void Warn(string msg);

        void WarnFormat(string msgFormat, params object[] args);

        void Warn(string msg, Exception ex);

        void Warn(Exception ex);

        #endregion Warn

        #region Error

        void Error(string msg);

        void ErrorFormat(string msgFormat, params object[] args);

        void Error(string msg, Exception ex);

        void Error(Exception ex);

        #endregion Error

        #region Fatal

        void Fatal(string msg);

        void FatalFormat(string msgFormat, params object[] args);

        void Fatal(string msg, Exception ex);

        void Fatal(Exception ex);

        #endregion Fatal

    }

    internal class DefaultLogProvider : ILogProvider
    {
        private ILog _logger;

        public ILog Logger
        {
            get => _logger;
            set => _logger = value;
        }

        #region LogInit

        /// <summary>
        /// web.config 或 app.config 默认配置
        /// </summary>
        public void LogInit()
        {
#if NET45
            log4net.Config.XmlConfigurator.Configure();
#else
            log4net.Config.XmlConfigurator.Configure(LogManager.CreateRepository(Assembly.GetEntryAssembly().FullName));
#endif
        }

        /// <summary>
        /// 独立文件配置
        /// </summary>
        /// <param name="filePath">log4net配置文件路径</param>
        public void LogInit(string filePath)
        {
#if NET45
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(filePath));
#else
            log4net.Config.XmlConfigurator.ConfigureAndWatch(LogManager.CreateRepository(Assembly.GetEntryAssembly().FullName), new System.IO.FileInfo(filePath));
#endif
        }

        #endregion LogInit

        #region Info

        public void Info(string msg)
        {
            _logger.Info(msg);
        }

        public void InfoFormat(string msgFormat, params object[] args)
        {
            _logger.InfoFormat(msgFormat, args);
        }

        public void Info(string msg, Exception ex)
        {
            _logger.Info(msg, ex);
        }

        #endregion Info

        #region Debug

        public void Debug(string msg)
        {
            _logger.Debug(msg);
        }

        public void DebugFormat(string msgFormat, params object[] args)
        {
            _logger.DebugFormat(msgFormat, args);
        }

        public void Debug(string msg, Exception ex)
        {
            _logger.Debug(msg, ex);
        }

        public void Debug(Exception ex)
        {
            _logger.Debug(ex.Message, ex);
        }

        #endregion Debug

        #region Warn

        public void Warn(string msg)
        {
            _logger.Warn(msg);
        }

        public void WarnFormat(string msgFormat, params object[] args)
        {
            _logger.WarnFormat(msgFormat, args);
        }

        public void Warn(string msg, Exception ex)
        {
            _logger.Warn(msg, ex);
        }

        public void Warn(Exception ex)
        {
            _logger.Warn(ex.Message, ex);
        }

        #endregion Warn

        #region Error

        public void Error(string msg)
        {
            _logger.Error(msg);
        }

        public void ErrorFormat(string msgFormat, params object[] args)
        {
            _logger.ErrorFormat(msgFormat, args);
        }

        public void Error(string msg, Exception ex)
        {
            _logger.Error(msg, ex);
        }

        public void Error(Exception ex)
        {
            _logger.Error(ex.Message, ex);
        }

        #endregion Error

        #region Fatal

        public void Fatal(string msg)
        {
            _logger.Fatal(msg);
        }

        public void FatalFormat(string msgFormat, params object[] args)
        {
            _logger.FatalFormat(msgFormat, args);
        }

        public void Fatal(string msg, Exception ex)
        {
            _logger.Fatal(msg, ex);
        }

        public void Fatal(Exception ex)
        {
            _logger.Fatal(ex);
        }

        #endregion Fatal
    }

    public class LogHelper
    {
        private static ConcurrentDictionary<string, ILogProvider> _logProviders =
            new ConcurrentDictionary<string, ILogProvider>();

        private static readonly DefaultLogProvider DefaultLogProvider = new DefaultLogProvider();
        private readonly ILog _logger;

        public LogHelper(Type type)
        {
#if NET45
            _logger = LogManager.GetLogger(type);
#else
            _logger = LogManager.GetLogger(Assembly.GetEntryAssembly().FullName, type);
#endif
            DefaultLogProvider.Logger = _logger;
        }

        #region LogInit

        /// <summary>
        /// LogInit
        /// </summary>
        public static void LogInit()
        {
            DefaultLogProvider.LogInit();
        }

        public static void LogInit(string confFilePath)
        {
            DefaultLogProvider.LogInit(confFilePath);
        }

        public static void LogInit(IEnumerable<ILogProvider> logProviders)
        {
            DefaultLogProvider.LogInit();
            foreach (var provider in logProviders)
            {
                _logProviders.GetOrAdd(provider.GetType().FullName ?? provider.ToString(), provider);
            }
            foreach (var provider in _logProviders.Values)
            {
                provider.LogInit();
            }
        }

        public static void LogInit(string confFilePath, IEnumerable<ILogProvider> logProviders)
        {
            DefaultLogProvider.LogInit(confFilePath);
            foreach (var provider in logProviders)
            {
                _logProviders.GetOrAdd(provider.GetType().FullName ?? provider.ToString(), provider);
            }
            foreach (var provider in _logProviders.Values)
            {
                provider.LogInit();
            }
        }

        #endregion LogInit

        #region Info

        public void Info(string msg)
        {
            DefaultLogProvider.Info(msg);
            foreach (var provider in _logProviders.Values)
            {
                provider.Info(msg);
            }
        }

        public void InfoFormat(string msgFormat, params object[] args)
        {
            Info(String.Format(msgFormat, args));
        }

        public void Info(string msg, Exception ex)
        {
            DefaultLogProvider.Info(msg, ex);
            foreach (var provider in _logProviders.Values)
            {
                provider.Info(msg, ex);
            }
        }

        #endregion Info

        #region Debug

        public void Debug(string msg)
        {
            DefaultLogProvider.Debug(msg);
            foreach (var provider in _logProviders.Values)
            {
                provider.Debug(msg);
            }
        }

        public void DebugFormat(string msgFormat, params object[] args)
        {
            Debug(String.Format(msgFormat, args));
        }

        public void Debug(string msg, Exception ex)
        {
            DefaultLogProvider.Debug(msg, ex);
            foreach (var provider in _logProviders.Values)
            {
                provider.Debug(msg, ex);
            }
        }

        public void Debug(Exception ex)
        {
            Debug(ex.Message, ex);
        }

        #endregion Debug

        #region Warn

        public void Warn(string msg)
        {
            DefaultLogProvider.Warn(msg);
            foreach (var provider in _logProviders.Values)
            {
                provider.Warn(msg);
            }
        }

        public void WarnFormat(string msgFormat, params object[] args)
        {
            Warn(String.Format(msgFormat, args));
        }

        public void Warn(string msg, Exception ex)
        {
            DefaultLogProvider.Warn(msg, ex);
            foreach (var provider in _logProviders.Values)
            {
                provider.Warn(msg, ex);
            }
        }

        public void Warn(Exception ex)
        {
            Warn(ex.Message, ex);
        }

        #endregion Warn

        #region Error

        public void Error(string msg)
        {
            DefaultLogProvider.Error(msg);
            foreach (var provider in _logProviders.Values)
            {
                provider.Error(msg);
            }
        }

        public void ErrorFormat(string msgFormat, params object[] args)
        {
            Error(String.Format(msgFormat, args));
        }

        public void Error(string msg, Exception ex)
        {
            DefaultLogProvider.Error(msg, ex);
            foreach (var provider in _logProviders.Values)
            {
                provider.Error(msg, ex);
            }
        }

        public void Error(Exception ex)
        {
            Error(ex.Message, ex);
        }

        #endregion Error

        #region Fatal

        public void Fatal(string msg)
        {
            DefaultLogProvider.Fatal(msg);
            foreach (var provider in _logProviders.Values)
            {
                provider.Fatal(msg);
            }
        }

        public void FatalFormat(string msgFormat, params object[] args)
        {
            Fatal(String.Format(msgFormat, args));
        }

        public void Fatal(string msg, Exception ex)
        {
            DefaultLogProvider.Fatal(msg, ex);
            foreach (var provider in _logProviders.Values)
            {
                provider.Fatal(msg, ex);
            }
        }

        public void Fatal(Exception ex)
        {
            DefaultLogProvider.Fatal(ex);
            foreach (var provider in _logProviders.Values)
            {
                provider.Fatal(ex);
            }
        }

        #endregion Fatal
    }
}