using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SP_Management.Classes.Data.Employee;

namespace SP_Management.Classes.CRUD.Employees
{
    public class GetAll
    {
       
        public DataTable GetEmployee(string ID ="")
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection =new SqlConnection(MiddleStore.ConnectPath))
            {
                string cmd;
                if (ID !="")
                {
                    cmd = $"Select * from dbo.Employees as e INNER Join dbo.EmployeeAccounts as ea On ea.EmpID = e.EmpID Where e.EmpID = '{ID}'";
                }
                else
                {
                    cmd = "select * from dbo.Employees e order by e.EmpID desc";
                }  
                SqlCommand SqlCmd = new SqlCommand(cmd,connection);
                SqlDataAdapter Adapter = new SqlDataAdapter();
                Adapter.SelectCommand = SqlCmd;
                Adapter.Fill(dataTable);
                connection.Close();
                connection.Dispose();
                Adapter.Dispose();
                SqlCmd.Dispose();
            }
            return dataTable;
        }
        public DataTable GetFullEmployee(string ID = "")
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(MiddleStore.ConnectPath))
            {
                string cmd;
                if (ID != "")
                {
                    cmd = $"Select * from dbo.Employees as e INNER Join dbo.Departments d On d.DeptID = e.DeptID Inner join dbo.Positions p on e.PositionID = p.PositionID left join EmployeeAccounts ea on ea.EmpID = e.EmpID Where e.EmpID = '{ID}'";
                }
                else
                {
                    cmd = "Select * from dbo.Employees as e INNER Join dbo.Departments d On d.DeptID = e.DeptID Inner join dbo.Positions p on e.PositionID = p.PositionID order by e.EmpID desc";
                }
                SqlCommand SqlCmd = new SqlCommand(cmd, connection);
                SqlDataAdapter Adapter = new SqlDataAdapter();
                Adapter.SelectCommand = SqlCmd;
                Adapter.Fill(dataTable);
                connection.Close();
                connection.Dispose();
                Adapter.Dispose();
                SqlCmd.Dispose();
            }
            return dataTable;
        }

    }
    public class GetOne
    {
        public DataTable GetEmployee(string ID="",string username = "")
        {
            DataTable dataTable = new DataTable();
            string cmd;
            try
            {
                using (SqlConnection connection = new SqlConnection(MiddleStore.ConnectPath))
                {
                    if (ID != "")
                    {
                        cmd = $"select * from dbo.Employees e Where e.EmpID = '{ID}'";
                    }
                    else if (username != "")
                    {
                        cmd = $"Select * From dbo.EmployeeAccounts e Where e.EmpUsername = '{username}'";
                    }
                    else
                    {
                       return new DataTable(); 
                    }
                    SqlCommand SqlCmd = new SqlCommand(cmd, connection);
                    SqlDataAdapter Adapter = new SqlDataAdapter();
                    Adapter.SelectCommand = SqlCmd;
                    Adapter.Fill(dataTable);
                    connection.Close();
                    connection.Dispose();
                    Adapter.Dispose();
                    SqlCmd.Dispose();
                }
            }
    
            catch (Exception ex)
            {
                Toast.Error("Error");
            }
            return dataTable;
        }
        public DataTable GetEmployeeAndAccount(string ID = "")
        {
            DataTable dataTable = new DataTable();
            string cmd;
            try
            {
                using (SqlConnection connection = new SqlConnection(MiddleStore.ConnectPath))
                {
                    if (ID != "")
                    {
                        cmd = $"Select * From dbo.EmployeeAccounts e Inner Join dbo.EmployeeAccounts ea On ea.EmpId = e.EmpID Where e.EmpID = '{ID}'";
                    }
                    else
                    {
                        cmd = "";
                    }
                    SqlCommand SqlCmd = new SqlCommand(cmd, connection);
                    SqlDataAdapter Adapter = new SqlDataAdapter();
                    Adapter.SelectCommand = SqlCmd;
                    Adapter.Fill(dataTable);
                    connection.Close();
                    connection.Dispose();
                    Adapter.Dispose();
                    SqlCmd.Dispose();
                }
            }

            catch (Exception ex)
            {
                Toast.Error("Error");
            }
            return dataTable;
        }
    }
}
