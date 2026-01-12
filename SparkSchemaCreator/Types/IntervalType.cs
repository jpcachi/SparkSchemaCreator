using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkSchemaCreator.Types
{
    internal abstract class IntervalType(byte startField, byte endField) : SimpleType
    {
        public byte StartField { get; set; } = startField;
        public byte EndField { get; set; } = endField;

    }
}
