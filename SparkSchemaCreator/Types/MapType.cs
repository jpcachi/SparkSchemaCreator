using SparkSchemaCreator.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Drawing.Design;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class MapType : ComplexType
    {
        public override string TypeName => "map";
        public override string TypeNameApi => $"MapType";


        private DataType _keyType;
        private DataType _valueType;

        public DataType KeyType {
            get {  return _keyType; }
            set { value.MapParent = this; value.IsKeyOfMapParent = true; _keyType = value; } }

        public DataType ValueType
        {
            get { return _valueType; }
            set { value.MapParent = this; value.IsKeyOfMapParent = false; _valueType = value; }
        }

        public bool ValueContainsNull { get; set; } = true;


        public MapType(DataType keyType, DataType valueType)
        {

            _keyType = keyType;
            _keyType.MapParent = this;
            _keyType.IsKeyOfMapParent = true;

            _valueType = valueType;
            _valueType.MapParent = this;
            _valueType.IsKeyOfMapParent = false;
        }

        public MapType(DataType keyType, DataType valueType, bool valueContainsNull) : this(keyType, valueType)
        {
            ValueContainsNull = valueContainsNull;
        }

        public override JToken ToJsonObject()
        {
            JObject result = new()
            {
                {"type", TypeName },
                {"keyType", KeyType.ToJsonObject() },
                {"valueType", ValueType.ToJsonObject() },
                {"valueContainsNull", ValueContainsNull }
            };

            return result;
        }

        public override string ToScalaObjectString(bool sortFields = false, bool includeEmpty = true, string wrap = "Array")
        {
            return $"{TypeNameApi}({KeyType.ToScalaObjectString(sortFields, includeEmpty, wrap)}, {ValueType.ToScalaObjectString(sortFields, includeEmpty, wrap)}, {ValueContainsNull.ToString().ToLower()})";
        }

        public override string ToPythonString(bool sortFields = false, bool includeEmpty = true)
        {
            return $"{TypeNameApi}({KeyType.ToPythonString(sortFields, includeEmpty)}, {ValueType.ToPythonString(sortFields, includeEmpty)}, {ValueContainsNull})";
        }

        public override bool Equals(object? other)
        {
            return other is MapType mapType && mapType.ValueContainsNull == ValueContainsNull && mapType.KeyType == KeyType && mapType.ValueType == ValueType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(KeyType, ValueType, ValueContainsNull);
        }

        public override void UpdateFrom(JsonSparkElement newValue)
        {
            if (newValue is not MapType mapType)
                return;

            if (KeyType is ComplexType kc1 && mapType.KeyType is ComplexType kc2)
                kc1.UpdateFrom(kc2);
            else
                KeyType = mapType.KeyType;

            if (ValueType is ComplexType vc1 && mapType.ValueType is ComplexType vc2)
                vc1.UpdateFrom(vc2);
            else
                ValueType = mapType.ValueType;

            ValueContainsNull = mapType.ValueContainsNull;
        }

        public override void BuildFormattedString(string prefix, StringConcat stringConcat, int maxDepth)
        {
            if(maxDepth > 0)
            {
                stringConcat.Append($"{prefix}-- key: {KeyType.TypeName}\r\n");
                BuildFormattedString(KeyType, $"{prefix}    |", stringConcat, maxDepth);
                stringConcat.Append($"{prefix}-- value: {ValueType.TypeName} (valueContainsNull = {ValueContainsNull})\r\n");
                BuildFormattedString(ValueType, $"{prefix}    |", stringConcat, maxDepth);
            }
        }
    }
}
