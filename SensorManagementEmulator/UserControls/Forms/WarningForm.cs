using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorManagementEmulator.UserControls.PopUps
{
    public partial class WarningForm : Form
    {
        public WarningForm()
        {
            InitializeComponent();
            this.Icon = new Icon("favicon.ico");
        }

        private void WarningForm_Load(object sender, EventArgs e)
        {

        }
    }
}
