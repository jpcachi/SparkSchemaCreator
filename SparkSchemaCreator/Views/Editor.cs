using SparkSchemaCreator.Json;
using SparkSchemaCreator.Properties;
using SparkSchemaCreator.Types;
using SparkSchemaCreator.Utils;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SparkSchemaCreator
{
    public partial class Editor : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsSample { get; private set; }

        internal StructType? Value { get; private set; }

        internal Editor(string value = "")
        {
            InitializeComponent();
            Icon = Resources.editor_icon;

            IsSample = false;

            fastColoredTextBox1.Text = value;
            button1.Enabled = !string.IsNullOrWhiteSpace(value);
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            IsSample = radioButton2.Checked;
            Value = StructFieldUtils.ParseStringToSchema(fastColoredTextBox1.Text, IsSample);

            if (Value == null)
                return;

            DialogResult = DialogResult.OK;
            ReleaseEditor();
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            ReleaseEditor();
            Close();
        }

        private void ReleaseEditor()
        {
            fastColoredTextBox1.Clear();
            fastColoredTextBox1.Dispose();
            GC.Collect();
        }

        private static string StripWhiteSpacesAndQuotes(string text)
        {
            string trimText = text.Trim();

            if (trimText.StartsWith('\"') && trimText.EndsWith('\"'))
            {
                trimText = trimText[1..^1];
            }

            return trimText;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string prettyJson = JsonUtils.FormatJson(fastColoredTextBox1.Text, Newtonsoft.Json.Formatting.Indented);
                fastColoredTextBox1.Text = prettyJson;
            }
            catch (Exception)
            {
                toolTip1.SetToolTip(button2, "Input is not a valid json.");
            }
        }

        [GeneratedRegex(@"([:\[,{]\s*)\\""(.*?)\\""(?=\s*[:,\]}])")]
        private static partial Regex UnescapeSlashQuoteRegex();

        private void Button3_Click(object sender, EventArgs e)
        {
            string jsonCleaned = UnescapeSlashQuoteRegex().Replace(StripWhiteSpacesAndQuotes(fastColoredTextBox1.Text), "$1\"$2\"");
            try
            {
                string prettyJson = JsonUtils.FormatJson(jsonCleaned, Newtonsoft.Json.Formatting.Indented);
                fastColoredTextBox1.Text = prettyJson;
            }
            catch (Exception)
            {
                fastColoredTextBox1.Text = jsonCleaned;
                toolTip1.SetToolTip(button3, "Input is not a valid json.");
            }
        }


        [GeneratedRegex(@"([:\[,{]\s*)""""(.*?)""""(?=\s*[:,\]}])")]
        private static partial Regex UnescapeQuoteQuoteRegex();
        private void Button4_Click(object sender, EventArgs e)
        {
            string jsonCleaned = UnescapeQuoteQuoteRegex().Replace(StripWhiteSpacesAndQuotes(fastColoredTextBox1.Text), @"$1""$2""").Replace(@"\""""", @"\""");
            try
            {
                string prettyJson = JsonUtils.FormatJson(jsonCleaned, Newtonsoft.Json.Formatting.Indented);
                fastColoredTextBox1.Text = prettyJson;
            }
            catch (Exception)
            {
                fastColoredTextBox1.Text = jsonCleaned;
                toolTip1.SetToolTip(button4, "Input is not a valid json.");
            }
        }

        private void Editor_Paint(object sender, PaintEventArgs e)
        {
            using (Brush b = new SolidBrush(Color.FromArgb(246, 248, 250)))
            {
                e.Graphics.FillRectangle(b, new Rectangle(ClientRectangle.Left, ClientRectangle.Bottom - 55, ClientRectangle.Width, 55));
            }

            using Pen p = new(Color.FromArgb(216, 222, 228));
            e.Graphics.DrawRectangle(p, fastColoredTextBox1.Location.X - 1, fastColoredTextBox1.Location.Y - 1, fastColoredTextBox1.Width + 1, fastColoredTextBox1.Height + 1);
            e.Graphics.DrawLine(p, ClientRectangle.Left, ClientRectangle.Bottom - 55, ClientRectangle.Right, ClientRectangle.Bottom - 55);
        }

        private void TextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void TextBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data?.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                try
                {
                    string file = files[0];
                    fastColoredTextBox1.Text = File.ReadAllText(file);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while importing the file:\n\n" + ex.Message, "Import Json", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FastColoredTextBox1_TextChanged(object sender, Controls.FastColoredTextBox.TextChangedEventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(fastColoredTextBox1.Text);
        }

        private void Editor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }

        private void Editor_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                fastColoredTextBox1.Clear();
                fastColoredTextBox1.Text = File.ReadAllText(files[0]);
            }
        }
    }
}
