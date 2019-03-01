using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorManagementEmulator
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("../../favicon.ico");
            this.Text = "Login form";
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress.Parse(HostnameTextbox.Text);
                DBconnectionService.Connect(UsernameTextbox.Text, PasswordTextbox.Text, HostnameTextbox.Text);
                new MainForm().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong credentials!");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
