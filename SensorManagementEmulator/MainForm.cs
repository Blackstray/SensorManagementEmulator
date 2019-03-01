using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SensorManagementEmulator.Models;
using SensorManagementEmulator.services;
using SensorManagementEmulator.UserControls;
using SensorManagementEmulator.UserControls.PopUps;

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
        }

        private void SensorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.RowIndex == mainSensorDataGridView.sensorDGV.Rows.GetLastRow(DataGridViewElementStates.Visible))
            {
                return;
            }
            if (mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                if (mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().CompareTo("Edit") == 0)
                {
                    SensorEditing(e);
                }
                else if (mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().CompareTo("Delete") == 0)
                {
                    SensorDeletion(e);
                }

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
            var form = new CreateOrEditForm();
            form.Show();
            form.Closed += (o, args) => { LoadDataGridViewData(); };
        }

        private bool IsDataChanged(int id, Sensor<double> sensorBefore)
        {
            var sensor = DBSelectionService.GetSensorById(id);


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
            form.CreateButton.Hide();
            form.SensorCreate.IdTextBox.Text = mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            form.SensorCreate.NameTextBox.Text = mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            form.SensorCreate.TypeTextBox.Text = mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            form.SensorCreate.MinValueTextBox.Text = mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
            form.SensorCreate.MaxValueTextBox.Text = mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
            form.SensorCreate.GenerationIntervalTextBox.Text = mainSensorDataGridView.sensorDGV.Rows[e.RowIndex].Cells[5].Value.ToString();

            form.CancelButton.Click += (o, args) => { form.Close(); };

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

        private void LoadDataGridViewData()
        {
            mainSensorDataGridView.sensorDGV.Rows.Clear();
            foreach (var sensor in DBSelectionService.GetSensors())
            {
                mainSensorDataGridView.sensorDGV.Rows.Add(sensor.Id, sensor.Name, sensor.Type, sensor.MinValue, sensor.MaxValue, sensor.GenInterValue);

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
    }
}
