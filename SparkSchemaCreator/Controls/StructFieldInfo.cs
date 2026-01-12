using SparkSchemaCreator.Types;
using SparkSchemaCreator.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace SparkSchemaCreator.Controls
{
    public partial class StructFieldInfo : UserControl
    {
        private Color titleColor = Color.SlateBlue;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TitleColor
        {
            get { return titleColor; }
            set 
            { 
                titleColor = value; 
                label1.ForeColor = titleColor; 
            }
        }

        private Color labelColor = Color.SteelBlue;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color LabelColor
        {
            get { return labelColor; }
            set 
            { 
                labelColor = value;

                label2.ForeColor = labelColor;
                label3.ForeColor = labelColor;
                label4.ForeColor = labelColor;
                label5.ForeColor = labelColor;
                label6.ForeColor = labelColor;
                label7.ForeColor = labelColor;
                label8.ForeColor = labelColor;
                label9.ForeColor = labelColor;
                label10.ForeColor = labelColor;

                groupBox1.ForeColor = labelColor;
                groupBox2.ForeColor = labelColor;
            }
        }

        private Color labelValueColor = Color.Black;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color LabelValueColor
        {
            get{ return labelValueColor; }
            set
            {
                labelValueColor = value;

                nameLabel.ForeColor = labelValueColor;
                pathLabel.ForeColor = labelValueColor;
                dataTypeLabel.ForeColor = labelValueColor;
                nullableLabel.ForeColor = labelValueColor;
                elementTypeLabel.ForeColor = labelValueColor;
                containsNullLabel.ForeColor = labelValueColor;
                keyTypeLabel.ForeColor = labelValueColor;
                valueTypeLabel.ForeColor = labelValueColor;
                valueContainsNullLabel.ForeColor = labelValueColor;
            }
        }

        public event EventHandler? EditButtonClick
        {
            add
            {
                editButton.Click += value;
            }
            remove
            {
                editButton.Click -= value; 
            }
        }

        public StructFieldInfo()
        {
            InitializeComponent();
        }

        private static string GetDataTypeForNestedArrayType(ArrayType array)
        {
            if (array.ElementType is ArrayType arrayChild)
                return $"{array.TypeName.Capitalize()}[{GetDataTypeForNestedArrayType(arrayChild)}]";

            return $"{array.TypeName.Capitalize()}[{array.ElementType.TypeName}]";
        }

        internal void LoadValuesRaw(object? obj)
        {
            if (obj == null)
                LoadValues(null);

            if (obj is StructField field)
                LoadValues(field);

            if(obj is NameWithDataType pairNode)
            {
                ComplexType? complexParent = pairNode.Name == "<element>" ? pairNode.DataType.ArrayParent : pairNode.DataType.MapParent;

                string fieldName = pairNode.DataType.GetJsonPathExpanded();
                bool nullable = (complexParent is ArrayType array && array.ContainsNull) ||
                        (complexParent is MapType map && map.ValueContainsNull && pairNode.Name == "<value>");

                LoadValues(fieldName, pairNode.DataType, complexParent == null || nullable, null);
            }
        }

        private void LoadValues(string name, DataType dataType, bool nullable, string? path)
        {
            string dataTypeStr = dataType is ArrayType array ? GetDataTypeForNestedArrayType(array) : dataType.TypeName;

            label1.Text = $"{name} <{dataTypeStr}>";
            nameLabel.Text = name;
            pathLabel.Text = path ?? dataType.GetJsonPath();
            dataTypeLabel.Text = dataTypeStr;
            nullableLabel.Text = nullable.ToString().ToLower();

            if(dataType is ArrayType arrayType)
            {
                groupBox2.Visible = false;
                groupBox1.Visible = true;

                elementTypeLabel.Text = arrayType.ElementType.TypeName;
                containsNullLabel.Text = arrayType.ContainsNull.ToString().ToLower();
            }
            else if (dataType is MapType mapType)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;

                keyTypeLabel.Text = mapType.KeyType.TypeName;
                valueTypeLabel.Text = mapType.ValueType.TypeName;
                valueContainsNullLabel.Text = mapType.ValueContainsNull.ToString().ToLower();
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
            }

        }

        private void LoadValues(StructField? field)
        {
            if (field != null)
            {
                LoadValues(field.Name, field.DataType, field.IsNullable, field.GetJsonPath());
            }
            else
            {
                label1.Text = "Field Information";
                nameLabel.Text = "<empty>";
                pathLabel.Text = "<empty>";
                dataTypeLabel.Text = "<empty>";
                nullableLabel.Text = "<empty>";
                elementTypeLabel.Text = "<empty>";
                containsNullLabel.Text = "<empty>";
                keyTypeLabel.Text = "<empty>";
                valueTypeLabel.Text = "<empty>";
                containsNullLabel.Text = "<empty>";
                editButton.Enabled = false;
            }
        }
    }
}
