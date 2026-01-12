using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class DateType : SimpleType
    {
        public override string TypeName => "date";
        public override string TypeNameApi => $"DateType";
    }
}
