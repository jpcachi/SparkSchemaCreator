using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class BinaryType : SimpleType
    {
        public override string TypeName => "binary";
        public override string TypeNameApi => "BinaryType";

    }
}
