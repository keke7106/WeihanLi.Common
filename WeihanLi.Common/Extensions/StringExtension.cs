using System;
using System.Collections.Generic;
using System.Text;

namespace System
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

        /// <summary>
        /// 字符串重复扩展方法 
        /// </summary>
        /// <param name="str"> 要重复的字符串 </param>
        /// <param name="repeatCount"> 重复次数 </param>
        /// <returns></returns>
        public static string Multiple(this string str, int repeatCount)
        {
            if (String.IsNullOrEmpty(str) || repeatCount <= 0)
            {
                return "";
            }
            StringBuilder sbText = new StringBuilder();
            for (int i = 0; i < repeatCount; i++)
            {
                sbText.Append(str);
            }
            return sbText.ToString();
        }

        /// <summary>
        /// 忽略大小写比较两个字符串
        /// </summary>
        /// <param name="s1">字符串1</param>
        /// <param name="s2">字符串2</param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string s1, string s2)
        {
            return string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);
        }
    }
}
