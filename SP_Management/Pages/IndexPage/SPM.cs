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

     

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
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
            Route.CreateLoginPage(null);
           // Route.CreateLoginPage(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* if (panel2.Width ==200)
            {
            panel2.Width = 50;
            }
            else
            {
                panel2.Width = 200;
            }*/
            panel3.Width = (panel2.Width == 200) ? panel3.Width+150 : panel3.Width-150;
            panel3.Location = (panel2.Width == 200) ?  new Point(panel3.Location.X-150, panel3.Location.Y): new Point(panel3.Location.X + 150, panel3.Location.Y);
            panel2.Width = (panel2.Width == 200) ? 50 : 200;
        }
    }
}
