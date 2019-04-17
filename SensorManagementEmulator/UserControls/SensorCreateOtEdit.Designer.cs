namespace SensorManagementEmulator.UserControls
{
    partial class SensorCreateOtEdit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.TypeTextBox = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.ValuesBox = new System.Windows.Forms.ComboBox();
            this.GenIntLabel = new System.Windows.Forms.Label();
            this.GenerInterBox = new System.Windows.Forms.ComboBox();
            this.MinMaxComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(151, 23);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.ReadOnly = true;
            this.IdTextBox.Size = new System.Drawing.Size(173, 20);
            this.IdTextBox.TabIndex = 0;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(151, 49);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(173, 20);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // TypeTextBox
            // 
            this.TypeTextBox.Location = new System.Drawing.Point(151, 75);
            this.TypeTextBox.Name = "TypeTextBox";
            this.TypeTextBox.Size = new System.Drawing.Size(173, 20);
            this.TypeTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(19, 30);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(16, 13);
            this.IdLabel.TabIndex = 5;
            this.IdLabel.Text = "Id";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(19, 56);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Name";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(19, 82);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(31, 13);
            this.TypeLabel.TabIndex = 7;
            this.TypeLabel.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "MinMaxValues";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(3, 320);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Visible = false;
            this.SaveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(279, 320);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Visible = false;
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(19, 134);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(39, 13);
            this.ValueLabel.TabIndex = 16;
            this.ValueLabel.Text = "Values";
            // 
            // ValuesBox
            // 
            this.ValuesBox.FormattingEnabled = true;
            this.ValuesBox.Location = new System.Drawing.Point(151, 134);
            this.ValuesBox.Name = "ValuesBox";
            this.ValuesBox.Size = new System.Drawing.Size(173, 21);
            this.ValuesBox.TabIndex = 17;
            // 
            // GenIntLabel
            // 
            this.GenIntLabel.AutoSize = true;
            this.GenIntLabel.Location = new System.Drawing.Point(22, 162);
            this.GenIntLabel.Name = "GenIntLabel";
            this.GenIntLabel.Size = new System.Drawing.Size(96, 13);
            this.GenIntLabel.TabIndex = 18;
            this.GenIntLabel.Text = "Generation interval";
            // 
            // GenerInterBox
            // 
            this.GenerInterBox.FormattingEnabled = true;
            this.GenerInterBox.Location = new System.Drawing.Point(151, 162);
            this.GenerInterBox.Name = "GenerInterBox";
            this.GenerInterBox.Size = new System.Drawing.Size(173, 21);
            this.GenerInterBox.TabIndex = 19;
            // 
            // MinMaxComboBox
            // 
            this.MinMaxComboBox.FormattingEnabled = true;
            this.MinMaxComboBox.Location = new System.Drawing.Point(151, 108);
            this.MinMaxComboBox.Name = "MinMaxComboBox";
            this.MinMaxComboBox.Size = new System.Drawing.Size(173, 21);
            this.MinMaxComboBox.TabIndex = 20;
            // 
            // SensorCreateOtEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MinMaxComboBox);
            this.Controls.Add(this.GenerInterBox);
            this.Controls.Add(this.GenIntLabel);
            this.Controls.Add(this.ValuesBox);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.TypeTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.IdTextBox);
            this.Name = "SensorCreateOtEdit";
            this.Size = new System.Drawing.Size(438, 346);
            this.Load += new System.EventHandler(this.SensorCreateOtEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        public System.Windows.Forms.TextBox IdTextBox;
        public System.Windows.Forms.TextBox NameTextBox;
        public System.Windows.Forms.TextBox TypeTextBox;
        private System.Windows.Forms.Label ValueLabel;
        public System.Windows.Forms.ComboBox ValuesBox;
        private System.Windows.Forms.Label GenIntLabel;
        public System.Windows.Forms.ComboBox GenerInterBox;
        public System.Windows.Forms.ComboBox MinMaxComboBox;
    }
}
