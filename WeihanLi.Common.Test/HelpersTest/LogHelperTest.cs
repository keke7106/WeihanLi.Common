using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using WeihanLi.Common.Helpers;
using Xunit;

namespace WeihanLi.Common.Test.HelpersTest
{
    public class LogHelperTest
    {
        private static readonly LogHelper Logger = new LogHelper(typeof(LogHelperTest));

        static LogHelperTest()
        {
            
        }

        [Fact]
        public void Info()
        {
            var confFilePath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) +
                               "\\log4net.config";
            LogHelper.LogInit(confFilePath);

            Logger.Info("12333");
            Logger.Warn("12333");
            Logger.Error("12333");
            Logger.Fatal("1234555");
        }
    }
}
