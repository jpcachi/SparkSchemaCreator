using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class VarcharType(int length) : CharBaseType(length)
    {
        public override string TypeNameSimple => $"varchar";
        public override string TypeName => $"varchar({Length})";
        public override string TypeNameApi => $"VarcharType({Length})";

    }
}
