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
    public partial class Toast : Form
    {
        public Toast()
        {
            InitializeComponent();
            this.TopMost = true;
        }
       
      
        public static void Success(string message = "")
        {
            Toast toast = new Toast();
            toast.success(message);
            toast.Show();
        }
        private void success(string message = "")
        {
            this.BackColor = Color.SeaGreen;
            this.LabelAlert.Text = String.IsNullOrEmpty(message) ? "Success" : message;
            
            TimerAlert.Start();
        }
        public static void Info(string message = "")
        {
            /*this.BackColor = Color.Gray;
            this.LabelAlert.Text = String.IsNullOrEmpty(message) ? "Info":message ;
            
           
            TimerAlert.Start();*/
        }
        public static void Warning(string message = "")
        {
           /* this.BackColor = Color.Crimson;
            this.LabelAlert.Text = String.IsNullOrEmpty(message) ? "Warning":message ;
            
           
            TimerAlert.Start();*/
        }
        public static void Error(string message = "")
        {
            Toast toast = new Toast();
            toast.error(message);
            toast.Show();
        }
        private void error(string message = "")
        {
            this.BackColor = Color.FromArgb(204, 0, 0);
            this.LabelAlert.Text = String.IsNullOrEmpty(message) ? "Error" : message;
            TimerAlert.Start();
        }




        private void TimerAlert_Tick(object sender, EventArgs e)
        {
            TimerClose.Start();
           
        }
        int interval = 0;
        private void TimerAnimated_Tick(object sender, EventArgs e)
        {
            if (this.Top <60)
            {
                this.Top += interval;
                interval +=2;
            }
            else
            {
                TimerAnimated.Stop();
               
            }
        }

        private void Toast_Load(object sender, EventArgs e)
        {
            this.Top = -1*(this.Height);
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 100;
            TimerAnimated.Start();
        }

        private void TimerClose_Tick(object sender, EventArgs e)
        {
            if(this.Opacity > 0){
                this.Opacity-=0.01;
                Console.WriteLine("sdsdsds");
            }
            else
            {
                this.Close();
            }
        }
    }
}
