using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kitaprazzi.Core.Helper
{
    public static class TextHelper
    {
        public static string ClearForUrl(string text, bool toLowercase = true)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            text = RemoveDiacritics(text, toLowercase);
            text = Regex.Replace(text, @"[()""'‘’“”]", " ");
            text = Regex.Replace(text, "[^a-z0-9]", " ", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"\s+", " ");
            text = text.Trim();
            text = text.Replace(" ", "-");
            return text;
        }

        public static string RemoveDiacritics(string text, bool toLowerCase = false)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            Encoding srcEncoding = Encoding.UTF8;
            Encoding destEncoding = Encoding.GetEncoding(1252); // Latin alphabet

            text = destEncoding.GetString(Encoding.Convert(srcEncoding, destEncoding, srcEncoding.GetBytes(text)));

            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                if (!CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]).Equals(UnicodeCategory.NonSpacingMark))
                {
                    result.Append(normalizedString[i]);
                }
            }

            return toLowerCase ? result.ToString().ToLowerInvariant() : result.ToString();
        }
    }
}
