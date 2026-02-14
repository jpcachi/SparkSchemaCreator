namespace SparkSchemaCreator
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            label1 = new Label();
            button1 = new Button();
            fastColoredTextBox1 = new SparkSchemaCreator.Controls.FastColoredTextBox.FastColoredTextBox();
            groupBox1 = new GroupBox();
            label2 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            groupBox2 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button5 = new Button();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 9);
            label1.Name = "label1";
            label1.Size = new Size(259, 15);
            label1.TabIndex = 0;
            label1.Text = "Edit the content of the Json to infer the schema:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(497, 466);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // fastColoredTextBox1
            // 
            fastColoredTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            fastColoredTextBox1.AutoScrollMinSize = new Size(2, 15);
            fastColoredTextBox1.BracketsHighlightStrategy = SparkSchemaCreator.Controls.FastColoredTextBox.BracketsHighlightStrategy.Strategy2;
            fastColoredTextBox1.DefaultMarkerSize = 8;
            fastColoredTextBox1.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fastColoredTextBox1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fastColoredTextBox1.Language = SparkSchemaCreator.Controls.FastColoredTextBox.Language.JSON;
            fastColoredTextBox1.LeftBracket = '[';
            fastColoredTextBox1.LeftBracket2 = '{';
            fastColoredTextBox1.Location = new Point(13, 28);
            fastColoredTextBox1.Name = "fastColoredTextBox1";
            fastColoredTextBox1.RightBracket = ']';
            fastColoredTextBox1.RightBracket2 = '}';
            fastColoredTextBox1.SelectionColor = Color.FromArgb(60, 30, 144, 255);
            fastColoredTextBox1.ServiceColors = (Controls.FastColoredTextBox.ServiceColors)resources.GetObject("fastColoredTextBox1.ServiceColors");
            fastColoredTextBox1.ShowLineNumbers = false;
            fastColoredTextBox1.Size = new Size(558, 271);
            fastColoredTextBox1.TabIndex = 0;
            fastColoredTextBox1.TextChanged += FastColoredTextBox1_TextChanged;
            fastColoredTextBox1.DragDrop += Editor_DragDrop;
            fastColoredTextBox1.DragEnter += Editor_DragEnter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(12, 305);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(354, 130);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Import Json as";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 30);
            label2.Name = "label2";
            label2.Size = new Size(219, 15);
            label2.TabIndex = 2;
            label2.Text = "Select how the input Json will be parsed:";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(30, 78);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(90, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Sample Json";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(30, 53);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(125, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Spark Schema Json";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button2);
            groupBox2.Location = new Point(372, 305);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 130);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Escaped quotes and format";
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top;
            button4.Location = new Point(27, 88);
            button4.Name = "button4";
            button4.Size = new Size(145, 23);
            button4.TabIndex = 0;
            button4.Text = "Replace escaped \"\" to \"";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Button4_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top;
            button3.Location = new Point(27, 59);
            button3.Name = "button3";
            button3.Size = new Size(145, 23);
            button3.TabIndex = 0;
            button3.Text = "Replace escaped \\\" to \"";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.Location = new Point(27, 30);
            button2.Name = "button2";
            button2.Size = new Size(145, 23);
            button2.TabIndex = 0;
            button2.Text = "Prettify json";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click_1;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.Location = new Point(416, 466);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 2;
            button5.Text = "Cancel";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Button2_Click;
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(584, 501);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(fastColoredTextBox1);
            Controls.Add(button5);
            Controls.Add(button1);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(486, 275);
            Name = "Editor";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editor";
            Paint += Editor_Paint;
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private SparkSchemaCreator.Controls.FastColoredTextBox.FastColoredTextBox fastColoredTextBox1;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox2;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button5;
        private Label label2;
        private ToolTip toolTip1;
    }
}