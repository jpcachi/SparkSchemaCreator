using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Actions
{
    internal interface IAction
    {
        void Do();
        void Undo();

        object? AffectedNode { get; }

        bool NeedsToExpandAllNodes { get; }
    }
}
