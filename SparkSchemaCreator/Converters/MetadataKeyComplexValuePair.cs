using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SparkSchemaCreator.Converters
{
    [DisplayName("Key-Value Complex Item")]
    internal class MetadataKeyComplexValuePair(string key, object? value, Type type, HashSet<string> keys) : MetadataKeyValuePair(key, value, type, keys)
    {
    }
}
