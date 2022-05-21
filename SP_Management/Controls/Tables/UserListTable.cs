using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP_Management.Classes.Employee;

namespace SP_Management.Controls.Tables
{
    public partial class UserListTable : UserControl
    {
        Employees emp = null;
        public UserListTable()
        {
            InitializeComponent();
        }
        public UserListTable(Employees emp)
        {
            InitializeComponent();
            this.emp = emp;
            Console.WriteLine(1);
        }

        private void UserListTable_Load(object sender, EventArgs e)
        {
            if(emp != null)
            {
                txtEmpID.Text = emp.EmpID;
                txtFName.Text = emp.EmpFName;
                txtEmpLName.Text = emp.EmpLName;
                txtEmpPhone.Text = emp.EmpPhone;
                txtEmpDepartment.Text = emp.EmpDepartment;
                txtEmpPosition.Text = emp.EmpPosition;
                txtEmpEmail.Text = emp.EmpEmail;
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ดึงข้อมูล ID "+emp.EmpID);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ลบ ID" + emp.EmpID);
        }
    }
}
