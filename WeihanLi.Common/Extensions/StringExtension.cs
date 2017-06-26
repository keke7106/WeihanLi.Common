using System;
using System.Collections.Generic;
using System.Text;

namespace WeihanLi.Common.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 去除多余文本，保留 @length 长度，如果长度小于 @length 则
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="length">保留字符串长度</param>
        /// <returns></returns>
        public static string TrimText(this string str, int length)
        {
            if (str.Length > length)
            {
                return str.Substring(0, length - 1) + "...";
            }
            else
            {
                return str;
            }
        }
    }
}
