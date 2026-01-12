using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Types
{

    internal abstract class CharBaseType(int length) : SimpleType
    {
        public int Length { get; set; } = length;

        public override string ToPythonString(bool sortFields = false, bool includeEmpty = true)
        {
            return TypeNameApi;
        }
    }
}
