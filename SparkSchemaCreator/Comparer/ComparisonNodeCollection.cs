using SparkSchemaCreator.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Comparer
{
    internal class ComparisonNodeCollection : ICollection<ComparisonNode>, IEnumerable<ComparisonNode>
    {
        private readonly List<ComparisonNode> _children;

        public int Count => _children.Count;

        public bool IsReadOnly => true;
        public ComparisonNode this[int i] => _children[i];
        public ComparisonNode this[string name] => _children.Find(x => x.Name == name) ?? throw new KeyNotFoundException(nameof(name));

        public bool Equal => _children.TrueForAll(x => x.ComparisonResult == ComparisonResult.Equal);

        public bool HasOnlyMissingFieldsDifference => 
            _children.Any(x => x.ComparisonResult == ComparisonResult.MissingField || x.ComparisonResult == ComparisonResult.ChildMissingFieldDifference) &&
            _children.TrueForAll(x => x.ComparisonResult == ComparisonResult.MissingField || x.ComparisonResult <= ComparisonResult.ChildMissingFieldDifference);

        public bool HasDifferences => _children.Any(x => x.ComparisonResult > ComparisonResult.ChildMetadataDifference);

        public bool HasMetadataDifferences => _children.Any(x => x.ComparisonResult.HasFlag(ComparisonResult.MetadataDifference) || x.ComparisonResult.HasFlag(ComparisonResult.ChildMetadataDifference));

        public ComparisonNodeCollection LeftChildren => [.. _children.Where(x => x.Left != null)];
        public ComparisonNodeCollection RightChildren => [.. _children.Where(x => x.Right != null)];

        internal ComparisonNodeCollection()
        {
            _children = [];
        }
        internal ComparisonNodeCollection(IEnumerable<ComparisonNode> children)
        {
            _children = [.. children];
        }

        public void AddRange(IEnumerable<ComparisonNode> children)
        {
            _children.AddRange(children);
        }

        public void Add(ComparisonNode item)
        {
            _children.Add(item);
        }

        public void Clear()
        {
            _children.Clear();
        }

        public bool Contains(ComparisonNode item)
        {
            return _children.Contains(item);
        }

        public void CopyTo(ComparisonNode[] array, int arrayIndex)
        {
            _children.CopyTo(array, arrayIndex);
        }

        public bool Remove(ComparisonNode item)
        {
            return _children.Remove(item);
        }

        public IEnumerator<ComparisonNode> GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
