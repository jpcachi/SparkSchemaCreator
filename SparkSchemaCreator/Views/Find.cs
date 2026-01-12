using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SparkSchemaCreator.Views
{
    public partial class Find : Form
    {

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                GetNextSearch(textBox1.Text, comboBox1.SelectedIndex <= 0 ? null : comboBox1.Text, checkBox2.Checked, checkBox1.Checked, checkBox3.Checked);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private readonly SearchEngine _parent;

        internal Find(SearchEngine parent)
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
            _parent = parent;
        }

        private void GetNextSearch(string text, string? dataType, bool metadata, bool caseSensitive, bool backwards)
        {
            _parent.GetNextSearch(text, dataType, metadata, caseSensitive, backwards);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GetNextSearch(textBox1.Text, comboBox1.SelectedIndex <= 0 ? null : comboBox1.Text, checkBox2.Checked, checkBox1.Checked, checkBox3.Checked);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (_parent != null)
            {
                _parent.ClearSearch();
                button1.Enabled = true;
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void Find_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
