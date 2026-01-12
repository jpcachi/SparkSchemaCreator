using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Types
{
    internal class StringConcat
    {
        protected readonly List<string> strings;
        protected int length;

        internal readonly int maxLength;

        internal StringConcat(int maxLength = int.MaxValue - 15) { 

            strings = [];
            this.maxLength = maxLength;
            length = 0;
        }

        internal bool AtLimit() => length >= maxLength;

        internal void Append(string? s)
        {
            if (s == null)
                return;

            int sLen = s.Length;
            if(!AtLimit())
            {
                int available = maxLength - length;
                string stringToAppend = available >= sLen ? s : s[..available];
                strings.Add(stringToAppend);
            }

            length = Math.Min(length + sLen, int.MaxValue - 15);

        }

        public override string ToString()
        {
            int finalLength = AtLimit() ? maxLength : length;
            StringBuilder result = new(finalLength);
            strings.ForEach(s => result.Append(s));
            return result.ToString();
        }
    }
}
