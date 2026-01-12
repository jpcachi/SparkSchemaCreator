using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class LongType : SimpleType
    {
        public override string TypeName => "long";
        public override string TypeNameApi => $"LongType";
    }
}
