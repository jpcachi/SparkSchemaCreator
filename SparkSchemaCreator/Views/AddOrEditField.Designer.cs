using SparkSchemaCreator.Controls.FastColoredTextBox;

namespace SparkSchemaCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrEditField));
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label5 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            richTextBox1 = new FastColoredTextBox();
            groupBox3 = new GroupBox();
            button6 = new Button();
            label8 = new Label();
            label9 = new Label();
            checkBox3 = new CheckBox();
            button4 = new Button();
            label7 = new Label();
            label6 = new Label();
            checkBox2 = new CheckBox();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            groupBox4 = new GroupBox();
            button8 = new Button();
            button7 = new Button();
            label11 = new Label();
            label10 = new Label();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)richTextBox1).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 13);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 42);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "DataType:";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(81, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += TextBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "string", "integer", "short", "long", "float", "double", "decimal", "boolean", "byte", "char", "varchar", "date", "timestamp", "timestamp_ntz", "interval", "interval year", "interval year to month", "interval month", "interval day", "interval day to hour", "interval day to minute", "interval day to second", "interval hour", "interval hour to minute", "interval hour to second", "interval minute", "interval minute to second", "interval second", "binary", "struct", "array", "map" });
            comboBox1.Location = new Point(81, 39);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(238, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Enabled = false;
            label3.Location = new Point(330, 41);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Precision:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Location = new Point(330, 70);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 4;
            label4.Text = "Scale:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown1.Enabled = false;
            numericUpDown1.Location = new Point(394, 39);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown2.Enabled = false;
            numericUpDown2.Location = new Point(394, 68);
            numericUpDown2.Maximum = new decimal(new int[] { 38, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Firebrick;
            label5.Location = new Point(12, 70);
            label5.Name = "label5";
            label5.Size = new Size(307, 15);
            label5.TabIndex = 6;
            label5.Text = "Name contains invalid character(s) among:   \" ,;{}()\\n\\t=\"";
            label5.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(richTextBox1);
            groupBox1.Location = new Point(12, 101);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(508, 358);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "StructType";
            groupBox1.Visible = false;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Controls.Add(radioButton2);
            groupBox2.Location = new Point(6, 268);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(496, 84);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Imput is a";
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
            richTextBox1.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
            richTextBox1.DefaultMarkerSize = 8;
            richTextBox1.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            richTextBox1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Language = Language.JSON;
            richTextBox1.LeftBracket = '[';
            richTextBox1.LeftBracket2 = '{';
            richTextBox1.Location = new Point(6, 22);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.RightBracket = ']';
            richTextBox1.RightBracket2 = '}';
            richTextBox1.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            //richTextBox1.ServiceColors = (ServiceColors)resources.GetObject("richTextBox1.ServiceColors");
            richTextBox1.ShowLineNumbers = false;
            richTextBox1.Size = new Size(496, 240);
            richTextBox1.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(button6);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(checkBox3);
            groupBox3.Controls.Add(button4);
            groupBox3.Location = new Point(12, 101);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(508, 88);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "ArrayType";
            groupBox3.Visible = false;
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.Location = new Point(245, 26);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 15;
            button6.Text = "Clear...";
            button6.UseVisualStyleBackColor = true;
            button6.Click += ClearArrayElementType;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.Highlight;
            label8.Location = new Point(107, 30);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 14;
            label8.Text = "<null>";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(20, 30);
            label9.Name = "label9";
            label9.Size = new Size(81, 15);
            label9.TabIndex = 13;
            label9.Text = "Element Type:";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(20, 55);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(98, 19);
            checkBox3.TabIndex = 12;
            checkBox3.Text = "Contains Null";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(156, 26);
            button4.Name = "button4";
            button4.Size = new Size(83, 23);
            button4.TabIndex = 11;
            button4.Text = "Configure";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Button4_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.Highlight;
            label7.Location = new Point(89, 30);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 14;
            label7.Text = "<null>";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 30);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 13;
            label6.Text = "KeyType:";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(21, 94);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(129, 19);
            checkBox2.TabIndex = 12;
            checkBox2.Text = "Value Contains Null";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(156, 26);
            button3.Name = "button3";
            button3.Size = new Size(83, 23);
            button3.TabIndex = 11;
            button3.Text = "Configure";
            button3.UseVisualStyleBackColor = true;
            button3.Click += SetMapKeyTypeButtonClick;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(445, 473);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(364, 473);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "OK";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(330, 12);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(81, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Is Nullable";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(button8);
            groupBox4.Controls.Add(button7);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(checkBox2);
            groupBox4.Controls.Add(button5);
            groupBox4.Controls.Add(button3);
            groupBox4.Location = new Point(12, 101);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(508, 125);
            groupBox4.TabIndex = 13;
            groupBox4.TabStop = false;
            groupBox4.Text = "MapType";
            groupBox4.Visible = false;
            // 
            // button8
            // 
            button8.Enabled = false;
            button8.Location = new Point(245, 55);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 15;
            button8.Text = "Clear...";
            button8.UseVisualStyleBackColor = true;
            button8.Click += ClearMapValueType;
            // 
            // button7
            // 
            button7.Enabled = false;
            button7.Location = new Point(245, 26);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 15;
            button7.Text = "Clear...";
            button7.UseVisualStyleBackColor = true;
            button7.Click += ClearMapKeyType;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = SystemColors.Highlight;
            label11.Location = new Point(89, 59);
            label11.Name = "label11";
            label11.Size = new Size(43, 15);
            label11.TabIndex = 14;
            label11.Text = "<null>";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(20, 59);
            label10.Name = "label10";
            label10.Size = new Size(63, 15);
            label10.TabIndex = 13;
            label10.Text = "ValueType:";
            // 
            // button5
            // 
            button5.Location = new Point(156, 55);
            button5.Name = "button5";
            button5.Size = new Size(83, 23);
            button5.TabIndex = 11;
            button5.Text = "Configure";
            button5.UseVisualStyleBackColor = true;
            button5.Click += SetMapValueTypeButtonClick;
            // 
            // AddOrEditField2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 510);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
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
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddOrEditField2";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddOrEditField";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)richTextBox1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label5;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox2;
        private FastColoredTextBox richTextBox1;
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private Button button3;
        private CheckBox checkBox2;
        private GroupBox groupBox4;
        private Label label6;
        private Label label7;
        private GroupBox groupBox3;
        private Label label8;
        private Label label9;
        private CheckBox checkBox3;
        private Button button4;
        private Label label11;
        private Label label10;
        private Button button5;
        private Button button6;
        private Button button8;
        private Button button7;
    }
}