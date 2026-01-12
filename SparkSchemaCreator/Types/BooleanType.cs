using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class BooleanType : SimpleType
    {
        public override string TypeName => "boolean";
        public override string TypeNameApi => "BooleanType";
    }
}
