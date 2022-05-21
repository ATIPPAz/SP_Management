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
            for (int i = 0; i < userlist.Length; i++)
            {
                foreach (DataRow item in EmplyeeData.Rows)
                {
                    userlist[i] = new Employees();
                    userlist[i].EmpID ="E"+(Convert.ToInt32(((item["EmpID"]).ToString().Split('E')[0]+i+1)));
                    userlist[i].EmpFName = item["EmpFName"].ToString();
                    userlist[i].EmpLName = item["EmpLName"].ToString();
                    userlist[i].EmpPhone = item["EmpPhone"].ToString();
                    userlist[i].EmpDepartment = item["DeptID"].ToString();
                    userlist[i].EmpPosition = item["PositionID"].ToString();
                   userlist[i].EmpEmail = item["EmpEmail"].ToString();
                }
            }
            return userlist;
        }
    }
}
