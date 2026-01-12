namespace SparkSchemaCreator.Controls
{
    partial class PanelWithHeader
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
            contentsPanel = new Panel();
            titlePanel = new Panel();
            titlePanelDraw = new Panel();
            button1 = new Button();
            titleLabel = new Label();
            titlePanel.SuspendLayout();
            titlePanelDraw.SuspendLayout();
            SuspendLayout();
            // 
            // contentsPanel
            // 
            contentsPanel.BackColor = SystemColors.Window;
            contentsPanel.Dock = DockStyle.Fill;
            contentsPanel.Location = new Point(0, 22);
            contentsPanel.Margin = new Padding(0);
            contentsPanel.Name = "contentsPanel";
            contentsPanel.Padding = new Padding(1, 0, 1, 1);
            contentsPanel.Size = new Size(118, 91);
            contentsPanel.TabIndex = 0;
            contentsPanel.Tag = "Content";
            contentsPanel.Paint += ContentsPanel_Paint;
            // 
            // titlePanel
            // 
            titlePanel.AutoSize = true;
            titlePanel.BackColor = Color.LightGray;
            titlePanel.Controls.Add(titlePanelDraw);
            titlePanel.Dock = DockStyle.Top;
            titlePanel.Location = new Point(0, 0);
            titlePanel.Margin = new Padding(4, 3, 4, 3);
            titlePanel.Name = "titlePanel";
            titlePanel.Size = new Size(118, 22);
            titlePanel.TabIndex = 1;
            titlePanel.Tag = "Title";
            // 
            // titlePanelDraw
            // 
            titlePanelDraw.AutoSize = true;
            titlePanelDraw.BackColor = Color.Transparent;
            titlePanelDraw.Controls.Add(button1);
            titlePanelDraw.Controls.Add(titleLabel);
            titlePanelDraw.Dock = DockStyle.Top;
            titlePanelDraw.Location = new Point(0, 0);
            titlePanelDraw.Margin = new Padding(4, 3, 4, 3);
            titlePanelDraw.Name = "titlePanelDraw";
            titlePanelDraw.Size = new Size(118, 22);
            titlePanelDraw.TabIndex = 1;
            titlePanelDraw.Paint += TitlePanel_Paint;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(96, 1);
            button1.Margin = new Padding(1);
            button1.Name = "button1";
            button1.Size = new Size(19, 20);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            button1.Paint += Button1_Paint;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Margin = new Padding(2, 0, 2, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Padding = new Padding(4, 3, 4, 3);
            titleLabel.Size = new Size(38, 21);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Title";
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PanelWithHeader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(contentsPanel);
            Controls.Add(titlePanel);
            Name = "PanelWithHeader";
            Size = new Size(118, 113);
            Paint += MyUserControl_Paint;
            Resize += PanelWithHeader_Resize;
            titlePanel.ResumeLayout(false);
            titlePanel.PerformLayout();
            titlePanelDraw.ResumeLayout(false);
            titlePanelDraw.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel contentsPanel;
        private System.Windows.Forms.Panel titlePanelDraw;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button button1;
    }
}
