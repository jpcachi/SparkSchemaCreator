using SparkSchemaCreator.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class DecimalType : SimpleType
    {
        [TypeConverter(typeof(DecimalTypePrecissionScaleConverter))]
        public int Precission { get; set; } = 10;

        [TypeConverter(typeof(DecimalTypePrecissionScaleConverter))]
        public int Scale { get; set; } = 0;

        public override string TypeNameSimple => $"decimal";
        public override string TypeName => $"decimal({Precission},{Scale})";
        public override string TypeNameApi => $"DecimalType({Precission}, {Scale})";

        public DecimalType(int precission) : this(precission, 0) { }

        public DecimalType(int precission, int scale)
        {
            if (precission > 38) 
                throw new ArgumentException("DecimalType precission cannot exceed 38.");

            if (Scale > precission) 
                throw new ArgumentException($"DecimalType scale cannot be bigger than precission.");

            Precission = precission;
            Scale = scale;
        }

        public override string ToPythonString(bool sortFields = false, bool includeEmpty = true)
        {
            return TypeNameApi;
        }
    }
}
