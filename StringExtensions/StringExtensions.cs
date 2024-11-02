using System.Net;

namespace StringExtensions
{
    public static class HtmlExtensions
    {
        public static string RemoveTags(this string html, bool htmlDecode = false)
        {
            if (string.IsNullOrEmpty(html))
            {
                return string.Empty;
            }

            var result = new char[html.Length];
            var cursor = 0;
            var inside = false;

            for (var i = 0; i < html.Length; i++)
            {
                var current = html[i];

                switch (current)
                {
                    case '<':
                        inside = true;
                        continue;
                    case '>':
                        inside = false;
                        continue;
                }

                if (!inside)
                {
                    result[cursor++] = current;
                }
            }

            var stringResult = new string(result, 0, cursor);

            if (htmlDecode)
            {
                stringResult = WebUtility.HtmlDecode(stringResult);
            }

            return stringResult;
        }
    }
}
