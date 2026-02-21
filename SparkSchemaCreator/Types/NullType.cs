using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class NullType : SimpleType
    {
        public override string TypeName => "void";
        public override string TypeNameApi => $"NullType";

    }
}
