/*
 * Copyright 2023 PetterPet
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaggleAPI.Web.Helpers
{
    internal static class Helper
    {
        //internal static void AddMessage(this KaggleStatus Status, params string[] messages)
        //{
        //    if (Status.InternalMessage == null)
        //        Status.InternalMessage = new List<string>();
        //    Status.InternalMessage.AddRange(messages);
        //}

        //internal static void AddMessage(this KaggleStatus Status, IEnumerable<string> messages)
        //{
        //    if (Status.InternalMessage == null)
        //        Status.InternalMessage = new List<string>();
        //    Status.InternalMessage.AddRange(messages);
        //}

        internal static string RemapInternationalCharToAscii(char c)
        {
            string s = c.ToString().ToLowerInvariant();
            if ("àåáâäãåą".Contains(s))
            {
                return "a";
            }
            else if ("èéêëę".Contains(s))
            {
                return "e";
            }
            else if ("ìíîïı".Contains(s))
            {
                return "i";
            }
            else if ("òóôõöøőð".Contains(s))
            {
                return "o";
            }
            else if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }
            else if ("çćčĉ".Contains(s))
            {
                return "c";
            }
            else if ("żźž".Contains(s))
            {
                return "z";
            }
            else if ("śşšŝ".Contains(s))
            {
                return "s";
            }
            else if ("ñń".Contains(s))
            {
                return "n";
            }
            else if ("ýÿ".Contains(s))
            {
                return "y";
            }
            else if ("ğĝ".Contains(s))
            {
                return "g";
            }
            else if (c == 'ř')
            {
                return "r";
            }
            else if (c == 'ł')
            {
                return "l";
            }
            else if (c == 'đ')
            {
                return "d";
            }
            else if (c == 'ß')
            {
                return "ss";
            }
            else if (c == 'Þ')
            {
                return "th";
            }
            else if (c == 'ĥ')
            {
                return "h";
            }
            else if (c == 'ĵ')
            {
                return "j";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Produces optional, URL-friendly version of a title, "like-this-one".
        /// hand-tuned for speed, reflects performance refactoring contributed
        /// by John Gietzen (user otac0n)
        /// </summary>
        /// Sauce: https://stackoverflow.com/questions/25259/how-does-stack-overflow-generate-its-seo-friendly-urls
        internal static string URLFriendly(string title)
        {
            if (title == null)
                return "";

            const int maxlen = 80;
            int len = title.Length;
            bool prevdash = false;
            var sb = new StringBuilder(len);
            char c;

            for (int i = 0; i < len; i++)
            {
                c = title[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
                    prevdash = false;
                }
                else if (
                    c == ' '
                    || c == ','
                    || c == '.'
                    || c == '/'
                    || c == '\\'
                    || c == '-'
                    || c == '_'
                    || c == '='
                )
                {
                    if (!prevdash && sb.Length > 0)
                    {
                        sb.Append('-');
                        prevdash = true;
                    }
                }
                else if ((int)c >= 128)
                {
                    int prevlen = sb.Length;
                    sb.Append(RemapInternationalCharToAscii(c));
                    if (prevlen != sb.Length)
                        prevdash = false;
                }
                if (i == maxlen)
                    break;
            }

            if (prevdash)
                return sb.ToString().Substring(0, sb.Length - 1);
            else
                return sb.ToString();
        }

        internal static string Stringify(this IEnumerable<string> strings)
        {
            return $"['{string.Join("', '", strings)}']";
        }

        internal static bool TryGetKey<K, V>(this IDictionary<K, V> instance, V value, out K key)
        {
            foreach (var entry in instance)
            {
                if (!Equals(entry.Value, value))
                {
                    continue;
                }
                key = entry.Key;
                return true;
            }
            key = default(K);
            return false;
        }

        internal static bool TryGetKey<K, V>(
            this IDictionary<K, V> instance,
            V value,
            out IEnumerable<K> keys
        )
        {
            keys = instance.Where(x => Equals(x.Value, value)).Select(x => x.Key);
            if (keys.Count() == 0)
                return false;
            return true;
        }
    }
}
