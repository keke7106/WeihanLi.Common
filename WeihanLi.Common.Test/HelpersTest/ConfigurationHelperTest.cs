using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WeihanLi.Common.Test.HelpersTest
{
    public class ConfigurationHelperTest
    {
        [Fact]
        public void AppSettingsTest()
        {
            var val = Helpers.ConfigurationHelper.AppSetting("key1");
            Assert.NotEmpty(val);
        }

        [Fact]
        public void AppSettingsToTest()
        {
            var val = Helpers.ConfigurationHelper.AppSetting<int>("key2");
            Assert.Equal(1,val);
            Assert.True(Helpers.ConfigurationHelper.AppSetting<bool>("key2"));
        }
    }
}
