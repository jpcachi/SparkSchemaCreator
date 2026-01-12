using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Types
{
    [Serializable]
    internal class CalendarIntervalType : SimpleType
    {
        public override string TypeName => "interval";

        public override string TypeNameApi => "CalendarIntervalType";
    }
}
