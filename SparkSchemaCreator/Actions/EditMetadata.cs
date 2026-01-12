using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Actions
{
    internal class EditMetadata(StructField editedField, Metadata newMetadata) : IAction
    {
        private readonly Metadata _newMetadata = new(newMetadata.Map);
        private readonly Metadata _oldMetadata = new(editedField.Metadata.Map);

        public object? AffectedNode => (editedField, editedField.Metadata);

        public bool NeedsToExpandAllNodes => false;

        public void Do()
        {
            editedField.Metadata = _newMetadata;
        }

        public void Redo()
        {
            editedField.Metadata = _newMetadata;
        }

        public void Undo()
        {
            editedField.Metadata = _oldMetadata;
        }
    }
}
