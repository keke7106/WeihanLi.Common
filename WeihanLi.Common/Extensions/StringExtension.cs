using System;

namespace WeihanLi.Common.Extensions
{
    public static class StringExtension
    {
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