using System;
using WeihanLi.Common.Helpers;

namespace DotNetFxSample
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.LogInit(ConfigurationHelper.MapPath("log4net.config"));
            Console.WriteLine("----------DotNetFxSample----------");
            ConfigurationHelperTest.TestConfigurationHelper();
            Console.ReadLine();
        }
    }
}
