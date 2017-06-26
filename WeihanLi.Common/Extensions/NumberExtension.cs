using System;
using System.Collections.Generic;
using System.Text;

namespace WeihanLi.Common.Extensions
{
    public static class NumberExtension
    {
        #region 数字格式修改
        /// <summary>
        /// 数字转换为百分比显示
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="digits">精度，保留几位小数</param>
        /// <returns></returns>
        public static string Number2Percent(this double number, int digits = 2)
        {
            if (digits < 0 || digits > 15)
            {
                digits = 2;
            }
            double bValue = Math.Round(number, digits + 2);
            bValue = bValue * 100;
            return bValue.ToString("0.00") + "%";
        }

        /// <summary>
        /// 数字转换为百分比显示
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="digits">精度，保留几位小数</param>
        /// <returns></returns>
        public static string Number2Percent(this decimal number, int digits = 2)
        {
            if (digits < 0 || digits > 15)
            {
                digits = 2;
            }
            decimal bValue = Math.Round(number, digits + 2);
            bValue = bValue * 100;
            return bValue.ToString("0.00") + "%";
        }
        /// <summary>
        /// 转换为指定位数小数
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="digits">精度，保留小数点位数</param>
        /// <returns></returns>
        public static decimal Round(this decimal number, int digits = 2)
        {
            return Math.Round(number, 2);
        }
        /// <summary>
        /// 转换为指定位数小数
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="digits">精度，保留小数点位数</param>
        /// <returns></returns>
        public static double Round(this double number, int digits = 2)
        {
            return Math.Round(number, 2);
        }
        #endregion
    }
}
