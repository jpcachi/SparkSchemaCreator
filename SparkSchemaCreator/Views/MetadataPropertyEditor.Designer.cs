namespace SparkSchemaCreator.Views
{
    partial class MetadataPropertyEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetadataPropertyEditor));
            propertyGrid1 = new PropertyGrid();
            buttonCancel = new Button();
            buttonOK = new Button();
            customTabControl1 = new SparkSchemaCreator.Controls.CustomTabControl();
            fastColoredTextBox1 = new SparkSchemaCreator.Controls.FastColoredTextBox.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).BeginInit();
            SuspendLayout();
            // 
            // propertyGrid1
            // 
            propertyGrid1.BackColor = SystemColors.Control;
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.HelpVisible = false;
            propertyGrid1.Location = new Point(0, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(637, 413);
            propertyGrid1.TabIndex = 0;
            propertyGrid1.ToolbarVisible = false;
            propertyGrid1.ViewBorderColor = SystemColors.Window;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(550, 378);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(469, 378);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ButtonOK_Click;
            // 
            // customTabControl1
            // 
            customTabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customTabControl1.BackColor = Color.Transparent;
            customTabControl1.Location = new Point(12, 12);
            customTabControl1.Name = "customTabControl1";
            customTabControl1.SelectedTabBackColor = SystemColors.ButtonHighlight;
            customTabControl1.SelectedTabBorderColor = Color.FromArgb(186, 197, 207);
            customTabControl1.SelectedTabForeColor = Color.FromArgb(36, 41, 47);
            customTabControl1.SelectedTabMouseDownBackColor = SystemColors.ButtonHighlight;
            customTabControl1.SelectedTabMouseOverBackColor = SystemColors.ButtonHighlight;
            customTabControl1.Size = new Size(613, 360);
            customTabControl1.TabBackColor = Color.FromArgb(246, 248, 250);
            customTabControl1.TabForeColor = Color.FromArgb(36, 41, 47);
            customTabControl1.TabIndex = 2;
            customTabControl1.TabMouseDownBackColor = Color.FromArgb(221, 244, 254);
            customTabControl1.TabMouseOverBackColor = Color.FromArgb(167, 217, 253);
            customTabControl1.Tabs = new string[]
    {
    "Metadata",
    "Json"
    };
            customTabControl1.SelectedTabChanged += CustomTabControl1_SelectedTabChanged;
            // 
            // fastColoredTextBox1
            // 
            fastColoredTextBox1.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            fastColoredTextBox1.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n";
            fastColoredTextBox1.AutoScrollMinSize = new Size(135, 15);
            fastColoredTextBox1.BracketsHighlightStrategy = SparkSchemaCreator.Controls.FastColoredTextBox.BracketsHighlightStrategy.Strategy2;
            fastColoredTextBox1.DefaultMarkerSize = 8;
            fastColoredTextBox1.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fastColoredTextBox1.Dock = DockStyle.Fill;
            fastColoredTextBox1.FoldingIndicatorColor = Color.SkyBlue;
            fastColoredTextBox1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fastColoredTextBox1.Language = SparkSchemaCreator.Controls.FastColoredTextBox.Language.JSON;
            fastColoredTextBox1.LeftBracket = '[';
            fastColoredTextBox1.LeftBracket2 = '{';
            fastColoredTextBox1.Location = new Point(0, 0);
            fastColoredTextBox1.Name = "fastColoredTextBox1";
            fastColoredTextBox1.RightBracket = ']';
            fastColoredTextBox1.RightBracket2 = '}';
            fastColoredTextBox1.SelectionColor = Color.FromArgb(60, 30, 144, 255);
            fastColoredTextBox1.ServiceColors = (Controls.FastColoredTextBox.ServiceColors)resources.GetObject("fastColoredTextBox1.ServiceColors");
            fastColoredTextBox1.Size = new Size(637, 413);
            fastColoredTextBox1.TabIndex = 3;
            fastColoredTextBox1.Text = "fastColoredTextBox1";
            // 
            // MetadataPropertyEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(637, 413);
            Controls.Add(customTabControl1);
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);
            Controls.Add(propertyGrid1);
            Controls.Add(fastColoredTextBox1);
            Name = "MetadataPropertyEditor";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Metadata Editor";
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PropertyGrid propertyGrid1;
        private Button buttonCancel;
        private Button buttonOK;
        private Controls.CustomTabControl customTabControl1;
        private SparkSchemaCreator.Controls.FastColoredTextBox.FastColoredTextBox fastColoredTextBox1;
    }
}