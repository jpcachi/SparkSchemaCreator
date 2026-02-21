using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Utils
{
    internal record NameWithDataType(string Name, DataType DataType) : ITreeElement
    {
        public ComplexType? GetParent()
        {
            if (DataType.ArrayParent != null)
                return DataType.ArrayParent;

            if (DataType.MapParent != null)
                return DataType.MapParent;

            return null;
        }
    }
}
