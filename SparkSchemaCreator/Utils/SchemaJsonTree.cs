using SparkSchemaCreator.Controls;
using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SparkSchemaCreator.Utils
{
    internal static class SchemaJsonTree
    {
        public static void NodeChildrenNeeded(NodeChildrenNeededEventArgs e)
        {
            if (e.Node is StructType root)
                e.Children = root.Fields;

            else if (e.Node is StructField field)
            {
                if (field.DataType is StructType structType)
                    e.Children = structType.Fields;

                else if (field.DataType is ArrayType arrayType)
                    e.Children = new NameWithDataType[] { new("<element>", arrayType.ElementType) };

                else if (field.DataType is MapType mapType)
                    e.Children = new NameWithDataType[] { new("<key>", mapType.KeyType), new("<value>", mapType.ValueType) };
            }

            else if (e.Node is NameWithDataType pairNode)
            {
                if (pairNode.DataType is StructType structType)
                    e.Children = structType.Fields;

                else if (pairNode.DataType is ArrayType arrayType)
                    e.Children = new NameWithDataType[] { new("<element>", arrayType.ElementType) };

                else if (pairNode.DataType is MapType mapType)
                    e.Children = new NameWithDataType[] { new("<key>", mapType.KeyType), new("<value>", mapType.ValueType) };
            }
        }

        public static void NodeTextNeeded(StringNodeEventArgs e)
        {
            if (e.Node is StructType)
                e.Result = "<Root>";
            else if (e.Node is StructField field)
                e.Result = field.Name;
            else if (e.Node is NameWithDataType pairNode)
                e.Result = pairNode.Name;
        }

        public static void NodeIconNeeded(ImageNodeEventArgs e, ImageList imageList)
        {

            DataType? dataType = null;

            if (e.Node is StructType structType)
                dataType = structType;

            else if (e.Node is StructField field)
                dataType = field.DataType;

            else if (e.Node is NameWithDataType pairNode)
                dataType = pairNode.DataType;


            if (dataType is StructType)
                e.Result = imageList.Images[1];
            else if (dataType is ArrayType)
                e.Result = imageList.Images[2];
            else if (dataType is MapType)
                e.Result = imageList.Images[0];
            else
                e.Result = imageList.Images[3];
        }
    }
}
