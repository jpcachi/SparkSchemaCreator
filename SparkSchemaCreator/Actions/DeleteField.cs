using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Actions
{
    internal class DeleteField : IAction
    {

        private readonly StructType parent;
        private readonly StructField deletedField;
        private readonly int fieldIndex;

        internal DeleteField(StructType parent, StructField deletedField)
        {
            this.parent = parent;
            this.deletedField = deletedField;

            fieldIndex = parent.Fields.IndexOf(deletedField);
        }

        public object? AffectedNode => deletedField;

        public bool NeedsToExpandAllNodes => false;

        public void Do()
        {
            parent.Fields.Remove(deletedField);
        }

        public void Redo()
        {
            parent.Fields.Remove(deletedField);
        }

        public void Undo()
        {
            parent.InsertField(fieldIndex, deletedField);
        }
    }
}
