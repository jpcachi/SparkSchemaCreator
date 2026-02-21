using Newtonsoft.Json.Linq;
using SparkSchemaCreator.Controls.FastColoredTextBox;
using SparkSchemaCreator.Json;
using SparkSchemaCreator.Properties;
using SparkSchemaCreator.Types;
using SparkSchemaCreator.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SparkSchemaCreator.Views
{
    public partial class AddOrEditField : Form
    {
        internal JsonSparkElement Value { get; private set; }

        private DataType _elementType;

        private DataType _keyType;
        private DataType _valueType;

        internal AddOrEditField(ITreeElement? element)
        {
            InitializeComponent();
            InitializeDataGrids();
            SetRegularEditSize();

            _elementType = new NullType();
            _keyType = new NullType();
            _valueType = new NullType();

            RefreshElementType();
            RefreshKeyType();
            RefreshValueType();

            struct1 = new StructType().ToJsonString(false, true, true);
            struct2 = string.Empty;

            richTextBox1.Text = struct1;

            if(element is StructField value)
            {
                Value = value.Clone();
                Text = "Edit Field";
                Icon = Resources.edit_field_icon;

                LoadStructField(value);
            }

            else if (element is NameWithDataType pairNode)
            {
                Value = pairNode.DataType;
                Text = $"Edit {pairNode.Name}";
                Icon = Resources.edit_field_icon;

                LoadNameWithDataType(pairNode);
            }

            else
            {
                Value = new StructField();
                Text = "Add Field";
                Icon = Resources.add_field_icon;
            }
        }

        private void ActivateButtonOK()
        {
            bool nameContainsInvalid = SchemaSettings.Instance.CheckIllegalCharactersInNames && StructFieldUtils.INVALID_CHARS.Intersect(textBox1.Text).Any();
            button2.Enabled = !string.IsNullOrEmpty(textBox1.Text) && !nameContainsInvalid
                && (comboBox1.SelectedIndex != -1);

            label5.Visible = nameContainsInvalid;
        }

        private void SetRegularEditSize()
        {
            ClientSize = new Size(532, 150);
            button1.Location = new Point(button1.Location.X, 115);
            button2.Location = new Point(button2.Location.X, 115);
        }

        private void SelectStruct()
        {
            ClientSize = new Size(532, 510);
            button1.Location = new Point(button1.Location.X, 475);
            button2.Location = new Point(button2.Location.X, 475);

            groupBox1.Visible = false;
            groupBox2.Visible = true;
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
            groupBox2.Visible = false;
            groupBox4.Visible = false;

            label3.Enabled = false;
            numericUpDown1.Enabled = false;
            label4.Enabled = false;
            numericUpDown2.Enabled = false;
        }

        private void SelectArray()
        {
            ClientSize = new Size(532, 238);
            button1.Location = new Point(button1.Location.X, 203);
            button2.Location = new Point(button2.Location.X, 203);

            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox4.Visible = false;

            label3.Enabled = false;
            numericUpDown1.Enabled = false;
            label4.Enabled = false;
            numericUpDown2.Enabled = false;
        }

        private void SelectMap()
        {
            ClientSize = new Size(532, 275);
            button1.Location = new Point(button1.Location.X, 240);
            button2.Location = new Point(button2.Location.X, 240);

            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = true;

            label3.Enabled = false;
            numericUpDown1.Enabled = false;
            label4.Enabled = false;
            numericUpDown2.Enabled = false;
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch(comboBox1.SelectedItem)
            {
                case "decimal": SelectDecimal(); break;
                case "char": case "varchar": SelectChar(); break;
                case "struct": SelectStruct(); break;
                case "array": SelectArray(); break;
                case "map": SelectMap(); break;
                default: SelectSimple(); break;
            }

            ActivateButtonOK();
        }


        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value > numericUpDown1.Value)
                numericUpDown2.Maximum = numericUpDown1.Value;

        }

        private void SetElementType()
        {
            using AddOrEditField child = new(new NameWithDataType("<element>", _elementType));
            if (child.ShowDialog(this) == DialogResult.OK)
            {
                _elementType = (child.Value as DataType)!;
                RefreshElementType();
            }
        }

        private void SetKeyType()
        {
            using AddOrEditField child = new(new NameWithDataType("<key>", _keyType));
            if (child.ShowDialog(this) == DialogResult.OK)
            {
                _keyType = (child.Value as DataType)!;
                RefreshKeyType();
            }
        }

        private void SetValueType()
        {
            using AddOrEditField child = new(new NameWithDataType("<value>", _valueType));
            if (child.ShowDialog(this) == DialogResult.OK)
            {
                _valueType = (child.Value as DataType)!;
                RefreshValueType();
            }
        }

        private void ClearElementType()
        {
            _elementType = new NullType();
            RefreshElementType();
        }

        private void ClearKeyType()
        {
            _keyType = new NullType();
            RefreshKeyType();
        }

        private void ClearValueType()
        {
            _valueType = new NullType();
            RefreshValueType();
        }

        private void RefreshElementType()
        {
            dataGridView2.Rows[0].Cells[1].Value = $"<{_elementType.TypeName}>";
        }

        private void RefreshKeyType()
        {
            dataGridView1.Rows[0].Cells[1].Value = $"<{_keyType.TypeName}>";
        }

        private void RefreshValueType()
        {
            dataGridView1.Rows[1].Cells[1].Value = $"<{_valueType.TypeName}>";
        }


        private void LoadDataType(DataType dataType)
        {
            comboBox1.SelectedItem = dataType.TypeNameSimple;

            if (dataType is DecimalType decimalType)
            {
                numericUpDown1.Value = decimalType.Precission;
                numericUpDown2.Value = decimalType.Scale;
            }
            else if (dataType is CharBaseType type)
                numericUpDown1.Value = type.Length;

            else if (dataType is StructType structType)
            {
                richTextBox1.Text = structType.ToJsonString(false, true, true);
                struct1 = richTextBox1.Text;
                struct2 = string.Join("\r\n", structType.Fields.Select(f => f.Name));
            }

            else if (dataType is ArrayType arrayType)
            {
                _elementType = arrayType.ElementType;

                RefreshElementType();
                checkBox3.Checked = arrayType.ContainsNull;
            }

            else if (dataType is MapType mapType)
            {
                _keyType = mapType.KeyType;
                _valueType = mapType.ValueType;

                RefreshKeyType();
                RefreshValueType();
                checkBox2.Checked = mapType.ValueContainsNull;
            }
        }

        private void LoadStructField(StructField field)
        {
            textBox1.Text = field.Name;

            LoadDataType(field.DataType);
        }

        private void LoadNameWithDataType(NameWithDataType pairNode)
        {
            textBox1.Text = pairNode.Name;
            textBox1.Enabled = false;
            checkBox1.Enabled = false;

            LoadDataType(pairNode.DataType);
        }

        private void InitializeDataGrids()
        {
            dataGridView1.Rows.Add(["KeyType", "<type>", "Configure", "Clear..."]);
            dataGridView1.Rows.Add(["ValueType", "<type>", "Configure", "Clear..."]);

            dataGridView2.Rows.Add(["ElementType", "<type>", "Configure", "Clear..."]);
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (sender is DataGridView dgv)
                dgv?.CurrentCell?.Selected = false;
        }

        private static DataType Coalesce(DataType? type)
        {
            return type ?? new NullType();
        }

        private DataType GetDataType()
        {
            if (comboBox1.SelectedItem is not string dataType)
                return DataType.FromString("void");

            if (dataType == "map")
                return new MapType(Coalesce(_keyType), Coalesce(_valueType), checkBox2.Checked);

            if (dataType == "array")
                return new ArrayType(Coalesce(_elementType), checkBox3.Checked);

            if (dataType == "struct")
            {
                if (radioButton1.Checked)
                {
                    return JsonSchemaToSchema.ParseSchemaJson(richTextBox1.Text);
                }

                StructType structType = new();
                structType.AddFields(richTextBox1.Lines.Select(field => new StructField(field, new StringType())));

                return structType;
            }

            if (dataType == "decimal")
                dataType += $"({numericUpDown1.Value},{numericUpDown2.Value})";
            else if (dataType == "char" || dataType == "varchar")
                dataType += $"({numericUpDown1.Value})";

            return DataType.FromString(dataType);
        }

        private void SaveDataToValue()
        {
            if (Value is DataType)
                Value = GetDataType();

            else if (Value is StructField fieldValue)
            {
                fieldValue.Name = textBox1.Text;
                fieldValue.DataType = GetDataType();
                fieldValue.IsNullable = checkBox1.Checked;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            ActivateButtonOK();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveDataToValue();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error parsing DataType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                /** Row 0: KeyType **/
                if (e.RowIndex == 0)
                    SetKeyType();

                /** Row 1: ValueType **/
                else if (e.RowIndex == 1)
                    SetValueType();
            }
            else if (e.ColumnIndex == 3)
            {
                /** Row 0: KeyType **/
                if (e.RowIndex == 0)
                    ClearKeyType();

                /** Row 1: ValueType **/
                else if (e.RowIndex == 1)
                    ClearValueType();
            }
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                /** Row 0: ElementType **/
                if (e.RowIndex == 0)
                    SetElementType();
            }
            else if (e.ColumnIndex == 3)
            {
                if (e.RowIndex == 0)
                    ClearElementType();
            }
        }

        private string struct1;
        private string struct2;

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                struct2 = richTextBox1.Text;
                richTextBox1.Text = struct1;
            }
            else
            {
                struct1 = richTextBox1.Text;
                richTextBox1.Text = struct2;
            }
        }
    }
}
