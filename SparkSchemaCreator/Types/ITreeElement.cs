using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Types
{
    internal interface ITreeElement
    {
        string? Name { get; }
        DataType DataType { get; }
    }
}
