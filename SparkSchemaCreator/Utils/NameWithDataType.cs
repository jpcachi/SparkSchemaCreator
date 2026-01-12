using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Utils
{
    internal class NameWithDataType
    {
        public string Name { get; }
        public DataType DataType { get; set; }

        internal NameWithDataType(string name, DataType dataType)
        {
            Name = name; DataType = dataType; 
        }

        public override bool Equals(object? obj)
        {
            return obj is NameWithDataType other && Name == other.Name && DataType == other.DataType;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ DataType.GetHashCode();
        }

        public ComplexType? GetParent()
        {
            if(DataType.ArrayParent != null)
                return DataType.ArrayParent;

            if(DataType.MapParent != null) 
                return DataType.MapParent;

            return null;
        }
    }
}
