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
        public static string ToSafeName(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            name = RemoveDiacritics(name);
            name = name.Strip(c =>
                !c.IsLetter()
                && !char.IsDigit(c)
                );

            name = name.Trim();

            // Don't allow non A-Z chars as first letter, as they are not allowed in prefixes.
            while (name.Length > 0 && !IsLetter(name[0]))
            {
                name = name[1..];
            }

            if (name.Length > 128)
            {
                name = name[..128];
            }

            return name;
        }
    }
}
