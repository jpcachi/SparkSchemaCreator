using SparkSchemaCreator.Controls;
using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SparkSchemaCreator.Utils
{
    internal static class SchemaJsonTree
    {
        public static void NodeChildrenNeeded(NodeChildrenNeededEventArgs e)
        {
            if (e.Node is StructType root)
                e.Children = root.Fields;

            else if (e.Node is ITreeElement element)
            {
                if (element.DataType is StructType structType)
                    e.Children = structType.Fields;

                else if (element.DataType is ArrayType arrayType)
                    e.Children = new NameWithDataType[] { new("<element>", arrayType.ElementType) };

                else if (element.DataType is MapType mapType)
                    e.Children = new NameWithDataType[] { new("<key>", mapType.KeyType), new("<value>", mapType.ValueType) };
            }
        }

        public static void NodeTextNeeded(StringNodeEventArgs e)
        {
            if (e.Node is StructType)
                e.Result = "<Root>";
            else if (e.Node is ITreeElement element)
                e.Result = element.Name;
        }

        public static void NodeIconNeeded(ImageNodeEventArgs e, ImageList imageList)
        {

            DataType? dataType = null;

            if (e.Node is StructType structType)
                dataType = structType;

            else if (e.Node is ITreeElement element)
                dataType = element.DataType;


            if (dataType is StructType)
                e.Result = imageList.Images[1];
            else if (dataType is ArrayType)
                e.Result = imageList.Images[2];
            else if (dataType is MapType)
                e.Result = imageList.Images[0];
            else
                e.Result = imageList.Images[3];
        }

        private static ITreeElement? CollectNode(ComplexType typeParent)
        {
            if (typeParent.FieldOfWhichItIsType != null)
                return typeParent.FieldOfWhichItIsType;

            if (typeParent.ArrayParent is not null)
                return new NameWithDataType("<element>", typeParent);

            if (typeParent.MapParent is not null)
                return new NameWithDataType(typeParent.IsKeyOfMapParent ? "<key>" : "<value>", typeParent);

            return null;
        }

        private static ITreeElement? CollectParent(ITreeElement? node)
        {
            if (node is StructField field && field.StructParent != null)
                return CollectNode(field.StructParent);

            else if (node is NameWithDataType pairNode)
            {
                if ((pairNode.Name == "<key>" || pairNode.Name == "<value>") && pairNode.DataType.MapParent is MapType mapParent)
                    return CollectNode(mapParent);

                else if (pairNode.Name == "<element>" && pairNode.DataType.ArrayParent is ArrayType arrayParent)
                    return CollectNode(arrayParent);
            }

            return null;
        }

        private static void CollectNodesRecursively(List<ITreeElement> parents, ITreeElement? node)
        {
            if (node == null)
                return;

            parents.Add(node);
            ITreeElement? iter = CollectParent(node);
            CollectNodesRecursively(parents, iter);
        }

        private static NameWithDataType? GetElementTypeIfNodeIsArray(ITreeElement node)
        {
            ArrayType? arrayType = null;

            if (node is StructField field && field.DataType is ArrayType array1)
                arrayType = array1;

            else if (node is NameWithDataType pairNode && pairNode.DataType is ArrayType array2)
                arrayType = array2;

            return arrayType == null ? null : new NameWithDataType("<element>", arrayType.ElementType);
        }

        private static void ExpandAndSelectNode(this FastTree tree, ITreeElement node, bool unselectOtherNodes)
        {
            NameWithDataType? expandedArrayType = GetElementTypeIfNodeIsArray(node);
            if (expandedArrayType != null)
                tree.ExpandNode(expandedArrayType);

            if (!tree.SelectNode(node, unselectOtherNodes) && CollectParent(node) is ITreeElement validParent)
                tree.SelectNode(validParent, unselectOtherNodes);
        }

        public static void ExpandNodesUntilStructField(this FastTree tree, ITreeElement node)
        {
            List<ITreeElement> parents = [];
            CollectNodesRecursively(parents, node);

            parents.Reverse();
            foreach (ITreeElement parent in parents)
            {
                tree.ExpandNode(parent);
            }

            tree.ScrollToNode(node);
            ExpandAndSelectNode(tree, node, true);
        }

        public static void ExpandNodesUntilStructFields(this FastTree tree, IEnumerable<ITreeElement> nodes)
        {
            List<ITreeElement> parents = [];
            foreach (ITreeElement node in nodes)
                CollectNodesRecursively(parents, node);

            parents.Reverse();
            foreach (ITreeElement parent in parents)
            {
                tree.ExpandNode(parent);
            }

            tree.ScrollToNode(nodes.First());

            bool first = true;
            foreach (ITreeElement node in nodes)
            {
                ExpandAndSelectNode(tree, node, first);
                first = false;
            }
        }
    }
}