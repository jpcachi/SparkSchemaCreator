using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Comparer
{
    internal class ComparisonNode
    {
        private readonly string _name;
        public string Name => _name;
        public string FullName => Left?.GetJsonPathExpanded() ?? Right?.GetJsonPathExpanded() ?? _name;

        public ComparisonResult ComparisonResult { get; }

        public JsonSparkElement? Left { get; }
        public JsonSparkElement? Right { get; }

        public ComparisonNodeCollection Children { get; }

        public ComparisonNode(JsonSparkElement? left, JsonSparkElement? right, ComparisonResult comparisonResult, ComparisonNodeCollection? children = null, string? name = null)
        {
            if (left == null && right == null)
                throw new ArgumentNullException("left,right", "Both fields in comparison cannot be null at the same time");

            ComparisonResult = comparisonResult;
            Left = left;
            Right = right;

            Children = children ?? [];
            _name = Left is StructField leftField ? leftField.Name : Right is StructField rightField ? rightField.Name : (name ?? string.Empty);
        }

        public string GetComparisonResultString()
        {
            List<string> result = [];

            if (ComparisonResult.HasFlag(ComparisonResult.TypeDifference))
                result.Add("Type");

            if (ComparisonResult.HasFlag(ComparisonResult.NullableDifference))
                result.Add("Nullable");

            if (ComparisonResult.HasFlag(ComparisonResult.ContainsNullDifference))
                result.Add(Left is ArrayType || Left is StructField field && field.DataType is ArrayType ? "ContainsNull" : "ValueContainsNull");

            if (ComparisonResult.HasFlag(ComparisonResult.MissingField))
                result.Add(Left == null ? "AddedField" : "MissingField");

            if (ComparisonResult.HasFlag(ComparisonResult.MetadataDifference))
                result.Add("Metadata");

            return string.Join(", ", result);
        }
    }
}
