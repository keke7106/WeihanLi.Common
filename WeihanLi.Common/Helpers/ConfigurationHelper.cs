using System.Configuration;

#if NET45
using System.Web.Configuration;
#endif

namespace WeihanLi.Common.Helpers
{
    public class ConfigurationHelper
    {
#if NET45
        /// <summary>
        /// 网站根路径
        /// </summary>
        private static string siteroot = System.Web.Hosting.HostingEnvironment.MapPath("~/");

        /// <summary>
        /// 获取配置文件中AppSetting节点的相对路径对应的绝对路径
        /// </summary>
        /// <param name="key">相对路径设置的键值</param>
        /// <returns>绝对路径</returns>
        public static string AppSettingMapPath(string key)
        {
            //拼接路径
            string path = siteroot + AppSetting(key);
            return path;
        }

        /// <summary>
        /// 将虚拟路径转换为物理路径
        /// </summary>
        /// <param name="virtualPath">虚拟路径</param>
        /// <returns>虚拟路径对应的物理路径</returns>
        public static string MapPath(string virtualPath)
        {
            return siteroot + virtualPath;
        }
#endif

        /// <summary>
        /// 获取配置文件中AppSetting节点的值
        /// </summary>
        /// <param name="key">设置的键值</param>
        /// <returns>键值对应的值</returns>
        public static string AppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }

        /// <summary>
        /// 获取配置文件中AppSetting节点的值
        /// </summary>
        /// <param name="key">设置的键值</param>
        /// <returns>键值对应的值</returns>
        public static T AppSetting<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (value == null)
            {
                return default(T);
            }
            return ConvertHelper.JsonToObject<T>(key);
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