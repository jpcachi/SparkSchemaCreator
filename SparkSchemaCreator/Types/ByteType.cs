using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class ByteType : SimpleType
    {
        public override string TypeName => "byte";
        public override string TypeNameApi => "ByteType";
    }
}
