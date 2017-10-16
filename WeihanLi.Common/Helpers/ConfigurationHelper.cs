using System;
using System.Collections.Specialized;
using System.Configuration;
using WeihanLi.Extensions;

namespace WeihanLi.Common.Helpers
{
    public static class ConfigurationHelper
    {
        /// <summary>
        /// 应用根目录
        /// </summary>
#if NET45
        private static readonly string AppRoot = System.Web.Hosting.HostingEnvironment.IsHosted ? System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath : AppDomain.CurrentDomain.BaseDirectory;
#else
        private static readonly string AppRoot = AppDomain.CurrentDomain.BaseDirectory;
#endif
        private static readonly NameValueCollection AppSettings;

        static ConfigurationHelper()
        {
            AppSettings = ConfigurationManager.AppSettings;
        }

        /// <summary>
        /// 获取配置文件中AppSetting节点的相对路径对应的绝对路径
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>绝对路径</returns>
        public static string AppSettingMapPath(string key)
        {
            return AppRoot + AppSetting(key);
        }

        /// <summary>
        /// 将虚拟路径转换为物理路径，相对路径转换为绝对路径
        /// </summary>
        /// <param name="virtualPath">虚拟路径</param>
        /// <returns>虚拟路径对应的物理路径</returns>
        public static string MapPath(string virtualPath)
        {
            return AppRoot + virtualPath;
        }

        /// <summary>
        /// 获取配置文件中AppSetting节点的值
        /// </summary>
        /// <param name="key">设置的键值</param>
        /// <returns>键值对应的值</returns>
        public static string AppSetting(string key)
        {
            return AppSettings[key];
        }

        /// <summary>
        /// 获取配置文件中AppSetting节点的值
        /// </summary>
        /// <param name="key">设置的键值</param>
        /// <param name="defaultValue">key不存在时默认值</param>
        /// <returns>键值对应的值</returns>
        public static string AppSetting(string key, string defaultValue)
        {
            return AppSettings[key] ?? defaultValue;
        }

        /// <summary>
        /// 获取配置文件中AppSetting节点的值
        /// </summary>
        /// <param name="key">设置的键值</param>
        /// <returns>键值对应的值</returns>
        public static T AppSetting<T>(string key)
        {
            return AppSettings[key].To<T>();
        }

        public static T AppSetting<T>(string key, T defaultValue)
        {
            return AppSettings[key].ToOrDefault(defaultValue);
        }

        public static T AppSetting<T>(string key, Func<T> defaultValueFactory)
        {
            return AppSettings[key].ToOrDefault(defaultValueFactory);
        }

        /// <summary>
        /// 获取配置文件中ConnectionStrings节点的值
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns>键值对应的连接字符串值</returns>
        public static string ConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}