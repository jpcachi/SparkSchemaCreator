using SparkSchemaCreator.Controls;
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
    public partial class MetadataPropertyEditor : Form
    {
        private class MetadataHolder
        {
            public Metadata Metadata { get; set; }
            internal MetadataHolder(Metadata metadata)
            {
                Metadata = metadata;
            }
        }

        private readonly MetadataHolder metadataHolder;

        internal Metadata Value => metadataHolder.Metadata;

        internal MetadataPropertyEditor(Metadata metadata)
        {
            InitializeComponent();
            metadataHolder = new MetadataHolder(new Metadata(metadata.Map));

            propertyGrid1.SelectedObject = metadataHolder;
            fastColoredTextBox1.Text = metadataHolder.Metadata.ToJsonString(false, true, true);

            customTabControl1.TabPanels["Metadata"].Controls.Add(propertyGrid1);
            customTabControl1.TabPanels["Json"].Controls.Add(fastColoredTextBox1);
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if(customTabControl1.SelectedTab == 1)
            {
                TryParseJson();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        internal void RefreshProperties()
        {
            propertyGrid1.Refresh();
        }

        private void TryParseJson()
        {
            try
            {
                Metadata newMetadata = JsonSchemaToSchema.ParseMetadata(fastColoredTextBox1.Text);
                metadataHolder.Metadata = newMetadata;
                RefreshProperties();
            }
            catch
            {

            }
        }

        private void CustomTabControl1_SelectedTabChanged(object sender, EventArgs e)
        {
            if (customTabControl1.SelectedTab == 1)
                fastColoredTextBox1.Text = metadataHolder.Metadata.ToJsonString(false, true, true);
            
            else if (customTabControl1.SelectedTab == 0)
                TryParseJson();
            
        }
    }
}
