using System.Net;

namespace LocalFiles.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToPath(this string link)
        {
            return WebUtility.UrlDecode(link).Replace("localfile://", string.Empty).Replace('/', '\\');
        }
    }
}
