using System.Net;
using Cysharp.Text;

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

            // name = RemoveDiacritics(name);
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

        public static string HtmlClassify(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            var friendlier = text.CamelFriendly();

            var result = new char[friendlier.Length];

            var cursor = 0;
            var previousIsNotLetter = false;
            for (var i = 0; i < friendlier.Length; i++)
            {
                var current = friendlier[i];
                if (IsLetter(current) || (char.IsDigit(current) && cursor > 0))
                {
                    if (previousIsNotLetter && i != 0 && cursor > 0)
                    {
                        result[cursor++] = '-';
                    }

                    result[cursor++] = char.ToLowerInvariant(current);
                    previousIsNotLetter = false;
                }
                else
                {
                    previousIsNotLetter = true;
                }
            }

            return new string(result, 0, cursor);
        }

        public static bool IsLetter(this char c)
        {
            return ('A' <= c && c <= 'Z') || ('a' <= c && c <= 'z');
        }

        public static bool IsSpace(this char c)
        {
            return (c == '\r' || c == '\n' || c == '\t' || c == '\f' || c == ' ');
        }

        public static string Strip(this string subject, Func<char, bool> predicate)
        {
            var result = new char[subject.Length];

            var cursor = 0;
            for (var i = 0; i < subject.Length; i++)
            {
                var current = subject[i];
                if (!predicate(current))
                {
                    result[cursor++] = current;
                }
            }

            return new string(result, 0, cursor);
        }

        public static string CamelFriendly(this string camel)
        {
            // Optimize common cases.
            if (string.IsNullOrWhiteSpace(camel))
            {
                return "";
            }

            using var sb = ZString.CreateStringBuilder();
            for (var i = 0; i < camel.Length; ++i)
            {
                var c = camel[i];
                if (i != 0 && char.IsUpper(c))
                {
                    sb.Append(' ');
                }
                sb.Append(c);
            }

            return sb.ToString();
        }


        public static string Translate(this string subject, char[] from, char[] to)
        {
            if (string.IsNullOrEmpty(subject))
            {
                return subject;
            }

            ArgumentNullException.ThrowIfNull(from);

            ArgumentNullException.ThrowIfNull(to);

            if (from.Length != to.Length)
            {
                throw new ArgumentNullException(nameof(from), "Parameters must have the same length");
            }

            var map = new Dictionary<char, char>(from.Length);
            for (var i = 0; i < from.Length; i++)
            {
                map[from[i]] = to[i];
            }

            var result = new char[subject.Length];

            for (var i = 0; i < subject.Length; i++)
            {
                var current = subject[i];
                if (map.TryGetValue(current, out var value))
                {
                    result[i] = value;
                }
                else
                {
                    result[i] = current;
                }
            }

            return new string(result);
        }

        public static string ToPascalCase(this string attribute, char upperAfterDelimiter)
        {
            attribute = attribute.Trim();

            var delimitersCount = 0;

            for (var i = 0; i < attribute.Length; i++)
            {
                if (attribute[i] == upperAfterDelimiter)
                {
                    delimitersCount++;
                }
            }

            var result = string.Create(attribute.Length - delimitersCount, new { attribute, upperAfterDelimiter }, (buffer, state) =>
            {
                var nextIsUpper = true;
                var k = 0;

                for (var i = 0; i < state.attribute.Length; i++)
                {
                    var c = state.attribute[i];

                    if (c == state.upperAfterDelimiter)
                    {
                        nextIsUpper = true;
                        continue;
                    }

                    if (nextIsUpper)
                    {
                        buffer[k] = char.ToUpperInvariant(c);
                    }
                    else
                    {
                        buffer[k] = c;
                    }

                    nextIsUpper = false;

                    k++;
                }
            });

            return result;
        }

        public static string Strip(this string subject, params char[] stripped)
        {
            if (stripped == null || stripped.Length == 0 || string.IsNullOrEmpty(subject))
            {
                return subject;
            }

            var result = new char[subject.Length];

            var cursor = 0;
            for (var i = 0; i < subject.Length; i++)
            {
                var current = subject[i];
                if (Array.IndexOf(stripped, current) < 0)
                {
                    result[cursor++] = current;
                }
            }

            return new string(result, 0, cursor);
        }

        // public async Task<string> GetContentItemIdFromRouteAsync(PathString url)
        // {
        //     if (!url.HasValue)
        //     {
        //         url = "/";
        //     }

        //     string contentItemId = null;

        //     if (url == "/")
        //     {
        //         // get contentItemId from homeroute
        //         var siteSettings = await _siteService.GetSiteSettingsAsync();
        //         contentItemId = siteSettings.HomeRoute["contentItemId"]?.ToString();
        //     }
        //     else
        //     {
        //         // Try to get from autorouteEntries.
        //         // This should not consider contained items, so will redirect to the parent item.
        //         (var found, var entry) = await _autorouteEntries.TryGetEntryByPathAsync(url.Value);

        //         if (found)
        //         {
        //             contentItemId = entry.ContentItemId;
        //         }
        //     }

        //     if (string.IsNullOrEmpty(contentItemId))
        //     {
        //         return null;
        //     }

        //     return contentItemId;
        // }

    }
}
