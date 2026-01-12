namespace SparkSchemaCreator.Controls
{
    partial class CustomTabControl
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
            buttonsPanel = new FlowLayoutPanel();
            contentPanel = new Panel();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonsPanel
            // 
            buttonsPanel.BackColor = Color.Transparent;
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.Location = new Point(0, 0);
            buttonsPanel.Margin = new Padding(0);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(514, 23);
            buttonsPanel.TabIndex = 0;
            // 
            // contentPanel
            // 
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 23);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(514, 378);
            contentPanel.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonsPanel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(514, 23);
            panel1.TabIndex = 0;
            // 
            // CustomTabControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(contentPanel);
            Controls.Add(panel1);
            Name = "CustomTabControl";
            Size = new Size(514, 401);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel buttonsPanel;
        private Panel contentPanel;
        private Panel panel1;
    }
}
