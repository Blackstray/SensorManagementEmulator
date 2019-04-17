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
            this.EditSensor = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Emulate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EmulateSensor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.EditSensor,
            this.DeleteColumn,
            this.Emulate,
            this.EmulateSensor});
            this.sensorDGV.Location = new System.Drawing.Point(0, 0);
            this.sensorDGV.Name = "sensorDGV";
            this.sensorDGV.Size = new System.Drawing.Size(805, 358);
            this.sensorDGV.TabIndex = 0;
            this.sensorDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sensorDGV_CellContentClick);
            // 
            // SensorIdColumn
            // 
            this.SensorIdColumn.HeaderText = "Id";
            this.SensorIdColumn.Name = "SensorIdColumn";
            this.SensorIdColumn.ReadOnly = true;
            this.SensorIdColumn.Width = 150;
            // 
            // SensorName
            // 
            this.SensorName.HeaderText = "Name";
            this.SensorName.Name = "SensorName";
            this.SensorName.ReadOnly = true;
            // 
            // SensorValueType
            // 
            this.SensorValueType.HeaderText = "Type";
            this.SensorValueType.Name = "SensorValueType";
            this.SensorValueType.ReadOnly = true;
            // 
            // EditSensor
            // 
            this.EditSensor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditSensor.HeaderText = "More";
            this.EditSensor.Name = "EditSensor";
            this.EditSensor.ReadOnly = true;
            this.EditSensor.Text = "More";
            this.EditSensor.ToolTipText = "More about sensor";
            this.EditSensor.UseColumnTextForButtonValue = true;
            this.EditSensor.Width = 50;
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
            this.DeleteColumn.Width = 50;
            // 
            // Emulate
            // 
            this.Emulate.HeaderText = "Emulate";
            this.Emulate.Name = "Emulate";
            this.Emulate.ReadOnly = true;
            this.Emulate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Emulate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Emulate.Text = "Emulate";
            this.Emulate.ToolTipText = "Emulate sensor";
            this.Emulate.UseColumnTextForButtonValue = true;
            this.Emulate.Width = 50;
            // 
            // EmulateSensor
            // 
            this.EmulateSensor.FalseValue = "false";
            this.EmulateSensor.HeaderText = "Emulate selected";
            this.EmulateSensor.IndeterminateValue = "false";
            this.EmulateSensor.Name = "EmulateSensor";
            this.EmulateSensor.TrueValue = "true";
            // 
            // SensorDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sensorDGV);
            this.Name = "SensorDataGridView";
            this.Size = new System.Drawing.Size(806, 358);
            this.Load += new System.EventHandler(this.SensorDataGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sensorDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView sensorDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorValueType;
        private System.Windows.Forms.DataGridViewButtonColumn EditSensor;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Emulate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EmulateSensor;
    }
}
