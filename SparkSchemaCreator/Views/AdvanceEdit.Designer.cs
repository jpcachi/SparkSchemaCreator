using SparkSchemaCreator.Controls;

namespace SparkSchemaCreator.Views
{
    partial class AdvanceEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvanceEdit));
            customTabControl1 = new Controls.CustomTabControl();
            propertyGrid1 = new PropertyGrid();
            fastColoredTextBox1 = new Controls.FastColoredTextBox.FastColoredTextBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).BeginInit();
            SuspendLayout();
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
            customTabControl1.TabIndex = 3;
            customTabControl1.TabMouseDownBackColor = Color.FromArgb(221, 244, 254);
            customTabControl1.TabMouseOverBackColor = Color.FromArgb(167, 217, 253);
            customTabControl1.Tabs = new string[]
    {
    "Properties",
    "Json"
    };
            customTabControl1.SelectedTabChanged += CustomTabControl1_SelectedTabChanged;
            // 
            // propertyGrid1
            // 
            propertyGrid1.BackColor = SystemColors.Window;
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.Location = new Point(0, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(637, 413);
            propertyGrid1.TabIndex = 4;
            propertyGrid1.ToolbarVisible = false;
            propertyGrid1.ViewBorderColor = SystemColors.Window;
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
            fastColoredTextBox1.AutoScrollMinSize = new Size(2, 14);
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
            //fastColoredTextBox1.ServiceColors = (Controls.FastColoredTextBox.ServiceColors)resources.GetObject("fastColoredTextBox1.ServiceColors");
            fastColoredTextBox1.Size = new Size(637, 413);
            fastColoredTextBox1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(550, 378);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(469, 378);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "OK";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // AdvanceEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(637, 413);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(customTabControl1);
            Controls.Add(propertyGrid1);
            Controls.Add(fastColoredTextBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdvanceEdit";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Advance Editor";
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Controls.CustomTabControl customTabControl1;
        private PropertyGrid propertyGrid1;
        private Controls.FastColoredTextBox.FastColoredTextBox fastColoredTextBox1;
        private Button button1;
        private Button button2;
    }
}