using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Utils
{
    internal class StringEqualityComparer : IEqualityComparer<string>
    {
        private bool IgnoreCase { get; }

        internal StringEqualityComparer(bool ignoreCase)
        {
            IgnoreCase = ignoreCase;
        }

        public bool Equals(string? x, string? y)
        {
            return x != null && y != null && x.Equals(y, IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
