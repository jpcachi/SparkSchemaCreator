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
    public partial class MetadataKeyValueEditor : Form
    {
        internal Metadata ParentMetadata { get; }

        internal Tuple<string, object?>? Value { get; private set; }
        internal MetadataKeyValueEditor(Metadata parent, string? key = null, string? value = null)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            ParentMetadata = parent;
            richTextBox1.Text = parent.ToJsonString();

            if (key != null)
            {
                Value = new Tuple<string, object?>(key, value);

                textBox1.Text = key;
                textBox2.Text = value;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //index 0: simple value
            if (comboBox1.SelectedIndex == 0)
            {
                label3.Visible = true;
                textBox3.Visible = true;
                groupBox1.Visible = false;
                return;
            }

            //index 1: Metadata o index 3: Metadata Array
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 3)
            {
                label3.Visible = false;
                textBox3.Visible = false;
                groupBox1.Visible = false;
                return;
            }

            //index 2: Simple Array
            if (comboBox1.SelectedIndex == 2)
            {
                label3.Visible = false;
                textBox3.Visible = false;
                groupBox1.Visible = true;
                return;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0: Value = new Tuple<string, object?>(textBox1.Text, textBox3.Text); break;
                case 1: Value = new Tuple<string, object?>(textBox1.Text, new Metadata()); break;
                case 2: Value = new Tuple<string, object?>(textBox1.Text, textBox2.Lines); break;
                case 3: Value = new Tuple<string, object?>(textBox1.Text, Array.Empty<Metadata>()); break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
