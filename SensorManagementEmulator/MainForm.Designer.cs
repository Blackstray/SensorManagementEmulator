namespace SensorManagementEmulator
{
    partial class MainForm
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
            this.SensortCreateButton = new System.Windows.Forms.Button();
            this.mainSensorDataGridView = new SensorManagementEmulator.UserControls.DataGridView.SensorDataGridView();
            this.ListReloadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SensortCreateButton
            // 
            this.SensortCreateButton.Location = new System.Drawing.Point(0, 12);
            this.SensortCreateButton.Name = "SensortCreateButton";
            this.SensortCreateButton.Size = new System.Drawing.Size(98, 23);
            this.SensortCreateButton.TabIndex = 1;
            this.SensortCreateButton.Text = "Create sensor";
            this.SensortCreateButton.UseVisualStyleBackColor = true;
            this.SensortCreateButton.Click += new System.EventHandler(this.SensortCreateButton_Click);
            // 
            // mainSensorDataGridView
            // 
            this.mainSensorDataGridView.Location = new System.Drawing.Point(0, 41);
            this.mainSensorDataGridView.Name = "mainSensorDataGridView";
            this.mainSensorDataGridView.Size = new System.Drawing.Size(1094, 213);
            this.mainSensorDataGridView.TabIndex = 2;
            this.mainSensorDataGridView.Load += new System.EventHandler(this.mainSensorDataGridView_Load_1);
            // 
            // ListReloadButton
            // 
            this.ListReloadButton.Location = new System.Drawing.Point(104, 12);
            this.ListReloadButton.Name = "ListReloadButton";
            this.ListReloadButton.Size = new System.Drawing.Size(93, 23);
            this.ListReloadButton.TabIndex = 3;
            this.ListReloadButton.Text = "Reload list";
            this.ListReloadButton.UseVisualStyleBackColor = true;
            this.ListReloadButton.Click += new System.EventHandler(this.ListReloadButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1095, 588);
            this.Controls.Add(this.ListReloadButton);
            this.Controls.Add(this.mainSensorDataGridView);
            this.Controls.Add(this.SensortCreateButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SensortCreateButton;
        private UserControls.DataGridView.SensorDataGridView mainSensorDataGridView;
        private System.Windows.Forms.Button ListReloadButton;
    }
}

