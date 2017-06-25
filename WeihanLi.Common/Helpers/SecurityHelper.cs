using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WeihanLi.Common.Helpers
{
    /// <summary>
    /// 安全助手
    /// </summary>
    public static class SecurityHelper
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="sourceString">原字符串</param>
        /// <returns>加密后字符串</returns>
        public static string MD5_Encrypt(string sourceString, bool isLower = false)
        {
            if (String.IsNullOrEmpty(sourceString))
            {
                return "";
            }
            return HashHelper.GetHashedString(HashType.MD5, sourceString, isLower);
        }

        /// <summary>
        /// use sha1 to encrypt string
        /// </summary>
        public static string SHA1_Encrypt(string sourceString, bool isLower = false)
        {
            if (String.IsNullOrEmpty(sourceString))
            {
                return "";
            }
            return HashHelper.GetHashedString(HashType.SHA1, sourceString, isLower);
        }

        /// <summary>
        /// SHA256 加密
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string SHA256_Encrypt(string sourceString, bool isLower = false)
        {
            if (String.IsNullOrEmpty(sourceString))
            {
                return "";
            }
            return HashHelper.GetHashedString(HashType.SHA256, sourceString, isLower);
        }

        /// <summary>
        /// SHA512_加密
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string SHA512_Encrypt(string sourceString, bool isLower = false)
        {
            if (String.IsNullOrEmpty(sourceString))
            {
                return "";
            }
            return HashHelper.GetHashedString(HashType.SHA512, sourceString, isLower);
        }
    }

    /// <summary>
    /// HashHelper
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// 计算字符串Hash值
        /// </summary>
        /// <param name="type">hash类型</param>
        /// <param name="str">要hash的字符串</param>
        /// <returns>hash过的字节数组</returns>
        public static byte[] GetHashedBytes(HashType type, string str) => GetHashedBytes(type, str, Encoding.UTF8);

        /// <summary>
        /// 计算字符串Hash值
        /// </summary>
        /// <param name="type">hash类型</param>
        /// <param name="str">要hash的字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <returns>hash过的字节数组</returns>
        public static byte[] GetHashedBytes(HashType type, string str, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(str);
            return GetHashedBytes(type, bytes);
        }

        /// <summary>
        /// 获取哈希之后的字符串
        /// </summary>
        /// <param name="type">哈希类型</param>
        /// <param name="str">源字符串</param>
        /// <returns>哈希算法处理之后的字符串</returns>
        public static string GetHashedString(HashType type, string str) => GetHashedString(type, str, Encoding.UTF8, false);

        /// <summary>
        /// 获取哈希之后的字符串
        /// </summary>
        /// <param name="type">哈希类型</param>
        /// <param name="str">源字符串</param>
        /// <param name="isLower">是否是小写</param>
        /// <returns>哈希算法处理之后的字符串</returns>
        public static string GetHashedString(HashType type, string str, bool isLower) => GetHashedString(type, str, Encoding.UTF8, isLower);

        /// <summary>
        /// 获取哈希之后的字符串
        /// </summary>
        /// <param name="type">哈希类型</param>
        /// <param name="str">源字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <param name="isLower">是否是小写</param>
        /// <returns>哈希算法处理之后的字符串</returns>
        public static string GetHashedString(HashType type, string str, Encoding encoding, bool isLower = false)
        {
            byte[] hashedBytes = GetHashedBytes(type, str, encoding);
            StringBuilder sbText = new StringBuilder();
            if (isLower)
            {
                foreach (byte b in hashedBytes)
                {
                    sbText.Append(b.ToString("x2"));
                }
            }
            else
            {
                foreach (byte b in hashedBytes)
                {
                    sbText.Append(b.ToString("X2"));
                }
            }
            return sbText.ToString();
        }

        /// <summary>
        /// 获取Hash后的字节数组
        /// </summary>
        /// <param name="type">哈希类型</param>
        /// <param name="bytes">原字节数组</param>
        /// <returns></returns>
        public static byte[] GetHashedBytes(HashType type, byte[] bytes)
        {
            HashAlgorithm algorithm;
            switch (type)
            {
                case HashType.MD5:
                    algorithm = MD5.Create();
                    break;

                case HashType.SHA1:
                    algorithm = SHA1.Create();
                    break;

                case HashType.SHA256:
                    algorithm = SHA256.Create();
                    break;

                case HashType.SHA384:
                    algorithm = SHA384.Create();
                    break;

                case HashType.SHA512:
                    algorithm = SHA512.Create();
                    break;

                default:
                    algorithm = MD5.Create();
                    break;
            }
            byte[] hashedBytes = algorithm.ComputeHash(bytes);
            algorithm.Dispose();
            return hashedBytes;
        }
    }

    /// <summary>
    /// Hash 类型
    /// </summary>
    public enum HashType
    {
        /// <summary>
        /// MD5
        /// </summary>
        MD5 = 0,
        /// <summary>
        /// SHA1
        /// </summary>
        SHA1 = 1,
        /// <summary>
        /// SHA256
        /// </summary>
        SHA256 = 2,
        /// <summary>
        /// SHA384
        /// </summary>
        SHA384 = 3,
        /// <summary>
        /// SHA512
        /// </summary>
        SHA512 = 4
    }
}
