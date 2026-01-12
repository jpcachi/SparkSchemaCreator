using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Actions
{
    internal class AddField(StructType parent, StructField addedField) : IAction
    {
        public object? AffectedNode => addedField;

        public bool NeedsToExpandAllNodes => false;

        public void Do()
        {
            parent.AddField(addedField);
        }

        public void Undo()
        {
            parent.Fields.Remove(addedField);
        }
    }
}
