using SparkSchemaCreator.Controls;

namespace SparkSchemaCreator.Views
{
    partial class SchemaComparer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchemaComparer));
            button1 = new Button();
            panelWithHeader1 = new PanelWithHeader();
            fastTreeSchema1 = new FastTree();
            panel1 = new Panel();
            buttonClear1 = new ButtonWithNoCue();
            buttonWithNoCue4 = new ButtonWithNoCue();
            buttonEdit1 = new ButtonWithNoCue();
            buttonOpen1 = new ButtonWithNoCue();
            panel2 = new Panel();
            buttonClear2 = new ButtonWithNoCue();
            buttonEdit2 = new ButtonWithNoCue();
            buttonOpen2 = new ButtonWithNoCue();
            panelWithHeader2 = new PanelWithHeader();
            fastTreeSchema2 = new FastTree();
            imageList1 = new ImageList(components);
            checkBox1 = new CheckBox();
            fastColoredTextBoxLeft = new SparkSchemaCreator.Controls.FastColoredTextBox.FastColoredTextBox();
            fastColoredTextBoxRight = new SparkSchemaCreator.Controls.FastColoredTextBox.FastColoredTextBox();
            checkBox2 = new CheckBox();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            linkLabel1 = new LinkLabel();
            label5 = new Label();
            button2 = new Button();
            label1 = new Label();
            label4 = new Label();
            panelWithHeader4 = new PanelWithHeader();
            panelWithHeader3 = new PanelWithHeader();
            label3 = new Label();
            label2 = new Label();
            panelWithHeader1.ContentsPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelWithHeader2.ContentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBoxLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBoxRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panelWithHeader4.ContentsPanel.SuspendLayout();
            panelWithHeader3.ContentsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(541, 760);
            button1.Name = "button1";
            button1.Size = new Size(89, 23);
            button1.TabIndex = 1;
            button1.Text = "Compare";
            button1.UseVisualStyleBackColor = true;
            button1.Click += CompareButtonClick;
            // 
            // panelWithHeader1
            // 
            panelWithHeader1.BorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader1.ContentBorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader1.ContentPanelBackColor = SystemColors.Window;
            panelWithHeader1.ContentPanelForeColor = SystemColors.ControlText;
            // 
            // 
            // 
            panelWithHeader1.ContentsPanel.BackColor = SystemColors.Window;
            panelWithHeader1.ContentsPanel.Controls.Add(fastTreeSchema1);
            panelWithHeader1.ContentsPanel.Controls.Add(panel1);
            panelWithHeader1.ContentsPanel.Dock = DockStyle.Fill;
            panelWithHeader1.ContentsPanel.ForeColor = SystemColors.ControlText;
            panelWithHeader1.ContentsPanel.Location = new Point(0, 21);
            panelWithHeader1.ContentsPanel.Margin = new Padding(0);
            panelWithHeader1.ContentsPanel.Name = "contentsPanel";
            panelWithHeader1.ContentsPanel.Padding = new Padding(1, 0, 1, 1);
            panelWithHeader1.ContentsPanel.Size = new Size(572, 429);
            panelWithHeader1.ContentsPanel.TabIndex = 0;
            panelWithHeader1.ContentsPanel.Tag = "Content";
            panelWithHeader1.Dock = DockStyle.Fill;
            panelWithHeader1.Location = new Point(0, 0);
            panelWithHeader1.MaximizeBox = false;
            panelWithHeader1.Name = "panelWithHeader1";
            panelWithHeader1.PreferredWindowSize = new Size(500, 500);
            panelWithHeader1.Size = new Size(572, 450);
            panelWithHeader1.TabIndex = 4;
            panelWithHeader1.Title = "First to compare";
            panelWithHeader1.TitleBackColor = Color.FromArgb(216, 222, 228);
            panelWithHeader1.TitleDetailsColor = Color.FromArgb(36, 41, 47);
            panelWithHeader1.TitleForeColor = Color.FromArgb(36, 41, 47);
            panelWithHeader1.WindowBackColor = SystemColors.Window;
            // 
            // fastTreeSchema1
            // 
            fastTreeSchema1.AllowDrop = true;
            fastTreeSchema1.AutoScroll = true;
            fastTreeSchema1.BackColor = SystemColors.Window;
            fastTreeSchema1.Dock = DockStyle.Fill;
            fastTreeSchema1.Location = new Point(1, 33);
            fastTreeSchema1.Name = "fastTreeSchema1";
            fastTreeSchema1.Padding = new Padding(5, 8, 0, 0);
            fastTreeSchema1.Readonly = true;
            fastTreeSchema1.SelectionColor = SystemColors.Highlight;
            fastTreeSchema1.ShowEmptyExpandBoxes = false;
            fastTreeSchema1.ShowExpandBoxes = true;
            fastTreeSchema1.ShowIcons = true;
            fastTreeSchema1.ShowRootNode = true;
            fastTreeSchema1.Size = new Size(570, 395);
            fastTreeSchema1.TabIndex = 6;
            fastTreeSchema1.NodeTextNeeded += FastTreeSchema_NodeTextNeeded;
            fastTreeSchema1.NodeIconNeeded += FastTreeSchema_NodeIconNeeded;
            fastTreeSchema1.NodeBackColorNeeded += FastTreeSchema_NodeBackColorNeeded;
            fastTreeSchema1.NodeForeColorNeeded += FastTreeSchema_NodeForeColorNeeded;
            fastTreeSchema1.NodeVisibilityNeeded += FastTreeSchema_NodeVisibilityNeeded;
            fastTreeSchema1.NodeSelectedStateChanged += FastTreeSchema_NodeSelectedStateChanged;
            fastTreeSchema1.NodeChildrenNeeded += FastTreeSchema_NodeChildrenNeeded;
            fastTreeSchema1.DragDrop += Schema1_DragDrop;
            fastTreeSchema1.DragEnter += Schema_DragEnter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(216, 222, 228);
            panel1.Controls.Add(buttonClear1);
            panel1.Controls.Add(buttonWithNoCue4);
            panel1.Controls.Add(buttonEdit1);
            panel1.Controls.Add(buttonOpen1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(570, 33);
            panel1.TabIndex = 3;
            // 
            // buttonClear1
            // 
            buttonClear1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClear1.FlatAppearance.BorderColor = Color.FromArgb(216, 222, 228);
            buttonClear1.FlatAppearance.BorderSize = 0;
            buttonClear1.FlatAppearance.MouseDownBackColor = Color.White;
            buttonClear1.FlatAppearance.MouseOverBackColor = Color.FromArgb(246, 248, 250);
            buttonClear1.FlatStyle = FlatStyle.Flat;
            buttonClear1.ForeColor = Color.FromArgb(36, 41, 47);
            buttonClear1.Image = Properties.Resources.Clear2;
            buttonClear1.Location = new Point(504, 7);
            buttonClear1.Name = "buttonClear1";
            buttonClear1.Size = new Size(63, 23);
            buttonClear1.TabIndex = 6;
            buttonClear1.Text = "Clear";
            buttonClear1.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonClear1.UseVisualStyleBackColor = true;
            buttonClear1.Click += ButtonClear1_Click;
            // 
            // buttonWithNoCue4
            // 
            buttonWithNoCue4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonWithNoCue4.FlatAppearance.BorderColor = Color.FromArgb(216, 222, 228);
            buttonWithNoCue4.FlatAppearance.BorderSize = 0;
            buttonWithNoCue4.FlatAppearance.MouseDownBackColor = Color.White;
            buttonWithNoCue4.FlatAppearance.MouseOverBackColor = Color.FromArgb(246, 248, 250);
            buttonWithNoCue4.FlatStyle = FlatStyle.Flat;
            buttonWithNoCue4.ForeColor = Color.FromArgb(36, 41, 47);
            buttonWithNoCue4.Image = Properties.Resources.Clear2;
            buttonWithNoCue4.Location = new Point(915, 7);
            buttonWithNoCue4.Name = "buttonWithNoCue4";
            buttonWithNoCue4.Size = new Size(63, 23);
            buttonWithNoCue4.TabIndex = 5;
            buttonWithNoCue4.Text = "Clear";
            buttonWithNoCue4.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonWithNoCue4.UseVisualStyleBackColor = true;
            // 
            // buttonEdit1
            // 
            buttonEdit1.FlatAppearance.BorderColor = Color.FromArgb(216, 222, 228);
            buttonEdit1.FlatAppearance.BorderSize = 0;
            buttonEdit1.FlatAppearance.MouseDownBackColor = Color.White;
            buttonEdit1.FlatAppearance.MouseOverBackColor = Color.FromArgb(246, 248, 250);
            buttonEdit1.FlatStyle = FlatStyle.Flat;
            buttonEdit1.ForeColor = Color.FromArgb(36, 41, 47);
            buttonEdit1.Image = Properties.Resources.editor_16;
            buttonEdit1.Location = new Point(116, 7);
            buttonEdit1.Name = "buttonEdit1";
            buttonEdit1.Size = new Size(134, 23);
            buttonEdit1.TabIndex = 5;
            buttonEdit1.Text = " Import or edit json";
            buttonEdit1.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonEdit1.UseVisualStyleBackColor = true;
            buttonEdit1.Click += ButtonEdit1_Click;
            // 
            // buttonOpen1
            // 
            buttonOpen1.FlatAppearance.BorderColor = Color.FromArgb(216, 222, 228);
            buttonOpen1.FlatAppearance.BorderSize = 0;
            buttonOpen1.FlatAppearance.MouseDownBackColor = Color.White;
            buttonOpen1.FlatAppearance.MouseOverBackColor = Color.FromArgb(246, 248, 250);
            buttonOpen1.FlatStyle = FlatStyle.Flat;
            buttonOpen1.ForeColor = Color.FromArgb(36, 41, 47);
            buttonOpen1.Image = Properties.Resources.import;
            buttonOpen1.Location = new Point(3, 7);
            buttonOpen1.Name = "buttonOpen1";
            buttonOpen1.Size = new Size(107, 23);
            buttonOpen1.TabIndex = 5;
            buttonOpen1.Text = " Open json file";
            buttonOpen1.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonOpen1.UseVisualStyleBackColor = true;
            buttonOpen1.Click += ButtonOpen1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(216, 222, 228);
            panel2.Controls.Add(buttonClear2);
            panel2.Controls.Add(buttonEdit2);
            panel2.Controls.Add(buttonOpen2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(1, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(570, 33);
            panel2.TabIndex = 2;
            // 
            // buttonClear2
            // 
            buttonClear2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClear2.FlatAppearance.BorderColor = Color.FromArgb(216, 222, 228);
            buttonClear2.FlatAppearance.BorderSize = 0;
            buttonClear2.FlatAppearance.MouseDownBackColor = Color.White;
            buttonClear2.FlatAppearance.MouseOverBackColor = Color.FromArgb(246, 248, 250);
            buttonClear2.FlatStyle = FlatStyle.Flat;
            buttonClear2.ForeColor = Color.FromArgb(36, 41, 47);
            buttonClear2.Image = Properties.Resources.Clear2;
            buttonClear2.Location = new Point(504, 7);
            buttonClear2.Name = "buttonClear2";
            buttonClear2.Size = new Size(63, 23);
            buttonClear2.TabIndex = 5;
            buttonClear2.Text = "Clear";
            buttonClear2.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonClear2.UseVisualStyleBackColor = true;
            buttonClear2.Click += ButtonClear2_Click;
            // 
            // buttonEdit2
            // 
            buttonEdit2.FlatAppearance.BorderColor = Color.FromArgb(216, 222, 228);
            buttonEdit2.FlatAppearance.BorderSize = 0;
            buttonEdit2.FlatAppearance.MouseDownBackColor = Color.White;
            buttonEdit2.FlatAppearance.MouseOverBackColor = Color.FromArgb(246, 248, 250);
            buttonEdit2.FlatStyle = FlatStyle.Flat;
            buttonEdit2.ForeColor = Color.FromArgb(36, 41, 47);
            buttonEdit2.Image = Properties.Resources.editor_16;
            buttonEdit2.Location = new Point(116, 7);
            buttonEdit2.Name = "buttonEdit2";
            buttonEdit2.Size = new Size(134, 23);
            buttonEdit2.TabIndex = 5;
            buttonEdit2.Text = " Import or edit json";
            buttonEdit2.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonEdit2.UseVisualStyleBackColor = true;
            buttonEdit2.Click += ButtonEdit2_Click;
            // 
            // buttonOpen2
            // 
            buttonOpen2.FlatAppearance.BorderColor = Color.FromArgb(216, 222, 228);
            buttonOpen2.FlatAppearance.BorderSize = 0;
            buttonOpen2.FlatAppearance.MouseDownBackColor = Color.White;
            buttonOpen2.FlatAppearance.MouseOverBackColor = Color.FromArgb(246, 248, 250);
            buttonOpen2.FlatStyle = FlatStyle.Flat;
            buttonOpen2.ForeColor = Color.FromArgb(36, 41, 47);
            buttonOpen2.Image = Properties.Resources.import;
            buttonOpen2.Location = new Point(3, 7);
            buttonOpen2.Name = "buttonOpen2";
            buttonOpen2.Size = new Size(107, 23);
            buttonOpen2.TabIndex = 5;
            buttonOpen2.Text = " Open json file";
            buttonOpen2.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonOpen2.UseVisualStyleBackColor = true;
            buttonOpen2.Click += ButtonOpen2_Click;
            // 
            // panelWithHeader2
            // 
            panelWithHeader2.BorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader2.ContentBorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader2.ContentPanelBackColor = SystemColors.Window;
            panelWithHeader2.ContentPanelForeColor = SystemColors.ControlText;
            // 
            // 
            // 
            panelWithHeader2.ContentsPanel.BackColor = SystemColors.Window;
            panelWithHeader2.ContentsPanel.Controls.Add(fastTreeSchema2);
            panelWithHeader2.ContentsPanel.Controls.Add(panel2);
            panelWithHeader2.ContentsPanel.Dock = DockStyle.Fill;
            panelWithHeader2.ContentsPanel.ForeColor = SystemColors.ControlText;
            panelWithHeader2.ContentsPanel.Location = new Point(0, 21);
            panelWithHeader2.ContentsPanel.Margin = new Padding(0);
            panelWithHeader2.ContentsPanel.Name = "contentsPanel";
            panelWithHeader2.ContentsPanel.Padding = new Padding(1, 0, 1, 1);
            panelWithHeader2.ContentsPanel.Size = new Size(572, 429);
            panelWithHeader2.ContentsPanel.TabIndex = 0;
            panelWithHeader2.ContentsPanel.Tag = "Content";
            panelWithHeader2.Dock = DockStyle.Fill;
            panelWithHeader2.Location = new Point(0, 0);
            panelWithHeader2.MaximizeBox = false;
            panelWithHeader2.Name = "panelWithHeader2";
            panelWithHeader2.PreferredWindowSize = new Size(500, 500);
            panelWithHeader2.Size = new Size(572, 450);
            panelWithHeader2.TabIndex = 5;
            panelWithHeader2.Title = "Second to compare";
            panelWithHeader2.TitleBackColor = Color.FromArgb(216, 222, 228);
            panelWithHeader2.TitleDetailsColor = Color.FromArgb(36, 41, 47);
            panelWithHeader2.TitleForeColor = Color.FromArgb(36, 41, 47);
            panelWithHeader2.WindowBackColor = SystemColors.Window;
            // 
            // fastTreeSchema2
            // 
            fastTreeSchema2.AllowDrop = true;
            fastTreeSchema2.AutoScroll = true;
            fastTreeSchema2.BackColor = SystemColors.Window;
            fastTreeSchema2.Dock = DockStyle.Fill;
            fastTreeSchema2.Location = new Point(1, 33);
            fastTreeSchema2.Name = "fastTreeSchema2";
            fastTreeSchema2.Padding = new Padding(5, 8, 0, 0);
            fastTreeSchema2.Readonly = true;
            fastTreeSchema2.SelectionColor = SystemColors.Highlight;
            fastTreeSchema2.ShowEmptyExpandBoxes = false;
            fastTreeSchema2.ShowExpandBoxes = true;
            fastTreeSchema2.ShowIcons = true;
            fastTreeSchema2.ShowRootNode = true;
            fastTreeSchema2.Size = new Size(570, 395);
            fastTreeSchema2.TabIndex = 6;
            fastTreeSchema2.NodeTextNeeded += FastTreeSchema_NodeTextNeeded;
            fastTreeSchema2.NodeIconNeeded += FastTreeSchema_NodeIconNeeded;
            fastTreeSchema2.NodeBackColorNeeded += FastTreeSchema_NodeBackColorNeeded;
            fastTreeSchema2.NodeForeColorNeeded += FastTreeSchema_NodeForeColorNeeded;
            fastTreeSchema2.NodeVisibilityNeeded += FastTreeSchema_NodeVisibilityNeeded;
            fastTreeSchema2.NodeSelectedStateChanged += FastTreeSchema_NodeSelectedStateChanged;
            fastTreeSchema2.NodeChildrenNeeded += FastTreeSchema_NodeChildrenNeeded;
            fastTreeSchema2.DragDrop += Schema2_DragDrop;
            fastTreeSchema2.DragEnter += Schema_DragEnter;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "element-tree-16-odp2.png");
            imageList1.Images.SetKeyName(1, "element-16-odp2.png");
            imageList1.Images.SetKeyName(2, "array-16-odp2.png");
            imageList1.Images.SetKeyName(3, "node-16-odp2.png");
            imageList1.Images.SetKeyName(4, "deleted5.png");
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(21, 730);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(196, 19);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Show only non-matching nodes";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // fastColoredTextBoxLeft
            // 
            fastColoredTextBoxLeft.AutoCompleteBracketsList = new char[]
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
            fastColoredTextBoxLeft.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n";
            fastColoredTextBoxLeft.AutoScrollMinSize = new Size(2, 14);
            fastColoredTextBoxLeft.BackColor = SystemColors.ControlLightLight;
            fastColoredTextBoxLeft.BorderStyle = BorderStyle.Fixed3D;
            fastColoredTextBoxLeft.BracketsHighlightStrategy = SparkSchemaCreator.Controls.FastColoredTextBox.BracketsHighlightStrategy.Strategy2;
            fastColoredTextBoxLeft.DefaultMarkerSize = 8;
            fastColoredTextBoxLeft.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fastColoredTextBoxLeft.Dock = DockStyle.Fill;
            fastColoredTextBoxLeft.FoldingIndicatorColor = Color.LightSkyBlue;
            fastColoredTextBoxLeft.Font = new Font("Courier New", 9.75F);
            fastColoredTextBoxLeft.Language = SparkSchemaCreator.Controls.FastColoredTextBox.Language.JSON;
            fastColoredTextBoxLeft.LeftBracket = '[';
            fastColoredTextBoxLeft.LeftBracket2 = '{';
            fastColoredTextBoxLeft.Location = new Point(1, 0);
            fastColoredTextBoxLeft.Name = "fastColoredTextBoxLeft";
            fastColoredTextBoxLeft.ReadOnly = true;
            fastColoredTextBoxLeft.RightBracket = ']';
            fastColoredTextBoxLeft.RightBracket2 = '}';
            fastColoredTextBoxLeft.SelectionColor = Color.FromArgb(60, 30, 144, 255);
            fastColoredTextBoxLeft.ServiceColors = (Controls.FastColoredTextBox.ServiceColors)resources.GetObject("fastColoredTextBoxLeft.ServiceColors");
            fastColoredTextBoxLeft.ShowLineNumbers = false;
            fastColoredTextBoxLeft.Size = new Size(298, 184);
            fastColoredTextBoxLeft.TabIndex = 0;
            // 
            // fastColoredTextBoxRight
            // 
            fastColoredTextBoxRight.AutoCompleteBracketsList = new char[]
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
            fastColoredTextBoxRight.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n";
            fastColoredTextBoxRight.AutoScrollMinSize = new Size(2, 14);
            fastColoredTextBoxRight.BackColor = SystemColors.ControlLightLight;
            fastColoredTextBoxRight.BorderStyle = BorderStyle.Fixed3D;
            fastColoredTextBoxRight.BracketsHighlightStrategy = SparkSchemaCreator.Controls.FastColoredTextBox.BracketsHighlightStrategy.Strategy2;
            fastColoredTextBoxRight.DefaultMarkerSize = 8;
            fastColoredTextBoxRight.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fastColoredTextBoxRight.Dock = DockStyle.Fill;
            fastColoredTextBoxRight.FoldingIndicatorColor = Color.LightSkyBlue;
            fastColoredTextBoxRight.Language = SparkSchemaCreator.Controls.FastColoredTextBox.Language.JSON;
            fastColoredTextBoxRight.LeftBracket = '[';
            fastColoredTextBoxRight.LeftBracket2 = '{';
            fastColoredTextBoxRight.Location = new Point(1, 0);
            fastColoredTextBoxRight.Name = "fastColoredTextBoxRight";
            fastColoredTextBoxRight.ReadOnly = true;
            fastColoredTextBoxRight.RightBracket = ']';
            fastColoredTextBoxRight.RightBracket2 = '}';
            fastColoredTextBoxRight.SelectionColor = Color.FromArgb(60, 30, 144, 255);
            fastColoredTextBoxRight.ServiceColors = (Controls.FastColoredTextBox.ServiceColors)resources.GetObject("fastColoredTextBoxRight.ServiceColors");
            fastColoredTextBoxRight.ShowLineNumbers = false;
            fastColoredTextBoxRight.Size = new Size(298, 183);
            fastColoredTextBoxRight.TabIndex = 0;
            // 
            // checkBox2
            // 
            checkBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(223, 730);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(233, 19);
            checkBox2.TabIndex = 11;
            checkBox2.Text = "Hide added/missing field(s) differences";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Location = new Point(9, 30);
            listView1.Name = "listView1";
            listView1.OwnerDraw = true;
            listView1.Size = new Size(524, 206);
            listView1.TabIndex = 12;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.VirtualMode = true;
            listView1.DrawColumnHeader += ListView1_DrawColumnHeader;
            listView1.DrawSubItem += ListView1_DrawSubItem;
            listView1.RetrieveVirtualItem += ListView1_RetrieveVirtualItem;
            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Differences";
            columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Node";
            columnHeader2.Width = 120;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 12);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(linkLabel1);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(listView1);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(panelWithHeader4);
            splitContainer1.Panel2.Controls.Add(panelWithHeader3);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Size = new Size(1148, 712);
            splitContainer1.SplitterDistance = 450;
            splitContainer1.TabIndex = 14;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(panelWithHeader1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(panelWithHeader2);
            splitContainer2.Size = new Size(1148, 450);
            splitContainer2.SplitterDistance = 572;
            splitContainer2.TabIndex = 0;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(394, 239);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(139, 15);
            linkLabel1.TabIndex = 16;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Copy results to clipboard";
            linkLabel1.LinkClicked += CopyToClipboard_LinkClicked;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.ForeColor = Color.Navy;
            label5.Location = new Point(178, 239);
            label5.Name = "label5";
            label5.Size = new Size(114, 15);
            label5.TabIndex = 15;
            label5.Text = "Metadata Difference";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(246, 248, 250);
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(1124, 4);
            button2.Name = "button2";
            button2.Size = new Size(20, 20);
            button2.TabIndex = 13;
            button2.UseVisualStyleBackColor = false;
            button2.Click += Button2_Click;
            button2.Paint += Button2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 10);
            label1.Name = "label1";
            label1.Size = new Size(122, 17);
            label1.TabIndex = 1;
            label1.Text = "Comparison Result";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(255, 247, 200);
            label4.Location = new Point(111, 239);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 15;
            label4.Text = "Difference";
            // 
            // panelWithHeader4
            // 
            panelWithHeader4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelWithHeader4.BorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader4.ContentBorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader4.ContentPanelBackColor = SystemColors.Window;
            panelWithHeader4.ContentPanelForeColor = SystemColors.ControlText;
            // 
            // 
            // 
            panelWithHeader4.ContentsPanel.BackColor = SystemColors.Window;
            panelWithHeader4.ContentsPanel.Controls.Add(fastColoredTextBoxRight);
            panelWithHeader4.ContentsPanel.Dock = DockStyle.Fill;
            panelWithHeader4.ContentsPanel.ForeColor = SystemColors.ControlText;
            panelWithHeader4.ContentsPanel.Location = new Point(0, 21);
            panelWithHeader4.ContentsPanel.Margin = new Padding(0);
            panelWithHeader4.ContentsPanel.Name = "contentsPanel";
            panelWithHeader4.ContentsPanel.Padding = new Padding(1, 0, 1, 1);
            panelWithHeader4.ContentsPanel.Size = new Size(300, 184);
            panelWithHeader4.ContentsPanel.TabIndex = 0;
            panelWithHeader4.ContentsPanel.Tag = "Content";
            panelWithHeader4.Location = new Point(845, 30);
            panelWithHeader4.MaximizeBox = false;
            panelWithHeader4.Name = "panelWithHeader4";
            panelWithHeader4.PreferredWindowSize = new Size(500, 500);
            panelWithHeader4.Size = new Size(300, 205);
            panelWithHeader4.TabIndex = 0;
            panelWithHeader4.Title = "Right Field";
            panelWithHeader4.TitleBackColor = Color.FromArgb(216, 222, 228);
            panelWithHeader4.TitleDetailsColor = Color.FromArgb(36, 41, 47);
            panelWithHeader4.TitleForeColor = Color.FromArgb(36, 41, 47);
            panelWithHeader4.WindowBackColor = SystemColors.Window;
            // 
            // panelWithHeader3
            // 
            panelWithHeader3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelWithHeader3.BorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader3.ContentBorderColor = Color.FromArgb(216, 222, 228);
            panelWithHeader3.ContentPanelBackColor = SystemColors.Window;
            panelWithHeader3.ContentPanelForeColor = SystemColors.ControlText;
            // 
            // 
            // 
            panelWithHeader3.ContentsPanel.BackColor = SystemColors.Window;
            panelWithHeader3.ContentsPanel.Controls.Add(fastColoredTextBoxLeft);
            panelWithHeader3.ContentsPanel.Dock = DockStyle.Fill;
            panelWithHeader3.ContentsPanel.ForeColor = SystemColors.ControlText;
            panelWithHeader3.ContentsPanel.Location = new Point(0, 21);
            panelWithHeader3.ContentsPanel.Margin = new Padding(0);
            panelWithHeader3.ContentsPanel.Name = "contentsPanel";
            panelWithHeader3.ContentsPanel.Padding = new Padding(1, 0, 1, 1);
            panelWithHeader3.ContentsPanel.Size = new Size(300, 185);
            panelWithHeader3.ContentsPanel.TabIndex = 0;
            panelWithHeader3.ContentsPanel.Tag = "Content";
            panelWithHeader3.Location = new Point(540, 30);
            panelWithHeader3.MaximizeBox = false;
            panelWithHeader3.Name = "panelWithHeader3";
            panelWithHeader3.PreferredWindowSize = new Size(500, 500);
            panelWithHeader3.Size = new Size(300, 206);
            panelWithHeader3.TabIndex = 0;
            panelWithHeader3.Title = "Left Field";
            panelWithHeader3.TitleBackColor = Color.FromArgb(216, 222, 228);
            panelWithHeader3.TitleDetailsColor = Color.FromArgb(36, 41, 47);
            panelWithHeader3.TitleForeColor = Color.FromArgb(36, 41, 47);
            panelWithHeader3.WindowBackColor = SystemColors.Window;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(255, 182, 185);
            label3.ForeColor = Color.Firebrick;
            label3.Location = new Point(57, 239);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 15;
            label3.Text = "Missing";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.PaleTurquoise;
            label2.ForeColor = Color.DarkGreen;
            label2.Location = new Point(9, 239);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 15;
            label2.Text = "Added";
            // 
            // SchemaComparer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 250);
            ClientSize = new Size(1172, 795);
            Controls.Add(splitContainer1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SchemaComparer";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Schema Diff Tool";
            panelWithHeader1.ContentsPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panelWithHeader2.ContentsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBoxLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBoxRight).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panelWithHeader4.ContentsPanel.ResumeLayout(false);
            panelWithHeader3.ContentsPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Controls.PanelWithHeader panelWithHeader1;
        private Panel panel2;
        private Controls.ButtonWithNoCue buttonClear2;
        private Controls.ButtonWithNoCue buttonEdit2;
        private Controls.ButtonWithNoCue buttonOpen2;
        private Controls.PanelWithHeader panelWithHeader2;
        private Panel panel1;
        private Controls.ButtonWithNoCue buttonWithNoCue4;
        private Controls.ButtonWithNoCue buttonEdit1;
        private Controls.ButtonWithNoCue buttonOpen1;
        private Controls.ButtonWithNoCue buttonClear1;
        private FastTree fastTreeSchema1;
        private FastTree fastTreeSchema2;
        private ImageList imageList1;
        private CheckBox checkBox1;
        private Controls.FastColoredTextBox.FastColoredTextBox fastColoredTextBoxLeft;
        private Controls.FastColoredTextBox.FastColoredTextBox fastColoredTextBoxRight;
        private CheckBox checkBox2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Controls.PanelWithHeader panelWithHeader4;
        private Controls.PanelWithHeader panelWithHeader3;
        private Label label1;
        private Button button2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private LinkLabel linkLabel1;
    }
}