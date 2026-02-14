namespace SparkSchemaCreator.Views
{
    partial class AddOrEditField
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrEditField));
            checkBox1 = new CheckBox();
            label5 = new Label();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox4 = new GroupBox();
            checkBox2 = new CheckBox();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewButtonColumn();
            Column4 = new DataGridViewLinkColumn();
            groupBox1 = new GroupBox();
            checkBox3 = new CheckBox();
            dataGridView2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewLinkColumn1 = new DataGridViewLinkColumn();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            richTextBox1 = new SparkSchemaCreator.Controls.FastColoredTextBox.FastColoredTextBox();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)richTextBox1).BeginInit();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(333, 14);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(81, 19);
            checkBox1.TabIndex = 23;
            checkBox1.Text = "Is Nullable";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Firebrick;
            label5.Location = new Point(15, 72);
            label5.Name = "label5";
            label5.Size = new Size(307, 15);
            label5.TabIndex = 22;
            label5.Text = "Name contains invalid character(s) among:   \" ,;{}()\\n\\t=\"";
            label5.Visible = false;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown2.Enabled = false;
            numericUpDown2.Location = new Point(397, 70);
            numericUpDown2.Maximum = new decimal(new int[] { 38, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 20;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown1.Enabled = false;
            numericUpDown1.Location = new Point(397, 41);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 21;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Location = new Point(333, 72);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 18;
            label4.Text = "Scale:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Enabled = false;
            label3.Location = new Point(333, 43);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 19;
            label3.Text = "Precision:";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "string", "integer", "short", "long", "float", "double", "decimal", "boolean", "byte", "char", "varchar", "date", "timestamp", "timestamp_ntz", "interval", "interval year", "interval year to month", "interval month", "interval day", "interval day to hour", "interval day to minute", "interval day to second", "interval hour", "interval hour to minute", "interval hour to second", "interval minute", "interval minute to second", "interval second", "binary", "struct", "array", "map" });
            comboBox1.Location = new Point(84, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(238, 23);
            comboBox1.TabIndex = 17;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(84, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 23);
            textBox1.TabIndex = 16;
            textBox1.TextChanged += TextBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 44);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 15;
            label2.Text = "DataType:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 15);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 14;
            label1.Text = "Name:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(checkBox2);
            groupBox4.Controls.Add(dataGridView1);
            groupBox4.Location = new Point(12, 99);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(508, 112);
            groupBox4.TabIndex = 24;
            groupBox4.TabStop = false;
            groupBox4.Text = "MapType";
            groupBox4.Visible = false;
            // 
            // checkBox2
            // 
            checkBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(21, 81);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(129, 19);
            checkBox2.TabIndex = 12;
            checkBox2.Text = "Value Contains Null";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Location = new Point(22, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(463, 46);
            dataGridView1.TabIndex = 25;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            dataGridView1.SelectionChanged += DataGridView_SelectionChanged;
            // 
            // Column1
            // 
            Column1.FillWeight = 50F;
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Resizable = DataGridViewTriState.False;
            // 
            // Column2
            // 
            dataGridViewCellStyle1.ForeColor = SystemColors.Highlight;
            Column2.DefaultCellStyle = dataGridViewCellStyle1;
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Resizable = DataGridViewTriState.False;
            // 
            // Column3
            // 
            Column3.FillWeight = 50F;
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Resizable = DataGridViewTriState.False;
            Column3.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Column4
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Column4.DefaultCellStyle = dataGridViewCellStyle2;
            Column4.FillWeight = 35F;
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Resizable = DataGridViewTriState.False;
            Column4.SortMode = DataGridViewColumnSortMode.Automatic;
            Column4.TrackVisitedState = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(dataGridView2);
            groupBox1.Location = new Point(12, 99);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(508, 83);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "ArrayType";
            groupBox1.Visible = false;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(22, 56);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(98, 19);
            checkBox3.TabIndex = 12;
            checkBox3.Text = "Contains Null";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewButtonColumn1, dataGridViewLinkColumn1 });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView2.Location = new Point(22, 24);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView2.Size = new Size(463, 23);
            dataGridView2.TabIndex = 25;
            dataGridView2.CellContentClick += DataGridView2_CellContentClick;
            dataGridView2.SelectionChanged += DataGridView_SelectionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.FillWeight = 50F;
            dataGridViewTextBoxColumn1.HeaderText = "Column1";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle4.ForeColor = SystemColors.Highlight;
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewTextBoxColumn2.HeaderText = "Column2";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewButtonColumn1.FillWeight = 50F;
            dataGridViewButtonColumn1.HeaderText = "Column3";
            dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            dataGridViewButtonColumn1.ReadOnly = true;
            dataGridViewButtonColumn1.Resizable = DataGridViewTriState.False;
            dataGridViewButtonColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewLinkColumn1
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewLinkColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewLinkColumn1.FillWeight = 35F;
            dataGridViewLinkColumn1.HeaderText = "Column4";
            dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            dataGridViewLinkColumn1.ReadOnly = true;
            dataGridViewLinkColumn1.Resizable = DataGridViewTriState.False;
            dataGridViewLinkColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewLinkColumn1.TrackVisitedState = false;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(richTextBox1);
            groupBox2.Location = new Point(12, 99);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(508, 358);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            groupBox2.Text = "StructType";
            groupBox2.Visible = false;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(radioButton1);
            groupBox3.Controls.Add(radioButton2);
            groupBox3.Location = new Point(6, 268);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(496, 84);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Imput is a";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(23, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(48, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Json";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(23, 47);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(161, 19);
            radioButton2.TabIndex = 0;
            radioButton2.Text = "List of fields (one per line)";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.AutoCompleteBracketsList = new char[]
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
            richTextBox1.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n";
            richTextBox1.AutoScrollMinSize = new Size(2, 15);
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.BracketsHighlightStrategy = SparkSchemaCreator.Controls.FastColoredTextBox.BracketsHighlightStrategy.Strategy2;
            richTextBox1.DefaultMarkerSize = 8;
            richTextBox1.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            richTextBox1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Language = SparkSchemaCreator.Controls.FastColoredTextBox.Language.JSON;
            richTextBox1.LeftBracket = '[';
            richTextBox1.LeftBracket2 = '{';
            richTextBox1.Location = new Point(6, 22);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.RightBracket = ']';
            richTextBox1.RightBracket2 = '}';
            richTextBox1.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            richTextBox1.ServiceColors = (Controls.FastColoredTextBox.ServiceColors)resources.GetObject("richTextBox1.ServiceColors");
            richTextBox1.ShowLineNumbers = false;
            richTextBox1.Size = new Size(496, 240);
            richTextBox1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Enabled = false;
            button2.Location = new Point(364, 475);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 27;
            button2.Text = "OK";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(445, 475);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 28;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // AddComplexTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 510);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddComplexTest";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddComplexTest";
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)richTextBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private Label label5;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private Label label3;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private GroupBox groupBox4;
        private CheckBox checkBox2;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private CheckBox checkBox3;
        private DataGridView dataGridView2;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Controls.FastColoredTextBox.FastColoredTextBox richTextBox1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewButtonColumn Column3;
        private DataGridViewLinkColumn Column4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private DataGridViewLinkColumn dataGridViewLinkColumn1;
        private Button button2;
        private Button button1;
    }
}