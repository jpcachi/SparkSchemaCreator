using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Actions
{
    internal class DeleteMultipleFields : IAction
    {
        private readonly List<StructType> parents;
        private readonly List<StructField> deletedFields;
        private readonly List<int> fieldIndices;

        internal DeleteMultipleFields(IEnumerable<StructField> fields)
        {
            parents = [.. fields.Select(x => x.StructParent!)];
            deletedFields = [.. fields];
            fieldIndices = [.. fields.Select(x => x.Index)];
        }

        public object? AffectedNode => deletedFields;

        public bool NeedsToExpandAllNodes => false;

        public void Do()
        {
            foreach (var (parent, child) in parents.Zip(deletedFields))
            {
                parent.Fields.Remove(child);
            }
        }

        public void Undo()
        {
            foreach (var ((parent, child), index) in parents.Zip(deletedFields).Zip(fieldIndices))
            {
                parent.Fields.Insert(index, child);
            }
        }
    }
}
