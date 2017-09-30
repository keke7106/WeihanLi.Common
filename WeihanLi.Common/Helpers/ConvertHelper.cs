using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

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
            return dt.ToEntities<T>();
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
    }
}