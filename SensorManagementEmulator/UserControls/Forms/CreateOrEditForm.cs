using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SensorManagementEmulator.Models;
using SensorManagementEmulator.services;

namespace SensorManagementEmulator.UserControls
{
    public partial class CreateOrEditForm : Form
    {
        public CreateOrEditForm()
        {
            InitializeComponent();
            this.Icon = new Icon("favicon.ico");
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Sensor<double> sensor = new Sensor<double>();
            try
            {
                sensor = this.SensorCreate.GenerateSensor(false);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid values");
                return;
            }
            DBInsertionService inserSensor = new DBInsertionService();
            inserSensor.InsertSensor(sensor);
            MessageBox.Show("Succesfully created!");
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

        }

        public void Init(Sensor<double> sensor)
        {
            CreateButton.Hide();
            AddDate(sensor);

            SensorCreate.GenerInterBox.SelectionChangeCommitted += delegate (object sender, EventArgs args)
            {
                ComboBox box = (ComboBox)sender;
                GenInterTextbox.Text = ((KeyValuePair<string, int>)box.SelectedItem).Value.ToString();
            };
            SensorCreate.MinMaxComboBox.SelectionChangeCommitted += delegate (object sender, EventArgs args)
            {
                SensorCreate.MinMaxComboBox.Refresh();
                ComboBox box = (ComboBox)sender;
                MinMaxTextbox.Text = box.SelectedText.Substring
                    (box.SelectedText.IndexOf(':') + 2,
                    box.SelectedText.Length - box.SelectedText.IndexOf(':') - 2);
            };
            SensorCreate.ValuesBox.SelectionChangeCommitted += delegate (object sender, EventArgs args)
            {
                ComboBox box = (ComboBox)sender;
                ValueTextbox.Text = ((KeyValuePair<string, double>)box.SelectedItem).Value.ToString();
            };

            if (sensor.MinMax.Count != 0 && SensorCreate.MinMaxComboBox.Items.Count!=0)
            {
                SensorCreate.MinMaxComboBox.SelectedIndex = 0;
                SensorCreate.MinMaxComboBox.SelectedItem = SensorCreate.MinMaxComboBox.Items[0];
                string text = SensorCreate.MinMaxComboBox.SelectedItem.ToString();
                MinMaxTextbox.Text = text.Substring
                (text.IndexOf(':')
                    + 2,
                    text.Length - text.IndexOf(':') - 2);
                SensorCreate.MinMaxComboBox.Refresh();
            }

            if (sensor.GenerIntervals.Count != 0 && SensorCreate.GenerInterBox.Items.Count != 0)
            {
                SensorCreate.GenerInterBox.SelectedIndex = 0;
                GenInterTextbox.Text =
                    ((KeyValuePair<string, int>)SensorCreate.GenerInterBox.Items[0]).Value.ToString();
            }

            if (sensor.values.Count != 0 && SensorCreate.ValuesBox.Items.Count != 0)
            {
                SensorCreate.ValuesBox.SelectedIndex = 0;
                ValueTextbox.Text =
                    ((KeyValuePair<string, double>)SensorCreate.ValuesBox.Items[0]).Value.ToString();
            }






            CancelButton.Click += (o, args) => { Close(); };
        }

        private void SensorCreate_Load(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDate(Sensor<double> sensor)
        {
            SensorCreate.IdTextBox.Text = sensor.id;
            SensorCreate.NameTextBox.Text = sensor.Name;
            SensorCreate.TypeTextBox.Text = sensor.Type;

            foreach (var key in sensor.values)
            {
                SensorCreate.ValuesBox.Items.Add(key);
            }
            foreach (var key in sensor.MinMax)
            {
                SensorCreate.MinMaxComboBox.Items.Add(key.Key + ": " + key.Value[0] + "/" + key.Value[1]);
            }
            foreach (var key in sensor.GenerIntervals)
            {
                SensorCreate.GenerInterBox.Items.Add(key);
            }
        }
    }
}
