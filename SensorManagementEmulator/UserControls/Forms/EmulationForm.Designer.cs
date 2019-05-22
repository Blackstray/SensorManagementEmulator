namespace SensorManagementEmulator.UserControls.Forms
{
    partial class EmulationForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.EmulationDataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.EmulateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.e = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.StopEmulationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EmulationDataChart)).BeginInit();
            this.SuspendLayout();
            // 
            // EmulationDataChart
            // 
            chartArea2.Name = "ChartArea1";
            this.EmulationDataChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.EmulationDataChart.Legends.Add(legend2);
            this.EmulationDataChart.Location = new System.Drawing.Point(216, 176);
            this.EmulationDataChart.Name = "EmulationDataChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.EmulationDataChart.Series.Add(series2);
            this.EmulationDataChart.Size = new System.Drawing.Size(300, 300);
            this.EmulationDataChart.TabIndex = 0;
            this.EmulationDataChart.Text = "Emulation chart";
            // 
            // EmulateButton
            // 
            this.EmulateButton.Location = new System.Drawing.Point(12, 12);
            this.EmulateButton.Name = "EmulateButton";
            this.EmulateButton.Size = new System.Drawing.Size(75, 23);
            this.EmulateButton.TabIndex = 1;
            this.EmulateButton.Text = "Emulate";
            this.EmulateButton.UseVisualStyleBackColor = true;
            this.EmulateButton.Click += new System.EventHandler(this.EmulateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sensor id:";
            // 
            // e
            // 
            this.e.AutoSize = true;
            this.e.Location = new System.Drawing.Point(12, 64);
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(72, 13);
            this.e.TabIndex = 3;
            this.e.Text = "Sensor name:";
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(86, 42);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(35, 13);
            this.IdLabel.TabIndex = 4;
            this.IdLabel.Text = "label2";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(86, 64);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "label3";
            // 
            // StopEmulationButton
            // 
            this.StopEmulationButton.Location = new System.Drawing.Point(12, 95);
            this.StopEmulationButton.Name = "StopEmulationButton";
            this.StopEmulationButton.Size = new System.Drawing.Size(100, 23);
            this.StopEmulationButton.TabIndex = 6;
            this.StopEmulationButton.Text = "Stop Emulation";
            this.StopEmulationButton.UseVisualStyleBackColor = true;
            // 
            // EmulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 198);
            this.Controls.Add(this.StopEmulationButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.e);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmulateButton);
            this.Controls.Add(this.EmulationDataChart);
            this.Name = "EmulationForm";
            this.Text = "EmulationForm";
            this.Load += new System.EventHandler(this.EmulationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmulationDataChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart EmulationDataChart;
        public System.Windows.Forms.Button EmulateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label e;
        public System.Windows.Forms.Label IdLabel;
        public System.Windows.Forms.Label NameLabel;
        public System.Windows.Forms.Button StopEmulationButton;
    }
}