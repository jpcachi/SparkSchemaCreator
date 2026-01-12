using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Actions
{
    internal class ImportFile : IAction
    {
        private readonly StructType _oldRoot;
        private readonly StructType _newRoot;

        private readonly ModelData _model;

        private readonly bool _expandAllNodes;
        internal ImportFile(ModelData model, StructType newRoot, bool expandAllNodes)
        {
            _oldRoot = new StructType(model.Root);
            _newRoot = new StructType(newRoot);

            _model = model;
            _expandAllNodes = expandAllNodes;
        }

        public object? AffectedNode => _model;
        public bool NeedsToExpandAllNodes => _expandAllNodes;

        public void Do()
        {
            _model.SetRoot(_newRoot);
        }

        public void Redo()
        {
            _model.SetRoot(_newRoot);
        }

        public void Undo()
        {
            _model.SetRoot(_oldRoot);
        }
    }
}
