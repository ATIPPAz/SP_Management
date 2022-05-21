using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SP_Management.Classes.Employee;
namespace SP_Management.Classes.Commands
{
    public class GetAll
    {
        public Employees[] Employee;
        public Employees[] GetEmployee()
        {
            Employees[] userlist = new Employees[12];
            Sql.SqlConnectionOpen();
            //Load data Employee
            string cmd = $"select * from dbo.Employees e ";
            Sql.RunCommand(cmd);
            Sql._adapter.SelectCommand = Sql._command;
            DataTable EmplyeeData = new DataTable();
            Sql._adapter.Fill(EmplyeeData);
            Sql.destroyCmd();
            Console.WriteLine(EmplyeeData.Rows.Count);
            Employee = new Employees[12];
            for (int i = 0; i < userlist.Length; i++)
            {
                foreach (DataRow item in EmplyeeData.Rows)
                {
                    Employee[i] = new Employees();
                    Employee[i].EmpID = item["EmpID"].ToString();
                    Employee[i].EmpFName = item["EmpFName"].ToString();
                    Employee[i].EmpLName = item["EmpLName"].ToString();
                    Employee[i].EmpPhone = item["EmpPhone"].ToString();
                    Employee[i].EmpDepartment = item["DeptID"].ToString();
                    Employee[i].EmpPosition = item["PositionID"].ToString();
                    Employee[i].EmpEmail = item["EmpEmail"].ToString();
                    userlist[i] = new Employees();
                    userlist[i].EmpID = "E" + (Convert.ToInt32(((item["EmpID"]).ToString().Split('E')[0] + i + 1)));
                    userlist[i].EmpFName = item["EmpFName"].ToString();
                    userlist[i].EmpLName = item["EmpLName"].ToString();
                    userlist[i].EmpPhone = item["EmpPhone"].ToString();
                    userlist[i].EmpDepartment = item["DeptID"].ToString();
                    userlist[i].EmpPosition = item["PositionID"].ToString();
                    userlist[i].EmpEmail = item["EmpEmail"].ToString();
                }
            }
            //return Employee;

            return userlist;
        }
    }
}
