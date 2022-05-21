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
        public UserlistPage()
        {
            InitializeComponent();
            GetAll getEmployees = new GetAll();
            Employees[] EmpData = getEmployees.GetEmployee();
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Tag = "E001";
            foreach (var Emp in EmpData)
            {
                UserListTable userListTable = new UserListTable(Emp);
                userListTable.Dock = DockStyle.Top;
                userListTable.Tag = Emp.EmpID;
                userListTable.BackColor = Color.Red;
                userListTable.ForeColor = Color.Green;
                TablePanel.Controls.Add(userListTable);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Route.index.OpenNewUserPage();   
        }
    }
}
