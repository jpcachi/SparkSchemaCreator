namespace SparkSchemaCreator.Controls
{
    partial class StructFieldInfo
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            containsNullLabel = new Label();
            elementTypeLabel = new Label();
            label7 = new Label();
            label6 = new Label();
            valueTypeLabel = new Label();
            label8 = new Label();
            nameLabel = new Label();
            pathLabel = new Label();
            dataTypeLabel = new Label();
            nullableLabel = new Label();
            editButton = new Button();
            groupBox2 = new GroupBox();
            valueContainsNullLabel = new Label();
            label10 = new Label();
            keyTypeLabel = new Label();
            label9 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 17);
            label1.Name = "label1";
            label1.Size = new Size(143, 21);
            label1.TabIndex = 0;
            label1.Text = "Field Information";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 61);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 91);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 1;
            label3.Text = "Path:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 121);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 1;
            label4.Text = "DataType:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 151);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 1;
            label5.Text = "Nullable:";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(containsNullLabel);
            groupBox1.Controls.Add(elementTypeLabel);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(30, 191);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(645, 109);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "ArrayType";
            // 
            // containsNullLabel
            // 
            containsNullLabel.AutoSize = true;
            containsNullLabel.Location = new Point(134, 65);
            containsNullLabel.Name = "containsNullLabel";
            containsNullLabel.Size = new Size(57, 15);
            containsNullLabel.TabIndex = 3;
            containsNullLabel.Text = "<empty>";
            // 
            // elementTypeLabel
            // 
            elementTypeLabel.AutoSize = true;
            elementTypeLabel.Location = new Point(134, 35);
            elementTypeLabel.Name = "elementTypeLabel";
            elementTypeLabel.Size = new Size(57, 15);
            elementTypeLabel.TabIndex = 3;
            elementTypeLabel.Text = "<empty>";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 65);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 0;
            label7.Text = "ContainsNull:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 35);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 0;
            label6.Text = "ElementType:";
            // 
            // valueTypeLabel
            // 
            valueTypeLabel.AutoSize = true;
            valueTypeLabel.Location = new Point(139, 65);
            valueTypeLabel.Name = "valueTypeLabel";
            valueTypeLabel.Size = new Size(57, 15);
            valueTypeLabel.TabIndex = 3;
            valueTypeLabel.Text = "<empty>";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(47, 65);
            label8.Name = "label8";
            label8.Size = new Size(63, 15);
            label8.TabIndex = 0;
            label8.Text = "ValueType:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(143, 61);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(57, 15);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "<empty>";
            // 
            // pathLabel
            // 
            pathLabel.AutoSize = true;
            pathLabel.Location = new Point(143, 91);
            pathLabel.Name = "pathLabel";
            pathLabel.Size = new Size(57, 15);
            pathLabel.TabIndex = 3;
            pathLabel.Text = "<empty>";
            // 
            // dataTypeLabel
            // 
            dataTypeLabel.AutoSize = true;
            dataTypeLabel.Location = new Point(143, 121);
            dataTypeLabel.Name = "dataTypeLabel";
            dataTypeLabel.Size = new Size(57, 15);
            dataTypeLabel.TabIndex = 3;
            dataTypeLabel.Text = "<empty>";
            // 
            // nullableLabel
            // 
            nullableLabel.AutoSize = true;
            nullableLabel.Location = new Point(143, 151);
            nullableLabel.Name = "nullableLabel";
            nullableLabel.Size = new Size(57, 15);
            nullableLabel.TabIndex = 3;
            nullableLabel.Text = "<empty>";
            // 
            // editButton
            // 
            editButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editButton.Enabled = false;
            editButton.Location = new Point(600, 18);
            editButton.Name = "editButton";
            editButton.Size = new Size(75, 23);
            editButton.TabIndex = 4;
            editButton.Text = "Edit...";
            editButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(valueContainsNullLabel);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(keyTypeLabel);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(valueTypeLabel);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(25, 191);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(650, 109);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "MapType";
            groupBox2.Visible = false;
            // 
            // valueContainsNullLabel
            // 
            valueContainsNullLabel.AutoSize = true;
            valueContainsNullLabel.Location = new Point(449, 35);
            valueContainsNullLabel.Name = "valueContainsNullLabel";
            valueContainsNullLabel.Size = new Size(57, 15);
            valueContainsNullLabel.TabIndex = 3;
            valueContainsNullLabel.Text = "<empty>";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(323, 35);
            label10.Name = "label10";
            label10.Size = new Size(107, 15);
            label10.TabIndex = 0;
            label10.Text = "ValueContainsNull:";
            // 
            // keyTypeLabel
            // 
            keyTypeLabel.AutoSize = true;
            keyTypeLabel.Location = new Point(139, 35);
            keyTypeLabel.Name = "keyTypeLabel";
            keyTypeLabel.Size = new Size(57, 15);
            keyTypeLabel.TabIndex = 3;
            keyTypeLabel.Text = "<empty>";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(47, 35);
            label9.Name = "label9";
            label9.Size = new Size(54, 15);
            label9.TabIndex = 0;
            label9.Text = "KeyType:";
            // 
            // StructFieldInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(editButton);
            Controls.Add(nullableLabel);
            Controls.Add(dataTypeLabel);
            Controls.Add(pathLabel);
            Controls.Add(nameLabel);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "StructFieldInfo";
            Size = new Size(704, 324);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private GroupBox groupBox1;
        private Label label7;
        private Label label6;
        private Label containsNullLabel;
        private Label elementTypeLabel;
        private Label nameLabel;
        private Label pathLabel;
        private Label dataTypeLabel;
        private Label nullableLabel;
        private Button editButton;
        private Label valueTypeLabel;
        private Label label8;
        private GroupBox groupBox2;
        private Label valueContainsNullLabel;
        private Label label10;
        private Label keyTypeLabel;
        private Label label9;
    }
}
