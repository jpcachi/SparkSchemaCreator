using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class ShortType : SimpleType
    {
        public override string TypeName => "short";
        public override string TypeNameApi => $"ShortType";

    }
}
