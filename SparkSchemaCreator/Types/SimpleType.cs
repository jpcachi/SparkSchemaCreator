using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal abstract class SimpleType : DataType
    {
        public override void UpdateFrom(JsonSparkElement newValue)
        {
            
        }

        public override JToken ToJsonObject()
        {
            return new JValue(TypeName);
        }

        public override bool Equals(object? obj)
        {
            if(obj is SimpleType other)
                return TypeName == other.TypeName;

            return false;
        }

        public override int GetHashCode()
        {
            return TypeName.GetHashCode();
        }

        public override string ToScalaObjectString(bool sortFields = false, bool includeEmpty = true, string wrap = "Array")
        {
            return TypeNameApi;
        }

        public override string ToPythonString(bool sortFields = false, bool includeEmpty = true)
        {
            return TypeNameApi + "()";
        }
    }
}
