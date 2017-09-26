using System;
using WeihanLi.Common.Helpers;

namespace DotNetCoreSample
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.LogInit(ConfigurationHelper.MapPath("log4net.config"));
            Console.WriteLine("----------DotNetCoreSample----------");
            ConfigurationHelperTest.TestConfigurationHelper();

            Console.ReadLine();
        }        
    }
}
