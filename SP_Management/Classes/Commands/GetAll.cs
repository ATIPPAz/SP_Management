/*using System;
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
        public  DataTable EmplyeeData;
        public Employees[] GetEmployee()
        {
            
            Sql.SqlConnectionOpen();
            //Load data Employee
            string cmd = $"select * from dbo.Employees e order by e.EmpID desc";
            Sql.RunCommand(cmd);
            Sql._adapter.SelectCommand = Sql._command;
            EmplyeeData = new DataTable();
            Sql._adapter.Fill(EmplyeeData);
            EmplyeeData.DefaultView.Sort = "EmpID ASC";

            Sql.destroyCmd();
            Employees[] userlist = new Employees[EmplyeeData.Rows.Count];
            Employee = new Employees[EmplyeeData.Rows.Count];
            int idx = 0;
                foreach (DataRow item in EmplyeeData.Rows)
                {
                    Employee[idx] = new Employees();
                    Employee[idx].EmpID = item["EmpID"].ToString();
                    Employee[idx].EmpFName = item["EmpFName"].ToString();
                    Employee[idx].EmpLName = item["EmpLName"].ToString();
                    Employee[idx].EmpPhone = item["EmpPhone"].ToString();
                    Employee[idx].EmpDepartment = item["DeptID"].ToString();
                    Employee[idx].EmpPosition = item["PositionID"].ToString();
                    Employee[idx].EmpEmail = item["EmpEmail"].ToString();
                    Console.WriteLine(Employee[idx].EmpID);
                    *//*userlist[idx] = new Employees();
                    userlist[idx].EmpID = item["EmpID"].ToString();
                    userlist[idx].EmpFName = item["EmpFName"].ToString();
                    userlist[idx].EmpLName = item["EmpLName"].ToString();
                    userlist[idx].EmpPhone = item["EmpPhone"].ToString();
                    userlist[idx].EmpDepartment = item["DeptID"].ToString();
                    userlist[idx].EmpPosition = item["PositionID"].ToString();
                    userlist[idx].EmpEmail = item["EmpEmail"].ToString();
                    Console.WriteLine(item["EmpID"].ToString());*//*
                idx += 1;
                }
        *//*    var data = Employee.OrderBy(e => e.EmpID);
            Employee = data.ToArray();*//*
            return Employee;

            *//*return userlist;*//*
        }
    }
}
*/