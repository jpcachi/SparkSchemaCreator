using SparkSchemaCreator.Types;
using SparkSchemaCreator.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkSchemaCreator.Actions
{
    internal class EditElement : IAction
    {

        private readonly DataType _oldValue;
        private readonly DataType _newValue;

        private readonly NameWithDataType _currentNode;

        internal EditElement(NameWithDataType currentNode, DataType newValue)
        {
            _currentNode = currentNode;

            _oldValue = currentNode.DataType.Clone();
            _newValue = newValue;
        }

        public object? AffectedNode => _currentNode;

        public bool NeedsToExpandAllNodes => false;

        private void SetParentValue(DataType dataValue)
        {
            ComplexType? parent = _currentNode.GetParent();

            if (parent is ArrayType array1)
                array1.ElementType = dataValue;
            else if (parent is MapType map)
            {
                if (_currentNode.Name == "<key>")
                    map.KeyType = dataValue;
                else
                    map.ValueType = dataValue;
            }

            _currentNode.DataType = dataValue;
        }

        public void Do()
        {
            SetParentValue(_newValue);
        }

        public void Undo()
        {
            SetParentValue(_oldValue);
        }
    }
}
