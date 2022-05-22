using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP_Management.Classes.Data.Employee;
using SP_Management.Classes;
namespace SP_Management.Controls.Tables
{
    public partial class TableExample : UserControl
    {
        Employees emp = null;
        public TableExample()
        {
            InitializeComponent();
        }
        public TableExample(Employees emp)
        {
            InitializeComponent();
            this.emp = emp;
            foreach (ColumnStyle item in tableLayoutPanel1.ColumnStyles)
            {
                Console.WriteLine(item.SizeType + " : " + item.Width);
            }
            
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
        public string GetID()
        {
            return txtEmpID.Text;
        }
        public string GetFName()
        {
            return txtFName.Text;
        }
        public string GetLname()
        {
            return txtEmpLName.Text;
        }
        public string GetPhone()
        {
            return txtEmpPhone.Text;
        }
        public string GetDept()
        {
            return txtEmpDepartment.Text;
        }
        public string GetEmail()
        {
            return txtEmpEmail.Text;
        }
        public string GetPosition()
        {
            return txtEmpPosition.Text;
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            Route.index.OpenEditUserPage(emp.EmpID);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ลบ ID" + emp.EmpID);
        }
    }
}
