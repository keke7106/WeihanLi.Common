using System;
using WeihanLi.Common.Helpers;

namespace DotNetFxSample
{
    class ConfigurationHelperTest
    {
        private static readonly LogHelper Logger = new LogHelper(typeof(ConfigurationHelperTest));
        public static void TestConfigurationHelper()
        {
            var key1 = ConfigurationHelper.AppSetting("key1");
            var key2 = ConfigurationHelper.AppSetting<int>("key2");
            var key3 = ConfigurationHelper.AppSetting<bool>("key3");
            var path = ConfigurationHelper.AppSettingMapPath("log4net");
            Console.WriteLine($"key1:{key1},key2:{key2},key3:{key3},path:{path}");
            Logger.Debug($"key1:{key1},key2:{key2},key3:{key3},path:{path}");
        }
    }
}
