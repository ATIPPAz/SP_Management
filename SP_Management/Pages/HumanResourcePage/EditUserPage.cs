using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP_Management.Classes;
using SP_Management.Classes.Employee;
namespace SP_Management.Pages.HumanResourcePage
{
    public partial class EditUserPage : UserControl
    {
        public EditUserPage()
        {
            InitializeComponent();
        }
        public EditUserPage(string id)
        {
            InitializeComponent();
            try
            {
                GetData(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        void GetData(string id)
        {
            string cmd = $"Select * from dbo.Employees as e INNER Join dbo.EmployeeAccounts as ea On ea.EmpID = e.EmpID Where e.EmpID = '{id}'";
            Sql.RunCommand(cmd);
            Sql._adapter.SelectCommand = Sql._command;
            DataTable EmplyeeData = new DataTable();
            Sql._adapter.Fill(EmplyeeData);
            Sql.destroyCmd();
            Console.WriteLine(EmplyeeData.Rows.Count);
            foreach (DataRow item in EmplyeeData.Rows)
            {
                txtID.Text = item["EmpEmail"].ToString();
                txtDepartment.Text = item["EmpFName"].ToString();
                txtLName.Text = item["EmpLName"].ToString();
                txtPhone.Text = item["EmpPhone"].ToString();
                txtHired.Text = item["EmpUsername"].ToString();
                txtUsername.Text = item["EmpID"].ToString();
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
        }
    }
}
