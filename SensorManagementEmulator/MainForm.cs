using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SensorManagementEmulator.Firebase;
using SensorManagementEmulator.Models;
using SensorManagementEmulator.services;
using SensorManagementEmulator.UserControls;
using SensorManagementEmulator.UserControls.Forms;
using SensorManagementEmulator.UserControls.PopUps;
using SensorManagementEmulatorDataEmulation;

namespace SensorManagementEmulator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Icon = new Icon("../../favicon.ico");
            this.Text = "Sensor Data Emulator";
            LoadDataGridViewData();
            mainSensorDataGridView.AutoScroll = true;
            mainSensorDataGridView.VerticalScroll.Enabled = true;
            mainSensorDataGridView.sensorDGV.CellContentClick += SensorDGV_CellContentClick;
            mainSensorDataGridView.sensorDGV.AllowUserToAddRows = false;
            SensortCreateButton.Enabled = true;
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.SetToolTip(SensortCreateButton, "temporary disabled");
            SensortCreateButton.DragOver += (sender, args) =>
            {
                buttonToolTip.Show("", SensortCreateButton);
            };

        }

        private void SensorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                if (mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().CompareTo("More") == 0)
                {
                    SensorEditing(e);
                }
                else if (mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().CompareTo("Delete") == 0)
                {
                   // SensorDeletion(e);
                }
                else if (mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().CompareTo("Emulate") == 0)
                {
                    Emulate(e);
                }
            }
        }
        private void Emulate(DataGridViewCellEventArgs e)
        {
            var form = new EmulationForm();
            form.EmulateButton.Click += (sender, args) =>
            {
                EmulateData(e, form);
            };
            form.Show();
        }

        private void EmulateData(DataGridViewCellEventArgs e, EmulationForm form)
        {
            foreach (var value in ((Sensor<double>)mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[2].Value).MinMax)
            {
                Task.Factory.StartNew(async () =>
                {
                    DataEmulationService sensorEmulation = new DataEmulationService();
                    form.Closing += (sender, args) =>
                    {
                        sensorEmulation.StopEmulation.Invoke(true);
                    };
                    await sensorEmulation.EmulateDoubleTemp((Sensor<double>)mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[2].Value, value.Key);
                });
            }

        }
        private void mainSensorDataGridView_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void SensortCreateButton_Click(object sender, EventArgs e)
        {
            return;
            var form = new CreateOrEditForm();
            form.Show();
            form.Closed += (o, args) => { LoadDataGridViewData(); };
        }

        private bool IsDataChanged(int id, Sensor<double> sensorBefore)
        {
            DBSelectionService selectSensor = new DBSelectionService();
            var sensor = selectSensor.GetSensorById(id);


            return !sensor.CompareTo(sensorBefore);
        }

        private void mainSensorDataGridView_Load_1(object sender, EventArgs e)
        {

        }

        private void ListReloadButton_Click(object sender, EventArgs e)
        {
            LoadDataGridViewData();
        }

        private void SensorEditing(DataGridViewCellEventArgs e)
        {
            var form = new CreateOrEditForm();
            form.Init((Sensor<double>)mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[2].Value);

            form.SaveButton.Click += (o, args) =>
            {
                Sensor<double> sensor = new Sensor<double>();
                try
                {
                    sensor = form.SensorCreate.GenerateSensor(true);
                }
                catch (FormatException exception)
                {
                    MessageBox.Show("Invalid values");
                }

                if (IsDataChanged(int.Parse(mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[0].Value.ToString()), sensor))
                {
                    DBUpdateService.UpdateSensorByNewSensor(sensor);
                    LoadDataGridViewData();
                }
                else
                {
                    form.Close();
                }

            };
            form.Show();
        }

        private async Task LoadDataGridViewData()
        {
            mainSensorDataGridView.sensorDGV.Rows.Clear();
            var FBService = new FireBaseDataRetrieve();
            var sensors = await FBService.RetrieveAllDocuments(FBConst.ProjectName);

            int i = 0;
            foreach (var sensor in sensors)
            {
                mainSensorDataGridView.sensorDGV.Rows.Add(sensor.id, sensor.Name, sensor);
                i++;
            }
        }

        private void SensorDeletion(DataGridViewCellEventArgs e)
        {
            var warningForm = new WarningForm();
            warningForm.YesButton.Click += (sender, args) =>
            {
                DBDeleteService.DeleteById(int.Parse(mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[0].Value.ToString()));
                mainSensorDataGridView.sensorDGV.Rows.RemoveAt(e.RowIndex);
                warningForm.Close();
            };
            warningForm.NoButton.Click += (sender, args) => { warningForm.Close(); };

            warningForm.WarningMessageLabel.Text = @"Are you sure, that you want to delete this item? :";
            warningForm.ItemLabel.Text = @"Sensor id: " + mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[0].Value.ToString();

            warningForm.Show();

        }

        private void EmulateSelectedButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < (mainSensorDataGridView.sensorDGV.RowCount); i++)
            {
                if (mainSensorDataGridView.sensorDGV.Rows[i].Cells[mainSensorDataGridView.sensorDGV.ColumnCount - 1].Value is null)
                    continue;
                bool temp = bool.Parse(mainSensorDataGridView.sensorDGV.Rows[i].Cells[mainSensorDataGridView.sensorDGV.ColumnCount - 1].Value.ToString());
                if (temp)
                {
                    var i1 = i;
                    foreach (var value in ((Sensor<double>)mainSensorDataGridView.sensorDGV.Rows[i].Cells[2].Value).MinMax)
                    {            
                        Task.Factory.StartNew(async () =>
                        {
                                await Task.Delay(50);
                                DataEmulationService sensorEmulation = new DataEmulationService();
                                StopEmulationButton.Click += (o, args) =>
                                {
                                    sensorEmulation.StopEmulation.Invoke(true);
                                };
                                await sensorEmulation.EmulateDoubleTemp((Sensor<double>)mainSensorDataGridView.sensorDGV.Rows[i1].Cells[2].Value, value.Key);
                                
                        });
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
