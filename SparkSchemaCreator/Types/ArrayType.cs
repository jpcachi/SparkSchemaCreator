using Newtonsoft.Json.Linq;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class ArrayType : ComplexType
    {
        public override string TypeName => "array";
        public override string TypeNameApi => "ArrayType";

        private DataType _elementType;
        public DataType ElementType { 
            get { return _elementType; } 
            set { value.ArrayParent = this; _elementType = value; } 
        }

        public bool ContainsNull { get; set; } = true;

        public ArrayType(DataType elementType)
        {
            _elementType = elementType;
            _elementType.ArrayParent = this;
        }

        public ArrayType(DataType elementType, bool containsNull) : this(elementType)
        {
            ContainsNull = containsNull;
        }

        public override JToken ToJsonObject()
        {
            JObject result = new()
            {
                {"type", TypeName },
                {"elementType", ElementType.ToJsonObject() },
                {"containsNull", ContainsNull }
            };
            
            return result;
        }

        public override string ToScalaObjectString(bool sortFields = false, bool includeEmpty = true, string wrap = "Array")
        {
            return $"{TypeNameApi}({ElementType.ToScalaObjectString(sortFields, includeEmpty, wrap)}, {ContainsNull.ToString().ToLower()})";
        }

        public override string ToPythonString(bool sortFields = false, bool includeEmpty = true)
        {
            return $"{TypeNameApi}({ElementType.ToPythonString(sortFields, includeEmpty)}, {ContainsNull})";
        }


        public override bool Equals(object? obj)
        {

            if(obj is ArrayType array)
                return ElementType == array.ElementType && ContainsNull == array.ContainsNull;

            return false;
        }

        public override int GetHashCode()
        {
            return (ElementType?.GetHashCode() ?? "<empty>".GetHashCode()) ^ ContainsNull.GetHashCode();  
        }

        public override void UpdateFrom(JsonSparkElement newValue)
        {
            if (newValue is not ArrayType array)
                return;

            
            if (ElementType is ComplexType complex1 && array.ElementType is ComplexType complex2 && 
                ElementType.GetType() == array.ElementType.GetType())
                complex1.UpdateFrom(complex2);
            else
                ElementType = array.ElementType;

            ContainsNull = array.ContainsNull;

            MapParent = array.MapParent;
            IsKeyOfMapParent = array.IsKeyOfMapParent;
            ArrayParent = array.ArrayParent;
        }

        public DataType GetNestedElementType()
        {
            if(ElementType is ArrayType array)
                return array.GetNestedElementType();

            return ElementType;
        }

        public override void BuildFormattedString(string prefix, StringConcat stringConcat, int maxDepth)
        {
            if (maxDepth > 0)
            {
                stringConcat.Append($"{prefix}-- element: {ElementType.TypeName} (containsNull = {ContainsNull})\r\n");
                BuildFormattedString(ElementType, $"{prefix}    |", stringConcat, maxDepth);
            }
        }
    }
}
