using SparkSchemaCreator.Converters;
using SparkSchemaCreator.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SparkSchemaCreator.Views
{
    public partial class AddMetadataComplexValue : Form
    {
        internal MetadataKeyValuePair? Value { get; private set; }
        private readonly HashSet<string> _keys;
        internal AddMetadataComplexValue(HashSet<string> keys)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            _keys = keys;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Value = new MetadataKeyValuePair(textBox1.Text, new Metadata(), typeof(Metadata), _keys);
                    break;

                case 1:
                    Value = new MetadataKeyValuePair(textBox1.Text, Array.Empty<string>(), typeof(string[]), _keys);
                    break;

                case 2:
                    Value = new MetadataKeyValuePair(textBox1.Text, Array.Empty<long>(), typeof(long[]), _keys);
                    break;

                case 3:
                    Value = new MetadataKeyValuePair(textBox1.Text, Array.Empty<double>(), typeof(double[]), _keys);
                    break;

                case 4:
                    Value = new MetadataKeyValuePair(textBox1.Text, Array.Empty<bool>(), typeof(bool[]), _keys);
                    break;

                case 5:
                    Value = new MetadataKeyValuePair(textBox1.Text, Array.Empty<Metadata>(), typeof(Metadata[]), _keys);
                    break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text) && !_keys.Contains(textBox1.Text);

            label4.Text = $"Key '{textBox1.Text}' already exists in Metadata";
            label4.Visible = _keys.Contains(textBox1.Text);
        }
    }
}
