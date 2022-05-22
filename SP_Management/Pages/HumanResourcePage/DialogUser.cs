using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP_Management.Classes;
using SP_Management.Classes.Employee;
namespace SP_Management.Pages.HumanResourcePage
{
    public partial class DialogUser : UserControl
    {
        DataTable Position =  new DataTable ();
        DataTable Departent = new DataTable();

        string[] text = new string[] {
        "ID","UserName","PreFix","FirstName","LastName","Gerder","Email","TelPhone","BirthDate","Department","Position","Salary","HireDate"
        };
        public DialogUser()
        {
            InitializeComponent();
            lblTitle.Text = "AddUser";
            txtID.Enabled = false;
            txtUsername.Enabled = true;
            
        }
      
        public DialogUser(string id)
        {
            InitializeComponent();
            lblTitle.Text = "EditUser";
            txtID.Enabled = false;
            txtUsername.Enabled = false;
            DateHired.CustomFormat = "yyyy-MM-dd";
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
                //txtDepartment.Text = item["EmpFName"].ToString();
                txtLName.Text = item["EmpLName"].ToString();
                txtPhone.Text = item["EmpPhone"].ToString();
               // txtHired.Text = item["EmpUsername"].ToString();
                txtUsername.Text = item["EmpID"].ToString();
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Route.index.CloseDialog();
        }

        private void txtFName_Enter(object sender, EventArgs e)
        {
            Removetext(txtFName,text[3]);
        }
        void Removetext(TextBox textbox,string text)
        {
            if (textbox.Text == text)
            {
                textbox.Text = "";
            }
        }

        void AddText(TextBox textbox, string text) {
            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                textbox.Text = text;
            }
        }
        void AddText(ComboBox textbox, string text)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                textbox.Text = text;
            }
        }
        void Removetext(ComboBox textbox, string text)
        {
            if (textbox.Text == text)
            {
                textbox.Text = "";
            }
        }
        private void txtFName_Leave(object sender, EventArgs e)
        {
            AddText(txtFName, text[3]);
        }

        private void cbPrefix_Enter(object sender, EventArgs e)
        {
            Removetext(cbPrefix,text[2]);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string DeptID;
            string PostionID;
            string Gender = (cbGender.SelectedItem == "ชาย") ? "M":"FM";
            string cmd = "";
            if (lblTitle.Text == "AddUser")
            {
                cmd = $"insert into dbo.Employees Values('P01','D01','{txtEmail.Text}','{txtFName.Text}','{txtLName.Text}','M','{txtSalary.Text}','{DateHired.Value.ToString("yyyy-MM-dd")}','{BirthDate.Value.ToString("yyyy-MM-dd")}','{cbPrefix.SelectedItem}','{txtPhone.Text}');";
            }
            else if (lblTitle.Text == "EditUser")
            {
                cmd = "";
            }
            /*  Console.WriteLine(cbPrefix.SelectedValue);
              Console.WriteLine(cbPrefix.SelectedIndex);
  */
            Console.WriteLine(Gender);
            Console.WriteLine(cbPrefix.SelectedItem);
            /*  Console.WriteLine(cbPrefix.SelectedItem);*/
            Console.WriteLine(DateHired.Value.ToString("yyyy-MM-dd"));
        }

        private void DialogUser_Load(object sender, EventArgs e)
        {
            GetPosition();
            GetDepartment();
        }
        void GetPosition()
        {
            //.Fill(Position);
            /*List<Employees> Employee = new List<Employees>();
            foreach (DataRow data in Position.Rows)
            {
                Employees emp = new Employees();   
                emp.EmpID = data["EmpID"].ToString();
                Employee.Add(emp);
            }*/
        }
        void GetDepartment()
        {
            //.Fill(Department);
        }
    }
}
