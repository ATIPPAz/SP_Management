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
    public partial class Login : Form
    {
       
        public Login()
        {
            InitializeComponent();
            Environment.SetEnvironmentVariable("DB","localhost");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Toast.Success("Login Success");
            Route.OpenIndex();
            Route.CloseLoginForm();
        }
    }
}
