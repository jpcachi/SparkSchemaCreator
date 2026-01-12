using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class DoubleType : SimpleType
    {
        public override string TypeName => "double";
        public override string TypeNameApi => $"DoubleType";
    }
}
