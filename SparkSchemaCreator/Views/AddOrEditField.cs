using SparkSchemaCreator.Json;
using SparkSchemaCreator.Properties;
using SparkSchemaCreator.Types;
using System.Data;

namespace SparkSchemaCreator
{
    public partial class AddOrEditField : Form
    {
        internal enum EditingMode
        {
            Default, ArrayType, MapKeyType, MapValueType
        }
        private void SetStructEditSize()
        {
            ClientSize = new Size(532, 510);
            button1.Location = new Point(button1.Location.X, 475);
            button2.Location = new Point(button2.Location.X, 475);
        }

        private void SetRegularEditSize()
        {
            ClientSize = new Size(532, 150);
            button1.Location = new Point(button1.Location.X, 115);
            button2.Location = new Point(button2.Location.X, 115);
        }

        private void SetArrayEditSize()
        {
            ClientSize = new Size(532, 238);
            button1.Location = new Point(button1.Location.X, 203);
            button2.Location = new Point(button2.Location.X, 203);

            groupBox3.Size = new Size(509, 88);
        }

        private void SetMapEditSize()
        {
            ClientSize = new Size(532, 275);
            button1.Location = new Point(button1.Location.X, 240);
            button2.Location = new Point(button2.Location.X, 240);

            groupBox4.Size = new Size(509, 125);
        }

        internal StructField Value { get; }

        private DataType? _elementType;

        private DataType? _keyType;
        private DataType? _valueType;

        internal AddOrEditField(StructField? editField, EditingMode editingMode = EditingMode.Default, DataType? elementType = null)
        {
            InitializeComponent();
            SetRegularEditSize();

            if (editField == null)
            {
                Value = new StructField();

                Text = editingMode >= EditingMode.MapKeyType ? "Set type for MapType" : editingMode == EditingMode.ArrayType ? "Set type for Array" : "Add Field";
                Icon = Resources.add_field_icon;

                label1.Enabled = editingMode == EditingMode.Default;
                textBox1.Enabled = editingMode == EditingMode.Default;

                button2.Enabled = editingMode != EditingMode.Default;
                richTextBox1.Text = new StructType().ToJsonString(false, true, true);

                if (editingMode != EditingMode.Default)
                {
                    Value.Name = editingMode == EditingMode.MapKeyType ? "<key>" : editingMode == EditingMode.MapValueType ? "<value>" : "<element>";

                    if (elementType != null)
                        Value.DataType = elementType;

                    LoadFieldValues();
                }
            }
            else
            {
                Value = editField.Clone();
                Text = "Edit Field";
                Icon = Resources.edit_field_icon;
                LoadFieldValues();
            }

            button4.Location = new Point(label8.Right + button4.Margin.Left, button4.Location.Y);
            button6.Location = new Point(button4.Right + button6.Margin.Left, button6.Location.Y);

            button3.Location = new Point(Math.Max(label7.Right, label11.Right) + button3.Margin.Left, button3.Location.Y);
            button5.Location = new Point(Math.Max(label7.Right, label11.Right) + button5.Margin.Left, button5.Location.Y);

            button7.Location = new Point(button3.Right + button7.Margin.Left, button7.Location.Y);
            button8.Location = new Point(button5.Right + button8.Margin.Left, button8.Location.Y);
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            Value.Name = textBox1.Text;
            Value.DataType = GetDataType();
            Value.IsNullable = checkBox1.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ActivateButtonOK()
        {
            string invalidCharacters = " ,;{}()\n\t=";
            bool nameContainsInvalid = SchemaSettings.Instance.CheckIllegalCharactersInNames && invalidCharacters.Intersect(textBox1.Text).Any();
            button2.Enabled = !string.IsNullOrEmpty(textBox1.Text) && !nameContainsInvalid
                && (comboBox1.SelectedIndex != -1);

            label5.Visible = nameContainsInvalid;

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 6: SelectDecimal(); break;
                case 9: case 10: SelectChar(); break;
                case 29: SelectStruct(); break;
                case 30: SelectArray(); break;
                case 31: SelectMap(); break;
                default: SelectSimple(); break;
            }

            ActivateButtonOK();
        }


        private void SelectStruct()
        {
            SetStructEditSize();
            groupBox1.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;

            label3.Enabled = false;
            numericUpDown1.Enabled = false;
            label4.Enabled = false;
            numericUpDown2.Enabled = false;
        }

        private void SelectSimple()
        {
            SetRegularEditSize();
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;

            label3.Enabled = false;
            numericUpDown1.Enabled = false;
            label4.Enabled = false;
            numericUpDown2.Enabled = false;
        }

        private void SelectArray()
        {
            SetArrayEditSize();
            label3.Enabled = false;
            numericUpDown1.Enabled = false;
            label4.Enabled = false;
            numericUpDown2.Enabled = false;

            groupBox1.Visible = false;
            groupBox3.Visible = true;
            groupBox4.Visible = false;
        }

        private void SelectMap()
        {
            SetMapEditSize();
            label3.Enabled = false;
            numericUpDown1.Enabled = false;
            label4.Enabled = false;
            numericUpDown2.Enabled = false;

            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = true;
        }

        private void SelectDecimal()
        {
            SetRegularEditSize();

            label3.Enabled = true;
            numericUpDown1.Enabled = true;
            label4.Enabled = true;
            numericUpDown2.Enabled = true;

            label3.Text = "Precision:";
            numericUpDown1.Visible = true;
            numericUpDown1.Maximum = 38;
            label4.Visible = true;
            numericUpDown2.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }

        private void SelectChar()
        {
            SetRegularEditSize();

            label3.Enabled = true;
            numericUpDown1.Enabled = true;

            label3.Text = "Length:";
            numericUpDown1.Visible = true;
            numericUpDown1.Maximum = int.MaxValue;
            label4.Visible = false;
            numericUpDown2.Visible = false;
            groupBox1.Visible = false;
        }


        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value > numericUpDown1.Value)
                numericUpDown2.Maximum = numericUpDown1.Value;
            
        }

        private void LoadFieldValues()
        {
            textBox1.Text = Value.Name;
            checkBox1.Checked = Value.IsNullable;
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Value.DataType.TypeName);

            if (Value.DataType is DecimalType decimalType)
            {
                numericUpDown1.Value = decimalType.Precission;
                numericUpDown2.Value = decimalType.Scale;
            }
            else if (Value.DataType is CharBaseType type)
            {
                numericUpDown1.Value = type.Length;
            }
            else if (Value.DataType is StructType structType)
            {
                richTextBox1.Text = structType.ToJsonString(false, true, true);
            }
            else if (Value.DataType is ArrayType arrayType)
            {
                _elementType = arrayType.ElementType;
                label8.Text = $"<{_elementType.TypeName}>";
                button6.Enabled = _elementType != null;
            }
            else if (Value.DataType is MapType mapType)
            {
                _keyType = mapType.KeyType;
                _valueType = mapType.ValueType;

                label7.Text = $"<{_keyType.TypeName}>";
                label11.Text = $"<{_valueType.TypeName}>";

                button7.Enabled = _keyType != null;
                button8.Enabled = _valueType != null;
            }
        }

        private DataType GetArrayElementType()
        {
            return _elementType ?? new StringType();
        }

        private DataType GetMapKeyType()
        {
            return _keyType ?? new StringType();
        }

        private DataType GetMapValueType()
        {
            return _valueType ?? new StringType();
        }

        private DataType GetDataType()
        {
            if (comboBox1.SelectedItem is not string dataType)
                return DataType.FromString("void");

            if (dataType == "map")
                return new MapType(GetMapKeyType(), GetMapValueType(), checkBox2.Checked);

            if (dataType == "array")
                return new ArrayType(GetArrayElementType(), checkBox3.Checked);

            if (dataType == "struct")
            {
                if (radioButton1.Checked)
                {
                    return JsonSchemaToSchema.Instance.ParseSchemaJson(richTextBox1.Text);
                }

                StructType structType = new();
                structType.AddFields(richTextBox1.Lines.Select(field => new StructField(field, new StringType())));

                return structType;
            }

            if (dataType == "decimal")
                dataType += $"({numericUpDown1.Value},{numericUpDown2.Value})";
            else if(dataType == "char" || dataType == "varchar")
                dataType += $"({numericUpDown1.Value})";

            return DataType.FromString(dataType);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            ActivateButtonOK();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            StructType type = (Value.DataType is StructType structType) ? structType : new StructType();
            richTextBox1.Text = radioButton1.Checked ? type.ToJsonString(false, true, true) : string.Join("\r\n", type.Fields.Select(field => field.Name));
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using AddOrEditField arrayChild = new(null, EditingMode.ArrayType, _elementType);
            if (arrayChild.ShowDialog() == DialogResult.OK)
            {
                _elementType = arrayChild.Value.DataType;

                if (_elementType is ComplexType complex)
                    complex.FieldOfWhichItIsType = null;

                label8.Text = $"<{_elementType.TypeName}>";
                button6.Enabled = true;
                button4.Location = new Point(label8.Right + button4.Margin.Left, button4.Location.Y);
                button6.Location = new Point(button4.Right + button6.Margin.Left, button6.Location.Y);
            }
        }

        private void SetMapKeyTypeButtonClick(object sender, EventArgs e)
        {
            using AddOrEditField mapChild = new(null, EditingMode.MapKeyType, _keyType);
            if (mapChild.ShowDialog() == DialogResult.OK)
            {
                _keyType = mapChild.Value.DataType;

                if (_keyType is ComplexType complex)
                    complex.FieldOfWhichItIsType = null;

                label7.Text = $"<{_keyType.TypeName}>";
                button7.Enabled = true;
                button3.Location = new Point(Math.Max(label7.Right, label11.Right) + button3.Margin.Left, button3.Location.Y);
                button5.Location = new Point(Math.Max(label7.Right, label11.Right) + button5.Margin.Left, button5.Location.Y);
                button7.Location = new Point(button3.Right + button7.Margin.Left, button7.Location.Y);
                button8.Location = new Point(button5.Right + button8.Margin.Left, button8.Location.Y);
            }
        }

        private void SetMapValueTypeButtonClick(object sender, EventArgs e)
        {
            using AddOrEditField mapChild = new(null, EditingMode.MapValueType, _valueType);
            if (mapChild.ShowDialog() == DialogResult.OK)
            {
                _valueType = mapChild.Value.DataType;

                if (_valueType is ComplexType complex)
                    complex.FieldOfWhichItIsType = null;

                label11.Text = $"<{_valueType.TypeName}>";
                button8.Enabled = true;
                button3.Location = new Point(Math.Max(label7.Right, label11.Right) + button3.Margin.Left, button3.Location.Y);
                button5.Location = new Point(Math.Max(label7.Right, label11.Right) + button5.Margin.Left, button5.Location.Y);
                button7.Location = new Point(button3.Right + button7.Margin.Left, button7.Location.Y);
                button8.Location = new Point(button5.Right + button8.Margin.Left, button8.Location.Y);
            }
        }

        private void ClearArrayElementType(object sender, EventArgs e)
        {
            _elementType = null;
            label8.Text = "<null>";
            button4.Location = new Point(label8.Right + button4.Margin.Left, button4.Location.Y);
            button6.Location = new Point(button4.Right + button6.Margin.Left, button6.Location.Y);
            button6.Enabled = false;
        }

        private void ClearMapKeyType(object sender, EventArgs e)
        {
            _keyType = null;
            label7.Text = "<null>";
            button3.Location = new Point(Math.Max(label7.Right, label11.Right) + button3.Margin.Left, button3.Location.Y);
            button5.Location = new Point(Math.Max(label7.Right, label11.Right) + button5.Margin.Left, button5.Location.Y);
            button7.Location = new Point(button3.Right + button7.Margin.Left, button7.Location.Y);
            button8.Location = new Point(button5.Right + button8.Margin.Left, button8.Location.Y);
            button7.Enabled = false;
        }

        private void ClearMapValueType(object sender, EventArgs e)
        {
            _valueType = null;
            label11.Text = "<null>";
            button3.Location = new Point(Math.Max(label7.Right, label11.Right) + button3.Margin.Left, button3.Location.Y);
            button5.Location = new Point(Math.Max(label7.Right, label11.Right) + button5.Margin.Left, button5.Location.Y);
            button7.Location = new Point(button3.Right + button7.Margin.Left, button7.Location.Y);
            button8.Location = new Point(button5.Right + button8.Margin.Left, button8.Location.Y);
            button8.Enabled = false;
        }
    }
}
