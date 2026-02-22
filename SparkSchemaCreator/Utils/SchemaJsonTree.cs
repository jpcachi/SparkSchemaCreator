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
    }
}
