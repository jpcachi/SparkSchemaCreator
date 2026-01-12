using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SparkSchemaCreator.Views
{
    public partial class SettingsDialog : Form
    {
        private readonly SchemaSettings schemaSettings;
        internal SettingsDialog()
        {
            InitializeComponent();
            schemaSettings = SchemaSettings.Instance;

            checkBox1.Checked = schemaSettings.IntegersAsLongs;
            checkBox2.Checked = schemaSettings.IncludeEmptyStructAndArrayTypes;
            checkBox3.Checked = schemaSettings.CheckIllegalCharactersInNames;

            switch(schemaSettings.WrapFieldsIn)
            {
                case SchemaSettings.ScalaCollection.Array:
                    radioButton1.Checked = true;
                    break;

                case SchemaSettings.ScalaCollection.List:
                    radioButton2.Checked = true;
                    break;

                case SchemaSettings.ScalaCollection.Seq:
                    radioButton3.Checked = true;
                    break;

                case SchemaSettings.ScalaCollection.DoubleColon:
                    radioButton4.Checked = true;
                    break;
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            using Pen p = new(Color.FromArgb(216, 222, 228));
            e.Graphics.DrawLine(p, 0, 1, panel1.ClientRectangle.Width, 1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            schemaSettings.IntegersAsLongs = checkBox1.Checked;
            schemaSettings.IncludeEmptyStructAndArrayTypes = checkBox2.Checked;
            schemaSettings.CheckIllegalCharactersInNames = checkBox3.Checked;

            if (radioButton1.Checked)
                schemaSettings.WrapFieldsIn = SchemaSettings.ScalaCollection.Array;

            else if (radioButton2.Checked)
                schemaSettings.WrapFieldsIn = SchemaSettings.ScalaCollection.List;

            else if (radioButton3.Checked)
                schemaSettings.WrapFieldsIn = SchemaSettings.ScalaCollection.Seq;

            else
                schemaSettings.WrapFieldsIn = SchemaSettings.ScalaCollection.DoubleColon;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
