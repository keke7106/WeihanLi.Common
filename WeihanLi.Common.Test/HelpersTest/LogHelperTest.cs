using System;
using System.Collections.Generic;
using System.Text;
using WeihanLi.Common.Helpers;

namespace WeihanLi.Common.Test.HelpersTest
{
    public class LogHelperTest
    {
        private static LogHelper logger = new LogHelper(typeof(LogHelperTest));

        static LogHelperTest()
        {
            LogHelper.LogInit();
        }
    }
}
