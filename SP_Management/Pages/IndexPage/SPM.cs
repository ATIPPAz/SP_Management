using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_Management
{
    public partial class SPM : Form
    {

        public SPM()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*  MessageBox.Show(Environment.GetEnvironmentVariable("DB"));*/

            Toast.Success("test");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Toast.Error("test");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Toast.Info("test");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Toast.Warning("test");
        }

        private void SPM_Load(object sender, EventArgs e)
        {
            if (Route.isStartUp)
            {
                Route.isStartUp = false;
                Route.index.Hide();
            }
        }

        private void Logoutbutton_Click(object sender, EventArgs e)
        {
            Toast.Success("Logout Success");
            Route.CreateLoginPage();
        }
    }
}
