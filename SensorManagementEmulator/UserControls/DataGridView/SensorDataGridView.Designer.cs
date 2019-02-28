namespace SensorManagementEmulator.UserControls.DataGridView
{
    partial class SensorDataGridView
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
            this.sensorDGV = new System.Windows.Forms.DataGridView();
            this.SensorIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SensorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SensorValueType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenerationInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditSensor = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sensorDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // sensorDGV
            // 
            this.sensorDGV.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.sensorDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sensorDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SensorIdColumn,
            this.SensorName,
            this.SensorValueType,
            this.MinValue,
            this.MaxValue,
            this.GenerationInterval,
            this.CurrentValue,
            this.EditSensor,
            this.DeleteColumn});
            this.sensorDGV.Location = new System.Drawing.Point(0, 0);
            this.sensorDGV.Name = "sensorDGV";
            this.sensorDGV.Size = new System.Drawing.Size(1093, 368);
            this.sensorDGV.TabIndex = 0;
            this.sensorDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sensorDGV_CellContentClick);
            // 
            // SensorIdColumn
            // 
            this.SensorIdColumn.HeaderText = "Id";
            this.SensorIdColumn.Name = "SensorIdColumn";
            this.SensorIdColumn.ReadOnly = true;
            this.SensorIdColumn.Width = 45;
            // 
            // SensorName
            // 
            this.SensorName.HeaderText = "Name";
            this.SensorName.Name = "SensorName";
            // 
            // SensorValueType
            // 
            this.SensorValueType.HeaderText = "Type";
            this.SensorValueType.Name = "SensorValueType";
            this.SensorValueType.ReadOnly = true;
            // 
            // MinValue
            // 
            this.MinValue.HeaderText = "Min value";
            this.MinValue.Name = "MinValue";
            // 
            // MaxValue
            // 
            this.MaxValue.HeaderText = "Max value";
            this.MaxValue.Name = "MaxValue";
            // 
            // GenerationInterval
            // 
            this.GenerationInterval.HeaderText = "Generation interval (ms)";
            this.GenerationInterval.Name = "GenerationInterval";
            // 
            // CurrentValue
            // 
            this.CurrentValue.HeaderText = "Current Value";
            this.CurrentValue.Name = "CurrentValue";
            // 
            // EditSensor
            // 
            this.EditSensor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditSensor.HeaderText = "Edit";
            this.EditSensor.Name = "EditSensor";
            this.EditSensor.ReadOnly = true;
            this.EditSensor.Text = "Edit";
            this.EditSensor.ToolTipText = "Edit sensor";
            this.EditSensor.UseColumnTextForButtonValue = true;
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.HeaderText = "Delete";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.ReadOnly = true;
            this.DeleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteColumn.Text = "Delete";
            this.DeleteColumn.ToolTipText = "Delete sensor";
            this.DeleteColumn.UseColumnTextForButtonValue = true;
            // 
            // SensorDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sensorDGV);
            this.Name = "SensorDataGridView";
            this.Size = new System.Drawing.Size(1063, 287);
            this.Load += new System.EventHandler(this.SensorDataGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sensorDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView sensorDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorValueType;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenerationInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentValue;
        private System.Windows.Forms.DataGridViewButtonColumn EditSensor;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteColumn;
    }
}
