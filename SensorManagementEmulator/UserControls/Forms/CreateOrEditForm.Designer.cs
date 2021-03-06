﻿namespace SensorManagementEmulator.UserControls
{
    partial class CreateOrEditForm
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
            this.CreateButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SensorCreate = new SensorManagementEmulator.UserControls.SensorCreateOtEdit();
            this.GenInterTextbox = new System.Windows.Forms.TextBox();
            this.ValueTextbox = new System.Windows.Forms.TextBox();
            this.MinMaxTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.Location = new System.Drawing.Point(429, 383);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(94, 38);
            this.CreateButton.TabIndex = 1;
            this.CreateButton.Text = "Create!";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(12, 383);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(98, 38);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save changes";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(336, 383);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(87, 38);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SensorCreate
            // 
            this.SensorCreate.Location = new System.Drawing.Point(12, 3);
            this.SensorCreate.Name = "SensorCreate";
            this.SensorCreate.Size = new System.Drawing.Size(349, 268);
            this.SensorCreate.TabIndex = 0;
            this.SensorCreate.Load += new System.EventHandler(this.SensorCreate_Load);
            // 
            // GenInterTextbox
            // 
            this.GenInterTextbox.Location = new System.Drawing.Point(368, 168);
            this.GenInterTextbox.Name = "GenInterTextbox";
            this.GenInterTextbox.Size = new System.Drawing.Size(163, 20);
            this.GenInterTextbox.TabIndex = 7;
            // 
            // ValueTextbox
            // 
            this.ValueTextbox.Location = new System.Drawing.Point(368, 141);
            this.ValueTextbox.Name = "ValueTextbox";
            this.ValueTextbox.Size = new System.Drawing.Size(163, 20);
            this.ValueTextbox.TabIndex = 6;
            // 
            // MinMaxTextbox
            // 
            this.MinMaxTextbox.Location = new System.Drawing.Point(368, 114);
            this.MinMaxTextbox.Name = "MinMaxTextbox";
            this.MinMaxTextbox.Size = new System.Drawing.Size(163, 20);
            this.MinMaxTextbox.TabIndex = 5;
            // 
            // CreateOrEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 433);
            this.Controls.Add(this.GenInterTextbox);
            this.Controls.Add(this.ValueTextbox);
            this.Controls.Add(this.MinMaxTextbox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.SensorCreate);
            this.Name = "CreateOrEditForm";
            this.Text = "CreateForm";
            this.Load += new System.EventHandler(this.CreateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public SensorCreateOtEdit SensorCreate;
        public System.Windows.Forms.Button SaveButton;
        public System.Windows.Forms.Button CancelButton;
        public System.Windows.Forms.Button CreateButton;
        public System.Windows.Forms.TextBox GenInterTextbox;
        public System.Windows.Forms.TextBox ValueTextbox;
        public System.Windows.Forms.TextBox MinMaxTextbox;
    }
}