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
using SensorManagementEmulator.Constants;

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
            this.PasswordTextbox.PasswordChar = '*';
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress.Parse(HostnameTextbox.Text);
                DBconnectionService dBconnection = new DBconnectionService();
                dBconnection.Connect(UsernameTextbox.Text, PasswordTextbox.Text, HostnameTextbox.Text);

                DBconnection.HostName = HostnameTextbox.Text;
                DBconnection.Password = PasswordTextbox.Text;
                DBconnection.Username = UsernameTextbox.Text;
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
