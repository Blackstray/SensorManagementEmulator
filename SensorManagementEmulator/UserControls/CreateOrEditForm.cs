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
                MessageBox.Show("Invadil values");
                return;
            }
            DBInsertionService.Insert(sensor);
            MessageBox.Show("Succesfully created!");
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

        }

        private void SensorCreate_Load(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
