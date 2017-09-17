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
        public void AppSettingsModelTest()
        {
            var val = Helpers.ConfigurationHelper.AppSetting<SimplePersonModel>("key2");
            Assert.NotNull(val);
        }
    }

    public class SimplePersonModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
