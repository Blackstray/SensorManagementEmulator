using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SensorManagementEmulator.Models;

namespace SensorManagementEmulator.UserControls
{
    public partial class SensorCreateOtEdit : UserControl
    {
        public SensorCreateOtEdit()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SensorCreateOtEdit_Load(object sender, EventArgs e)
        {

        }

        public Sensor<double> GenerateSensor(bool withId)
        {
            Sensor<double> sensor = new Sensor<double>();

            sensor = new Sensor<double>
            {
                Name = NameTextBox.Text,
                Type = TypeTextBox.Text
            };
            if (withId)
            {
                sensor.Id = int.Parse(IdTextBox.Text);
            }

            return sensor;
        }

        private void GenerationInterval_Click(object sender, EventArgs e)
        {

        }
    }
}
