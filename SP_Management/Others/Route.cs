using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_Management.Others
{
    public static class Route
    {
        public static Login Login;
        public static SPM index;
        public static bool isStartUp = true;
        public static Form StartUp()
        {
            index = new SPM();
            Login = new Login();
            index.Opacity = 0;
            Login.Show();
            Login.TopMost = true;
            return index;
        }
        public static void CreateLoginPage(Form form)
        {
            Login = new Login();
            isStartUp = true;
            Login.Show();
            Login.TopMost = true;
            index.Opacity = 0;
            if(form != null)
            {
            form.Close();
            }
            index.Hide();
        }
        public static void CloseLoginForm()
        {
            Login.Close();
            Login.Dispose();
        }
        public static void OpenIndex()
        {
            index.Opacity = 1;
            index.Show();
        }
        public static void CloseIndex()
        {
            index.Close();
            Application.Exit();
        }
    }
}
