using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Utils
{
    internal static class StringExtender
    {
        public static string? Capitalize(this string? text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            char[] chars = text.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return new string(chars);
        }
    }
}
