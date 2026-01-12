namespace SparkSchemaCreator.Controls
{
    partial class TabTextControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabTextControl));
            panel1 = new Panel();
            buttonsPanel = new FlowLayoutPanel();
            panel2 = new Panel();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            contentsPanel = new DrawablePanel();
            copiedToClipboardLabel = new Label();
            copyToClipboardButton = new Button();
            fastColoredTextBox1 = new Controls.FastColoredTextBox.FastColoredTextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            contentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonsPanel);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(787, 23);
            panel1.TabIndex = 1;
            // 
            // buttonsPanel
            // 
            buttonsPanel.BackColor = Color.Transparent;
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.Location = new Point(0, 0);
            buttonsPanel.Margin = new Padding(0);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(493, 23);
            buttonsPanel.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(checkBox2);
            panel2.Controls.Add(checkBox1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(493, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(294, 23);
            panel2.TabIndex = 1;
            panel2.Visible = false;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(134, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.Padding = new Padding(0, 0, 4, 0);
            checkBox2.Size = new Size(157, 19);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Escape quote characters";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(7, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(121, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Pretty json format";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // contentsPanel
            // 
            contentsPanel.BackColor = Color.White;
            contentsPanel.Controls.Add(copiedToClipboardLabel);
            contentsPanel.Controls.Add(copyToClipboardButton);
            contentsPanel.Controls.Add(fastColoredTextBox1);
            contentsPanel.Dock = DockStyle.Fill;
            contentsPanel.Location = new Point(0, 23);
            contentsPanel.Name = "contentsPanel";
            contentsPanel.Size = new Size(787, 365);
            contentsPanel.TabIndex = 2;
            contentsPanel.Paint += ContentsPanel_Paint;
            // 
            // copiedToClipboardLabel
            // 
            copiedToClipboardLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            copiedToClipboardLabel.AutoSize = true;
            copiedToClipboardLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            copiedToClipboardLabel.ForeColor = Color.DarkSalmon;
            copiedToClipboardLabel.Location = new Point(596, 333);
            copiedToClipboardLabel.Name = "copiedToClipboardLabel";
            copiedToClipboardLabel.Size = new Size(182, 17);
            copiedToClipboardLabel.TabIndex = 2;
            copiedToClipboardLabel.Text = "Text copied to the clipboard";
            copiedToClipboardLabel.Visible = false;
            // 
            // copyToClipboardButton
            // 
            copyToClipboardButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            copyToClipboardButton.Location = new Point(8, 331);
            copyToClipboardButton.Name = "copyToClipboardButton";
            copyToClipboardButton.Size = new Size(112, 23);
            copyToClipboardButton.TabIndex = 1;
            copyToClipboardButton.Text = "Copy to clipboard";
            copyToClipboardButton.UseVisualStyleBackColor = true;
            copyToClipboardButton.Click += CopyToClipboardButton_Click;
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
            fastColoredTextBox1.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
            fastColoredTextBox1.AutoScrollMinSize = new Size(25, 15);
            fastColoredTextBox1.DefaultMarkerSize = 8;
            fastColoredTextBox1.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fastColoredTextBox1.FoldingIndicatorColor = Color.SkyBlue;
            fastColoredTextBox1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fastColoredTextBox1.Location = new Point(9, 9);
            fastColoredTextBox1.Name = "fastColoredTextBox1";
            fastColoredTextBox1.SelectionColor = Color.FromArgb(60, 30, 144, 255);
            //fastColoredTextBox1.ServiceColors = (Controls.FastColoredTextBox.ServiceColors)resources.GetObject("fastColoredTextBox1.ServiceColors");
            fastColoredTextBox1.Size = new Size(769, 316);
            fastColoredTextBox1.TabIndex = 0;
            fastColoredTextBox1.TextChanged += fastColoredTextBox1_TextChanged;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            // 
            // TabTextControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(contentsPanel);
            Controls.Add(panel1);
            Name = "TabTextControl";
            Size = new Size(787, 388);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            contentsPanel.ResumeLayout(false);
            contentsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel buttonsPanel;
        private Panel panel2;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private DrawablePanel contentsPanel;
        private Controls.FastColoredTextBox.FastColoredTextBox fastColoredTextBox1;
        private Button copyToClipboardButton;
        private Label copiedToClipboardLabel;
        private System.Windows.Forms.Timer timer1;
    }
}
