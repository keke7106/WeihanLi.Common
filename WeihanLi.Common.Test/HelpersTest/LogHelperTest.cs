using System;
using System.Collections.Generic;
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
            LogHelper.LogInit();
        }

        [Fact]
        public void Info()
        {
            Logger.Info("12333");
        }
    }
}
