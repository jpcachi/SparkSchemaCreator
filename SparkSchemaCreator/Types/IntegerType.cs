using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class IntegerType : SimpleType
    {
        public override string TypeName => "integer";
        public override string TypeNameApi => $"IntegerType";
    }
}
