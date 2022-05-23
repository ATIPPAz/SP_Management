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
using SP_Management.Classes.CRUD.Postitions;
using SP_Management.Classes.CRUD.Employees;
using SP_Management.Classes.Data.Employee;
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
            SetPosition();
            SetDepartment();
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
            var getposition = new Classes.CRUD.Departments.GetAll();
            DataTable department = getposition.GetPosition();
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
            var getposition = new Classes.CRUD.Postitions.GetAll();
            DataTable position = getposition.GetPosition();
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
            var getdata = new Classes.CRUD.Employees.GetAll();
            DataTable EmplyeeData = new DataTable();
            EmplyeeData = getdata.GetFullEmployee(ID: id);
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
            Employees emp = new Employees()
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
                Create update = new Create(){};
                update.CreateNewEmployee(emp);
            }
            else if (lblTitle.Text == "EditUser")
            {
                Update update = new Update() { };
                update.UpdateEmployee(emp);
            }
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
