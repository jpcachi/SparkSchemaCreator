using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Actions
{
    internal class EditField : IAction
    {

        private readonly StructField _oldValue;
        private readonly StructField _newValue;

        private readonly StructField _field;

        internal EditField(StructField field, StructField newFieldData)
        {
            _field = field;

            _oldValue = field.Clone();
            _newValue = newFieldData;
        }

        public object? AffectedNode => _field;

        public bool NeedsToExpandAllNodes => false;

        public void Do()
        {
            _field.UpdateFrom(_newValue);
        }

        public void Undo()
        {
            _field.UpdateFrom(_oldValue);
        }
    }
}
