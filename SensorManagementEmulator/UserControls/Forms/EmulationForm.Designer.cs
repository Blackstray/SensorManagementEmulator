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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.EmulationDataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.EmulateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EmulationDataChart)).BeginInit();
            this.SuspendLayout();
            // 
            // EmulationDataChart
            // 
            chartArea3.Name = "ChartArea1";
            this.EmulationDataChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.EmulationDataChart.Legends.Add(legend3);
            this.EmulationDataChart.Location = new System.Drawing.Point(818, 12);
            this.EmulationDataChart.Name = "EmulationDataChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.EmulationDataChart.Series.Add(series3);
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
            // EmulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 497);
            this.Controls.Add(this.EmulateButton);
            this.Controls.Add(this.EmulationDataChart);
            this.Name = "EmulationForm";
            this.Text = "EmulationForm";
            this.Load += new System.EventHandler(this.EmulationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmulationDataChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart EmulationDataChart;
        public System.Windows.Forms.Button EmulateButton;
    }
}