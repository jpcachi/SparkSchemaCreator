namespace SparkSchemaCreator.Views
{
    partial class FindChildren
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
            label1 = new Label();
            textBox1 = new TextBox();
            panelWithHeader3 = new SparkSchemaCreator.Controls.PanelWithHeader();
            textBox2 = new TextBox();
            panelWithHeader1 = new SparkSchemaCreator.Controls.PanelWithHeader();
            textBox3 = new TextBox();
            button1 = new Button();
            checkBox1 = new CheckBox();
            panelWithHeader3.ContentsPanel.SuspendLayout();
            panelWithHeader1.ContentsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(349, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter the name of the fields you want to search for (one per line):";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(376, 441);
            textBox1.TabIndex = 1;
            // 
            // panelWithHeader3
            // 
            panelWithHeader3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelWithHeader3.BorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader3.ContentBorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader3.ContentPanelBackColor = SystemColors.Window;
            panelWithHeader3.ContentPanelForeColor = SystemColors.ControlText;
            // 
            // 
            // 
            panelWithHeader3.ContentsPanel.BackColor = SystemColors.Window;
            panelWithHeader3.ContentsPanel.Controls.Add(textBox2);
            panelWithHeader3.ContentsPanel.Dock = DockStyle.Fill;
            panelWithHeader3.ContentsPanel.ForeColor = SystemColors.ControlText;
            panelWithHeader3.ContentsPanel.Location = new Point(0, 21);
            panelWithHeader3.ContentsPanel.Margin = new Padding(0);
            panelWithHeader3.ContentsPanel.Name = "contentsPanel";
            panelWithHeader3.ContentsPanel.Padding = new Padding(1, 0, 1, 1);
            panelWithHeader3.ContentsPanel.Size = new Size(394, 204);
            panelWithHeader3.ContentsPanel.TabIndex = 0;
            panelWithHeader3.ContentsPanel.Tag = "Content";
            panelWithHeader3.Location = new Point(394, 12);
            panelWithHeader3.MaximizeBox = false;
            panelWithHeader3.Name = "panelWithHeader3";
            panelWithHeader3.Size = new Size(394, 225);
            panelWithHeader3.TabIndex = 2;
            panelWithHeader3.Title = "Fields found";
            panelWithHeader3.TitleBackColor = Color.FromArgb(216, 222, 228);
            panelWithHeader3.TitleDetailsColor = Color.FromArgb(36, 41, 47);
            panelWithHeader3.TitleForeColor = Color.FromArgb(36, 41, 47);
            panelWithHeader3.WindowBackColor = SystemColors.Window;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.ForeColor = Color.DarkGreen;
            textBox2.Location = new Point(1, 0);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(392, 203);
            textBox2.TabIndex = 2;
            // 
            // panelWithHeader1
            // 
            panelWithHeader1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelWithHeader1.BorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader1.ContentBorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader1.ContentPanelBackColor = SystemColors.Window;
            panelWithHeader1.ContentPanelForeColor = SystemColors.ControlText;
            // 
            // 
            // 
            panelWithHeader1.ContentsPanel.BackColor = SystemColors.Window;
            panelWithHeader1.ContentsPanel.Controls.Add(textBox3);
            panelWithHeader1.ContentsPanel.Dock = DockStyle.Fill;
            panelWithHeader1.ContentsPanel.ForeColor = SystemColors.ControlText;
            panelWithHeader1.ContentsPanel.Location = new Point(0, 21);
            panelWithHeader1.ContentsPanel.Margin = new Padding(0);
            panelWithHeader1.ContentsPanel.Name = "contentsPanel";
            panelWithHeader1.ContentsPanel.Padding = new Padding(1, 0, 1, 1);
            panelWithHeader1.ContentsPanel.Size = new Size(394, 204);
            panelWithHeader1.ContentsPanel.TabIndex = 0;
            panelWithHeader1.ContentsPanel.Tag = "Content";
            panelWithHeader1.Location = new Point(394, 243);
            panelWithHeader1.MaximizeBox = false;
            panelWithHeader1.Name = "panelWithHeader1";
            panelWithHeader1.Size = new Size(394, 225);
            panelWithHeader1.TabIndex = 2;
            panelWithHeader1.Title = "Fields not found";
            panelWithHeader1.TitleBackColor = Color.FromArgb(216, 222, 228);
            panelWithHeader1.TitleDetailsColor = Color.FromArgb(36, 41, 47);
            panelWithHeader1.TitleForeColor = Color.FromArgb(36, 41, 47);
            panelWithHeader1.WindowBackColor = SystemColors.Window;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Dock = DockStyle.Fill;
            textBox3.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.ForeColor = Color.Firebrick;
            textBox3.Location = new Point(1, 0);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.Size = new Size(392, 203);
            textBox3.TabIndex = 3;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(358, 493);
            button1.Name = "button1";
            button1.Size = new Size(85, 23);
            button1.TabIndex = 3;
            button1.Text = "Search fields";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 474);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(86, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Match &case";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // FindChildren
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 528);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(panelWithHeader1);
            Controls.Add(panelWithHeader3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FindChildren";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Find Children";
            panelWithHeader3.ContentsPanel.ResumeLayout(false);
            panelWithHeader3.ContentsPanel.PerformLayout();
            panelWithHeader1.ContentsPanel.ResumeLayout(false);
            panelWithHeader1.ContentsPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Controls.PanelWithHeader panelWithHeader3;
        private Controls.PanelWithHeader panelWithHeader1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private CheckBox checkBox1;
    }
}