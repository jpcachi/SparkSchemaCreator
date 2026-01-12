using SparkSchemaCreator.Json;
using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SparkSchemaCreator.Views
{
    public partial class AdvanceEdit : Form
    {
        internal JsonSparkElement Value { get; private set; }
        internal DataType? DefaultDataType { get; }
        internal AdvanceEdit(ModelData model, StructField? editField = null)
        {
            InitializeComponent();
            customTabControl1.TabPanels["Properties"].Controls.Add(propertyGrid1);
            customTabControl1.TabPanels["Json"].Controls.Add(fastColoredTextBox1);

            if (editField == null)
            {
                StructType value = new(model.Root);
                Value = value;
            }
            else
            {
                StructField value = editField.Clone();
                Value = value;
                DefaultDataType = DataType.Copy(value.DataType);
            }

            propertyGrid1.SelectedObject = Value;
        }

        private void UpdateValue(string value)
        {
            if (Value is StructType root)
            {
                root.UpdateFrom(JsonSchemaToSchema.Instance.ParseSchemaJson(value));
            }
            else if (Value is StructField field)
            {
                field.UpdateFrom(JsonSchemaToSchema.Instance.ParseSchemaField(value));
                field.DataType.DefaultType = DefaultDataType;
            }
        }

        private void CustomTabControl1_SelectedTabChanged(object sender, EventArgs e)
        {
            if (customTabControl1.SelectedTab == 0)
            {
                try
                {
                    string jsonStructField = fastColoredTextBox1.Text;
                    UpdateValue(jsonStructField);

                    propertyGrid1.SelectedObject = Value;
                    propertyGrid1.Refresh();
                }
                catch { }
            }
            else
            {
                fastColoredTextBox1.Text = Value.ToJsonString(false, true, true);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
