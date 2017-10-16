using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// ReSharper disable once CheckNamespace
namespace WeihanLi.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IOExtension
    {
        /// <summary>
        ///     A Stream extension method that converts the Stream to a byte array.
        /// </summary>
        /// <param name="this">The Stream to act on.</param>
        /// <returns>The Stream as a byte[].</returns>
        public static byte[] ToByteArray(this Stream @this)
        {
            using (var ms = new MemoryStream())
            {
                @this.CopyTo(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        ///     A Stream extension method that reads a stream to the end.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>
        ///     The rest of the stream as a string, from the current position to the end. If the current position is at the
        ///     end of the stream, returns an empty string ("").
        /// </returns>
        public static string ReadToEnd(this Stream @this)
        {
            using (var sr = new StreamReader(@this, Encoding.Default))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        ///     A Stream extension method that reads a stream to the end.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>
        ///     The rest of the stream as a string, from the current position to the end. If the current position is at the
        ///     end of the stream, returns an empty string ("").
        /// </returns>
        public static string ReadToEnd(this Stream @this, Encoding encoding)
        {
            using (var sr = new StreamReader(@this, encoding))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        ///     Enumerates for each in this collection.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="action">The action.</param>
        /// <returns>An enumerator that allows foreach to be used to process for each in this collection.</returns>
        public static IEnumerable<FileInfo> ForEach(this IEnumerable<FileInfo> @this, Action<FileInfo> action)
        {
            foreach (FileInfo t in @this)
            {
                action(t);
            }
            return @this;
        }

        /// <summary>
        ///     Enumerates for each in this collection.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="action">The action.</param>
        /// <returns>An enumerator that allows foreach to be used to process for each in this collection.</returns>
        public static IEnumerable<DirectoryInfo> ForEach(this IEnumerable<DirectoryInfo> @this, Action<DirectoryInfo> action)
        {
            foreach (DirectoryInfo t in @this)
            {
                action(t);
            }
            return @this;
        }
    }
}