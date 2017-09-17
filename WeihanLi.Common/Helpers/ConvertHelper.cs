using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#if NET45
using System.Data;
#endif

using System.Reflection;

namespace WeihanLi.Common.Helpers
{
    public static class ConvertHelper
    {
#if NET45
        /// <summary>
        /// 利用反射和泛型
        /// </summary>
        /// <param name="dt">DataTable 对象</param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable dt) where T : class, new()
        {
            // 定义集合
            List<T> ts = new List<T>();

            // 获得此模型的类型
            Type type = typeof(T);
            //定义一个临时变量
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量
                    //检查DataTable是否包含此列（列名==对象的属性名）
                    if (dt.Columns.Contains(tempName))
                    {
                        //取值
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性
                        if (value != null)
                        {
                        }
                        pi.SetValue(t, value, null);
                    }
                }
                //对象添加到泛型集合中
                ts.Add(t);
            }

            return ts;
        }
#endif

        /// <summary>
        /// 将object对象转换为Json数据
        /// </summary>
        /// <param name="obj">object对象</param>
        /// <returns>转换后的json字符串</returns>
        public static string ObjectToJson(object obj)
        {
            if (obj == null)
            {
                return String.Empty;
            }
            return JsonConvert.SerializeObject(obj);
        }

        public static string ObjectToJson(object obj, JsonSerializerSettings serializerSettings)
        {
            if (obj == null)
            {
                return String.Empty;
            }
            if (serializerSettings == null)
            {
                return ObjectToJson(obj);
            }
            return JsonConvert.SerializeObject(obj, serializerSettings);
        }

        /// <summary>
        /// 将Json对象转换为T对象
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="jsonString">json对象字符串</param>
        /// <returns>由字符串转换得到的T对象</returns>
        public static T JsonToObject<T>(string jsonString)
        {
            if (String.IsNullOrEmpty(jsonString))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// 将int转换为bool类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ConvertIntToBool(int value)
        {
            return value > 0;
        }

        #region 转Int

        /// <summary>
        /// 将string类型转换成int类型
        /// </summary>
        /// <param name="s">目标字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int StringToInt(string s, int defaultValue = 0)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                int result;
                if (int.TryParse(s, out result))
                    return result;
            }

            return defaultValue;
        }

        /// <summary>
        /// 将object类型转换成int类型
        /// </summary>
        /// <param name="s">目标对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ObjectToInt(object o, int defaultValue = 0)
        {
            if (o != null)
                return StringToInt(o.ToString(), defaultValue);

            return defaultValue;
        }

        #endregion 转Int

        #region 转Bool

        /// <summary>
        /// 将string类型转换成bool类型
        /// </summary>
        /// <param name="s">目标字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static bool StringToBool(string s, bool defaultValue = false)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }
            if (s == "false")
            {
                return false;
            }
            else if (s == "true")
            {
                return true;
            }
            return defaultValue;
        }

        /// <summary>
        /// 将object类型转换成bool类型
        /// </summary>
        /// <param name="s">目标对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static bool ObjectToBool(object o, bool defaultValue = false)
        {
            if (o != null)
                return StringToBool(o.ToString(), defaultValue);

            return defaultValue;
        }

        #endregion 转Bool

        #region 转DateTime

        /// <summary>
        /// 将string类型转换成datetime类型
        /// </summary>
        /// <param name="s">目标字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime StringToDateTime(string s, DateTime defaultValue)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                DateTime result;
                if (DateTime.TryParse(s, out result))
                    return result;
            }
            return defaultValue;
        }

        /// <summary>
        /// 将string类型转换成datetime类型
        /// </summary>
        /// <param name="s">目标字符串</param>
        /// <returns></returns>
        public static DateTime StringToDateTime(string s)
        {
            return StringToDateTime(s, DateTime.Now);
        }

        /// <summary>
        /// 将object类型转换成datetime类型
        /// </summary>
        /// <param name="s">目标对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime ObjectToDateTime(object o, DateTime defaultValue)
        {
            if (o != null)
                return StringToDateTime(o.ToString(), defaultValue);

            return defaultValue;
        }

        /// <summary>
        /// 将object类型转换成datetime类型
        /// </summary>
        /// <param name="s">目标对象</param>
        /// <returns></returns>
        public static DateTime ObjectToDateTime(object o)
        {
            return ObjectToDateTime(o, DateTime.Now);
        }

        #endregion 转DateTime

        #region 转Decimal

        /// <summary>
        /// 将string类型转换成decimal类型
        /// </summary>
        /// <param name="s">目标字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static decimal StringToDecimal(string s, decimal defaultValue = 0)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                decimal result;
                if (decimal.TryParse(s, out result))
                    return result;
            }
            return defaultValue;
        }

        /// <summary>
        /// 将object类型转换成decimal类型
        /// </summary>
        /// <param name="s">目标对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static decimal ObjectToDecimal(object o, decimal defaultValue = 0)
        {
            if (o != null)
                return StringToDecimal(o.ToString(), defaultValue);

            return defaultValue;
        }

        #endregion 转Decimal
    }
}