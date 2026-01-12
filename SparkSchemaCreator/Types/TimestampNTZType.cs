using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class TimestampNTZType : SimpleType
    {
        public override string TypeName => "timestamp_ntz";
        public override string TypeNameApi => $"TimestampNTZType";

    }
}
