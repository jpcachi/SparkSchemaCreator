using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class CharType(int length) : CharBaseType(length)
    {
        public override string TypeNameSimple => $"char";
        public override string TypeName => $"char({Length})";
        public override string TypeNameApi => $"CharType({Length})";

    }
}
