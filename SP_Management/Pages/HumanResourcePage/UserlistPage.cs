using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP_Management.Classes.Commands;
using SP_Management.Controls.Tables;
using SP_Management.Classes.Employee;

namespace SP_Management.Pages.HumanResource
{
    public partial class UserlistPage : UserControl
    {
        GetAll getEmployees;
        public UserlistPage()
        {
            InitializeComponent();
            getEmployees = new GetAll();
            Employees[] EmpData = getEmployees.GetEmployee();
            foreach (var Emp in EmpData)
            {
                UserListTable userListTable = new UserListTable(Emp);
                BodyPanel.Controls.Add(userListTable);
                userListTable.Dock = DockStyle.Top;
                userListTable.Tag = Emp.EmpID;
                userListTable.BackColor = Color.White;
                userListTable.ForeColor = Color.Black;
            }
            /* Control[] control =
             {
                 new Label(){ Text = "ID",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "FirstName",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "LastName",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "TelePhone",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "Department",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "Position",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new Label(){ Text = "Email",Dock = DockStyle.Fill,BackColor=Color.FromArgb(62, 148, 239)},
                 new PictureBox(){ SizeMode = PictureBoxSizeMode.Zoom,Dock = DockStyle.Fill },
                 new PictureBox(){ SizeMode = PictureBoxSizeMode.Zoom,Dock = DockStyle.Fill },
             };
             int[] size =
             {
                 0.1,
             };
             HearderTable hearderTable = new HearderTable(size, control);
             hearderTable.Dock = DockStyle.Top;
             TablePanel.Controls.Add(hearderTable);*/
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            Route.index.OpenNewUserPage();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var res = getEmployees.Employee.Where(word => word.EmpID.Contains('E'));
            foreach (var item in res)
            {
                Console.WriteLine(item.EmpID);
            }
        }
    }
}
