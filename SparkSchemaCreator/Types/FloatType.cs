using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class FloatType : SimpleType
    {
        public override string TypeName => "float";
        public override string TypeNameApi => $"FloatType";
    }
}
