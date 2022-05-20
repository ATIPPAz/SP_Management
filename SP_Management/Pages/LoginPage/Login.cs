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

       

        private void checkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            PasswordText.PasswordChar = checkShowPassword.Checked ? '\0' : '•';
           
        }
        private bool CheckTextBox()
        {
           
            if (string.IsNullOrEmpty(UsernameText.Text) || UsernameText.Text=="")
            {
                UsernameText.Clear();
                Toast.Error("Please Enter Username");
                UsernameText.Focus();
                return true;
            }
            if (string.IsNullOrEmpty(PasswordText.Text) || PasswordText.Text == "")
            {
                PasswordText.Clear();
                Toast.Error("Please Enter Password");
                PasswordText.Focus();
                return true;
            }
            return false;
        }



        
        private void UsernameText_Click(object sender, EventArgs e)
        {
            /* TimerUserIn.Start(); 
             TimerPassOut.Start();
             UsernameLine.Location = new Point(85, 257);*/
            UsernameLine.Location = new Point(85, 242);
            UsernameLine.Height = 3;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            UsernameLine.Location = new Point(85, 257);
            PasswordLine.Location = new Point(85, 330);
            UsernameLine.Height = 0;
            PasswordLine.Height = 0;
        }

        private void PasswordText_Click(object sender, EventArgs e)
        {
            /*TimerUserOut.Start();
            TimerPassIn.Start();
            PasswordLine.Location = new Point(85, 330);*/
            PasswordLine.Location = new Point(85, 315);
            PasswordLine.Height = 3;
        }

        private void TimerAnimatedUser_Tick(object sender, EventArgs e)
        {
            if (UsernameLine.Location.Y > 257-15) { 
            UsernameLine.Location = new Point(85, UsernameLine.Location.Y-1);
                if(UsernameLine.Location.Y - (257)==-5)
                {
                    UsernameLine.Height += 1;
                }
                else if (UsernameLine.Location.Y - (257) == -10)
                {
                    UsernameLine.Height += 1;
                }
                else if (UsernameLine.Location.Y - (257) == -14)
                {
                    UsernameLine.Height += 1;
                }
            }
            else
            {
                UsernameLine.Location = new Point(85, 242);
                UsernameLine.Height = 3;
                TimerUserIn.Stop();
            }
        }

        private void TimerUserOut_Tick(object sender, EventArgs e)
        {
            if (UsernameLine.Location.Y < 257 )
            {
                UsernameLine.Location = new Point(85, UsernameLine.Location.Y + 1);
                if (UsernameLine.Location.Y - (257) == -5)
                {
                   
                    UsernameLine.Height -= 1;
                }
                else if (UsernameLine.Location.Y - (257) == -10)
                {
                   
                    UsernameLine.Height -= 1;
                }
                else if (UsernameLine.Location.Y - (257) == -14)
                {
                   
                    UsernameLine.Height -= 1;
                }
            }
            else
            {
                UsernameLine.Height =0;
                UsernameLine.Location = new Point(85, 257);
                TimerUserOut.Stop();
            }
        }

        private void TimerPassIn_Tick(object sender, EventArgs e)
        {
            if (PasswordLine.Location.Y > 330 - 15)
            {
                PasswordLine.Location = new Point(85, PasswordLine.Location.Y - 1);
                if (PasswordLine.Location.Y - (330) == -5)
                {
                    PasswordLine.Height += 1;
                }
                else if (PasswordLine.Location.Y - (330) == -10)
                {
                    PasswordLine.Height += 1;
                }
                else if (UsernameLine.Location.Y - (330) == -14)
                {
                    PasswordLine.Height += 1;
                }
            }
            else
            {
                PasswordLine.Location = new Point(85, 315);
                PasswordLine.Height = 3;
                TimerPassIn.Stop();
            }
        }

        private void TimerPassOut_Tick(object sender, EventArgs e)
        {

            if (PasswordLine.Location.Y < 330)
            {
                PasswordLine.Location = new Point(85, PasswordLine.Location.Y + 1);
                if (PasswordLine.Location.Y - (330) == -5)
                {
                   
                    PasswordLine.Height -= 1;
                }
                else if (UsernameLine.Location.Y - (330) == -10)
                {
                    
                    PasswordLine.Height -= 1;
                }
                else if (PasswordLine.Location.Y - (330) == -14)
                {
                  
                    PasswordLine.Height -= 1;
                }
            }
            else
            {
                PasswordLine.Height = 0;
                PasswordLine.Location = new Point(85, 330);
                TimerPassOut.Stop();
            }
        }

        private void UsernameText_MouseHover(object sender, EventArgs e)
        {
            TimerUserIn.Start();
            TimerPassOut.Start();
            UsernameLine.Location = new Point(85, 257);
        }

        private void UsernameText_MouseLeave(object sender, EventArgs e)
        {
            TimerUserIn.Stop();
            TimerUserOut.Start();
            TimerPassOut.Start();
        }

        private void PasswordText_MouseHover(object sender, EventArgs e)
        {
            TimerPassIn.Start();
            TimerUserOut.Start();
            PasswordLine.Location = new Point(85, 330);
        }

        private void PasswordText_MouseLeave(object sender, EventArgs e)
        {
            TimerPassIn.Stop();
            TimerPassOut.Start();
            TimerUserOut.Start();
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            Route.CloseIndex();
        }

        private void PasswordText_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        void LoginProcess() 
        {
            if (!CheckTextBox())
            {
                Console.WriteLine(UsernameText.Text);
                Console.WriteLine(PasswordText.Text);

                //ส่งข้อมูลไปหา sql
                Toast.Success("Login Success");
                Route.OpenIndex();
                Route.CloseLoginForm();
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void UsernameText_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void buttonLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                LoginProcess();
            }
        }
    }
}
