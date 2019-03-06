namespace SensorManagementEmulator.UserControls.PopUps
{
    partial class WarningForm
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
            this.NoButton = new System.Windows.Forms.Button();
            this.YesButton = new System.Windows.Forms.Button();
            this.WarningMessageLabel = new System.Windows.Forms.Label();
            this.ItemLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NoButton
            // 
            this.NoButton.Location = new System.Drawing.Point(185, 145);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(135, 34);
            this.NoButton.TabIndex = 0;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            // 
            // YesButton
            // 
            this.YesButton.Location = new System.Drawing.Point(12, 145);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(135, 34);
            this.YesButton.TabIndex = 1;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            // 
            // WarningMessageLabel
            // 
            this.WarningMessageLabel.AutoSize = true;
            this.WarningMessageLabel.Location = new System.Drawing.Point(35, 30);
            this.WarningMessageLabel.Name = "WarningMessageLabel";
            this.WarningMessageLabel.Size = new System.Drawing.Size(47, 13);
            this.WarningMessageLabel.TabIndex = 2;
            this.WarningMessageLabel.Text = "Warning";
            // 
            // ItemLabel
            // 
            this.ItemLabel.AutoSize = true;
            this.ItemLabel.Location = new System.Drawing.Point(38, 58);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(27, 13);
            this.ItemLabel.TabIndex = 3;
            this.ItemLabel.Text = "Item";
            // 
            // WarningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 219);
            this.Controls.Add(this.ItemLabel);
            this.Controls.Add(this.WarningMessageLabel);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.NoButton);
            this.Name = "WarningForm";
            this.Text = "WarningForm";
            this.Load += new System.EventHandler(this.WarningForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button NoButton;
        public System.Windows.Forms.Button YesButton;
        public System.Windows.Forms.Label WarningMessageLabel;
        public System.Windows.Forms.Label ItemLabel;
    }
}