using System.IO;
using System.Text;

namespace System.Net
{
    public static class NetExtension
    {
        /// <summary>
        ///     A WebRequest extension method that gets the WebRequest response or the WebException response.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The WebRequest response or WebException response.</returns>
        public static WebResponse GetResponseSafe(this WebRequest @this)
        {
            try
            {
                return @this.GetResponse();
            }
            catch (WebException e)
            {
                return e.Response;
            }
        }

        /// <summary>
        ///     A WebResponse extension method that reads the response stream to the end.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The response stream as a string, from the current position to the end.</returns>
        public static string ReadToEnd(this WebResponse @this)
        {
            using (WebResponse response = @this)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, Encoding.Default))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}