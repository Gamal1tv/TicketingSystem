using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ticketing_System
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Form1 cScreen = new Form1();
            cScreen.userCustomer();
            Hide();
            cScreen.ShowDialog();
            Application.Exit();
        }

        private void btnTechnician_Click(object sender, EventArgs e)
        {
            Form1 tScreen = new Form1();
            Hide();
            tScreen.ShowDialog();
            Application.Exit();
        }
    }
}
