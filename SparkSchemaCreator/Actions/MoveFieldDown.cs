using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Actions
{
    internal class MoveFieldDown(StructType parent, StructField fieldToMove) : IAction
    {
        private readonly int _index = fieldToMove.Index;

        public object? AffectedNode => fieldToMove;

        public bool NeedsToExpandAllNodes => false;

        public void Do()
        {
            parent.Fields.RemoveAt(_index);
            parent.Fields.Insert(_index + 1, fieldToMove);
        }

        public void Undo()
        {
            parent.Fields.RemoveAt(_index + 1);
            parent.Fields.Insert(_index, fieldToMove);
        }
    }
}
