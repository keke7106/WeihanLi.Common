using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WeihanLi.Common.Helpers
{
    /// <summary>
    /// HTTP请求帮助类
    /// </summary>
    public static class HttpHelper
    {
        /// <summary>
        /// HTTP GET请求，返回字符串
        /// </summary>
        /// <param name="url"> url </param>
        /// <returns></returns>
        public static string HttpGetString(string url)
        {
            Uri uri = new Uri(url, UriKind.Absolute);
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            request.Method = "GET";
            return request.GetResponseSafe().ReadToEnd();
        }

        /// <summary>
        /// HTTP POST 请求，返回字符串
        /// </summary>
        /// <param name="url"> url </param>
        /// <param name="parameters"> post数据字典 </param>
        /// <param name="queryStringExist"> 是否存在GET请求参数 </param>
        /// <returns></returns>
        public static string HttpGetString(string url, Dictionary<string, string> parameters, bool queryStringExist = false)
        {
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder sbParameters = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        sbParameters.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        if (queryStringExist)
                        {
                            sbParameters.AppendFormat("&{0}={1}", key, parameters[key]);
                        }
                        else
                        {
                            sbParameters.AppendFormat("?{0}={1}", key, parameters[key]);
                        }
                        i++;
                    }
                }
                if (sbParameters.Length > 0)
                {
                    url = url + sbParameters.ToString();
                }
            }
            Uri uri = new Uri(url, UriKind.Absolute);
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            request.Method = "GET";
            return request.GetResponseSafe().ReadToEnd();
        }

        /// <summary>
        /// HTTP POST 请求，返回字符串
        /// </summary>
        /// <param name="url"> url </param>
        /// <param name="parameters"> post数据字典 </param>
        /// <returns></returns>
        public static string HttpPostString(string url, Dictionary<string, string> parameters)
        {
            Uri uri = new Uri(url, UriKind.Absolute);
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            request.Method = "POST";
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        i++;
                    }
                }
                byte[] postData = Encoding.UTF8.GetBytes(buffer.ToString());
                var postStream = request.GetRequestStream();
                postStream.Write(postData, 0, postData.Length);
            }
            return request.GetResponseSafe().ReadToEnd();
        }

        /// <summary>
        /// Http
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HttpPostJson<T>(string url, T data)
        {
            return HttpPostForString(url, Encoding.UTF8.GetBytes(ConvertHelper.ObjectToJson(data)), true);
        }


        public static string HttpPostJson<T>(string url, T data, Encoding encoding)
        {
            return HttpPostForString(url, encoding.GetBytes(ConvertHelper.ObjectToJson(data)), true);
        }

        public static TResponse HttpPostJsonFor<TRequest, TResponse>(string url, TRequest data)
        {
            return HttpPostFor<TResponse>(url, Encoding.UTF8.GetBytes(ConvertHelper.ObjectToJson(data)), true);
        }

        public static TResponse HttpPostJsonFor<TRequest,TResponse>(string url, TRequest data, Encoding encoding)
        {
            return HttpPostFor<TResponse>(url, encoding.GetBytes(ConvertHelper.ObjectToJson(data)), true);
        }


        /// <summary>
        /// HTTP POST 请求，返回字符串
        /// </summary>
        /// <param name="url"> url </param>
        /// <param name="postData"> post数据 </param>
        /// <param name="isJsonFormat"> 是否是json格式数据 </param>
        /// <returns></returns>
        public static string HttpPostForString(string url, byte[] postData, bool isJsonFormat = true)
        {
            Uri uri = new Uri(url, UriKind.Absolute);
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            request.Method = "POST";
            if (isJsonFormat)
            {
                request.ContentType = "application/json;charset=UTF-8";
            }
            var postStream = request.GetRequestStream();
            postStream.Write(postData, 0, postData.Length);
            return request.GetResponseSafe().ReadToEnd();
        }
        
        public static T HttpPostFor<T>(string url, byte[] postData, bool isJsonFormat)
        {
            Uri uri = new Uri(url, UriKind.Absolute);
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            request.Method = "POST";
            if (isJsonFormat)
            {
                request.ContentType = "application/json;charset=UTF-8";
            }
            var postStream = request.GetRequestStream();
            postStream.Write(postData, 0, postData.Length);
            return ConvertHelper.JsonToObject<T>(request.GetResponseSafe().ReadToEnd());
        }

        public static byte[] HttpPostForBytes(string url, byte[] postData,bool isJsonFormat)
        {
            Uri uri = new Uri(url, UriKind.Absolute);
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            request.Method = "POST";
            if (isJsonFormat)
            {
                request.ContentType = "application/json;charset=UTF-8";
            }
            var postStream = request.GetRequestStream();
            postStream.Write(postData, 0, postData.Length);
            return request.GetResponseSafe().ReadAllBytes();
        }
    }
}