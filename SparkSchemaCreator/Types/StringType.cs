using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class StringType : SimpleType
    {
        public override string TypeName => "string";
        public override string TypeNameApi => $"StringType";
    } 
}
