using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Comparer
{
    [Flags]
    internal enum ComparisonResult
    {
        Equal = 0,
        ChildMissingFieldDifference = 1,
        ChildMetadataDifference = 2,
        ChildDifference = 4,
        MetadataDifference = 8,
        TypeDifference = 16,
        NullableDifference = 32,
        ContainsNullDifference = 64,
        MissingField = 128
    }
}
