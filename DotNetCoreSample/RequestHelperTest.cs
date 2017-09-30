﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WeihanLi.Common.Helpers;

namespace DotNetCoreSample
{
    class RequestHelperTest
    {
        private static readonly LogHelper Logger = new LogHelper(typeof(RequestHelperTest));

        public static void GetRequestParamTest()
        {            
            var param = GetParamInfo("https://www.baidu.com/?tn=47018152_dg");
            Debug.Assert(param.HasKeys());
            Debug.Assert(param.Count==1);
            
            param = GetParamInfo("http://tieba.baidu.com/f/index/forumpark?pcn=%E5%B0%8F%E8%AF%B4&pci=161&ct=0&rn=20&pn=1");
            Debug.Assert(param.HasKeys());
            Debug.Assert(param.Count == 5);

            param = GetParamInfo("https://www.baidu.com/?tn");
            Debug.Assert(param.HasKeys());

            param = GetParamInfo("https://www.baidu.com/?tn=");
            Debug.Assert(param["tn"]==String.Empty);
        }

        private static NameValueCollection GetParamInfo(string url)
        {
            var param = RequestHelper.GetParamCollection(url);
            Logger.DebugFormat("\n url:{0} \n param info:\n {1}", url,String.Join(",", param.AllKeys.Select(p => p + ":" + param.Get(p))));
            return param;
        }
    }
}
