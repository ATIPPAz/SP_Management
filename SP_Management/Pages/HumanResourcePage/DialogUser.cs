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
using SP_Management.Others;
using SP_Management.Models.Employee;
using SP_Management.SqlActions;

namespace SP_Management.Pages.HumanResourcePage
{
    public partial class DialogUser : UserControl
    {
        DataTable Position =  new DataTable ();
        DataTable Departent = new DataTable();
        DateTime Birth;
        DateTime Hired;
        string[] text = new string[] {
        "ID","UserName","PreFix","FirstName","LastName","Gerder","Email","TelPhone","BirthDate","Department","Position","Salary","HireDate"
        };
        public DialogUser()
        {
            InitializeComponent();
            lblTitle.Text = "AddUser";
            txtID.Enabled = false;
            txtUsername.Enabled = true;
            SetPosition();
            SetDepartment();
            cbDepartment.SelectedIndex = -1;
            cbPosition.SelectedIndex = -1;

        }

        public DialogUser(string id)
        {
            InitializeComponent();
            lblTitle.Text = "EditUser";
            txtID.Enabled = false;
            //txtUsername.Enabled = false;
            try
            {
                Console.WriteLine(id);
                GetData(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void SetDepartment()
        {
            var getdepartment = new GetAll();
            DataTable department = getdepartment.GetData("Departments");
            valueCbBox[] values = new valueCbBox[department.Rows.Count];
            int idx = 0;
            foreach (DataRow pos in department.Rows)
            {
                values[idx] = new valueCbBox();
                values[idx].ID = pos["DeptID"].ToString();
                values[idx].Name = pos["DeptName"].ToString();
                idx++;
            }
            cbDepartment.DataSource = values;
            cbDepartment.DisplayMember = "Name";
            cbDepartment.ValueMember = "ID";
        }

        private void SetPosition()
        {
            var getposition = new GetAll();
            DataTable position = getposition.GetData("Positions");
            valueCbBox[] values = new valueCbBox[position.Rows.Count];
            int idx = 0;
            foreach (DataRow pos in position.Rows)
            {
                values[idx] = new valueCbBox();
                values[idx].ID = pos["PositionID"].ToString();
                values[idx].Name = pos["PositionName"].ToString();
                idx++;
            }
            cbPosition.DataSource = values;
            cbPosition.DisplayMember = "Name";
            cbPosition.ValueMember = "ID";
        }

        void GetData(string id)
        {
            var getdata = new GetOne();
            DataTable EmplyeeData;
            EmplyeeData = getdata.GetData(
                Table:new string[] { "Employees" , "EmployeeAccounts","Departments","Positions" },
                ColumnSelect:"e.EmpID",
                IDSelect:id,
                JoinColumn:new string[] { "EmpID,EmpID","DeptID,DeptID","PositionID,PositionID" },
                CallTable:new string[] {"e,ea","e,d","e,p"});
            foreach (DataRow item in EmplyeeData.Rows)
            {
                txtID.Text = item["EmpID"].ToString();
                txtFName.Text = item["EmpFName"].ToString();
                txtLName.Text = item["EmpLName"].ToString();
                txtPhone.Text = item["EmpPhone"].ToString();
                txtUsername.Text = item["EmpUsername"].ToString();
                txtEmail.Text = item["EmpEmail"].ToString(); 
                txtSalary.Text = item["EmpSalary"].ToString();
                cbDepartment.Text = item["DeptName"].ToString();
                cbGender.Text = (item["EmpGender"].ToString() == "M") ? "ชาย":"หญิง";
                cbPosition.Text = item["PositionName"].ToString();
                cbPrefix.Text = item["EmpPName"].ToString();
                BirthDate.Format = DateTimePickerFormat.Custom;
                BirthDate.CustomFormat = "yyyy-MM-dd";
                DateHired.Format = DateTimePickerFormat.Custom;
                DateHired.CustomFormat = "yyyy-MM-dd";
                BirthDate.Value = Convert.ToDateTime(item["EmpBirthDay"].ToString());
                DateHired.Value = Convert.ToDateTime(item["EmpHire"].ToString());
            }
            SetPosition();
            SetDepartment();
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

        private void SaveBtn_Click(object sender, EventArgs e) {

            Console.WriteLine(cbGender.SelectedItem);
            Console.WriteLine(cbDepartment.SelectedValue.ToString());
            Console.WriteLine(BirthDate.Value.ToString("yyyy-MM-dd"));
            Employee emp = new Employee()
            {
                EmpDepartment = cbDepartment.SelectedValue.ToString(),
                EmpPosition = cbPosition.SelectedValue.ToString(),
                EmpGender = (cbGender.SelectedItem.ToString() == "ชาย") ? "M" : "FM",
                EmpEmail = txtEmail.Text,
                EmpFName = txtFName.Text,
                EmpLName = txtLName.Text,
                EmpPhone = txtPhone.Text,
                EmpID = txtID.Text,
                EmpUsername = txtUsername.Text,
                DateBirth = BirthDate.Value.ToString("yyyy-MM-dd"),
                DateHire = DateHired.Value.ToString("yyyy-MM-dd"),
                EmpPName = cbPrefix.SelectedItem.ToString(),
                EmpSalary = txtSalary.Text
            };
            Console.WriteLine(emp.EmpGender);
            if (lblTitle.Text == "AddUser")
            {
                Insert createEmp = new Insert() { };
                createEmp.Create("Employees",new string[] {
                "PositionID","DeptID" ,"EmpEmail" ,"EmpFName" ,"EmpLName" ,"EmpGender" ,"EmpSalary","EmpHire","EmpBirthDay","EmpPName","EmpPhone"
                },new string[]{
                emp.EmpPosition.ToString(),emp.EmpDepartment.ToString(),emp.EmpEmail.ToString(),emp.EmpFName.ToString(),emp.EmpLName.ToString(),emp.EmpGender.ToString(),emp.EmpSalary.ToString(),emp.DateHire.ToString(),emp.DateBirth.ToString(),emp.EmpPName.ToString(),emp.EmpPhone
                });

                GetOne getEmp = new GetOne();
                var dataEmp = getEmp.GetData(
                    Table:new string[] {"Employees"},
                    CallTable:new string[] {"e"},
                    ColumnSelect:"EmpFName",
                    IDSelect: emp.EmpFName
                );

                string username = "";
                foreach (DataRow data in dataEmp.Rows)
                {
                    username = data["EmpID"].ToString();
                }
                string password = BCrypt.Net.BCrypt.HashPassword("1234", GetRandomSalt());
                Insert createAcc = new Insert() { };
                createAcc.Create("EmployeeAccounts", new string[] {
               "EmpID","EmpUsername","EmpPassword"
                }, new string[]{
                username,emp.EmpUsername,password
                });
                Toast.Success("เพิ่มสำเร็จ");
            }
            else if (lblTitle.Text == "EditUser")
            {
                Update update = new Update();
                update.Updatedata(Table:"Employees" , ColoumnUpdate:new string[]
                {
                    "PositionID"  ,"DeptID" ,"EmpEmail","EmpFName","EmpLName","EmpGender" ,"EmpSalary","EmpHire","EmpBirthDay","EmpPName"  ,"EmpPhone"
                },
                ColumnValue:new string[] {
                 emp.EmpPosition ,  emp.EmpDepartment ,  emp.EmpEmail, emp.EmpFName,  emp.EmpLName, emp.EmpGender, emp.EmpSalary, emp.DateHire,  emp.DateBirth, emp.EmpPName, emp.EmpPhone
                },
                SelectRowUpdate:"EmpID",
                SelectValue:emp.EmpID);
                Toast.Success("เพิ่มสำเร็จ");
            }
        }
        private string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
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
    public class valueCbBox
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}
