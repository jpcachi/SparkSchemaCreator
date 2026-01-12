using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class TimestampType : SimpleType
    {
        public override string TypeName => "timestamp";
        public override string TypeNameApi => $"TimestampType";

    }
}
