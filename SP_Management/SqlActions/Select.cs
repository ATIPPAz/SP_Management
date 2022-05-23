using SP_Management.Others;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Management.SqlActions
{
    public class GetAll
    {
        public DataTable GetData(string Table,string orderID = "",string[] JoinTable = null,string[] JoinId = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(MiddleStore.ConnectPath))
            {
                string cmd;
                cmd = $"select * from dbo.{Table}";
                if(JoinTable != null)
                {
                    for (int i = 0; i < JoinTable.Length; i++)
                    {
                        string[] Id = JoinTable[i].Split(',');
                        cmd += $"inner join dbo.{JoinTable[i]} on '{Id[0]}' = '{Id[1]}'";
                    }
                }
                if(orderID !="")
                {
                    cmd += $"order by {orderID} asc";
                }
                using (SqlCommand SqlCmd = new SqlCommand(cmd, connection)) 
                {
                    using (SqlDataAdapter Adapter = new SqlDataAdapter())
                    {
                        Adapter.SelectCommand = SqlCmd;
                        Adapter.Fill(dataTable);
                        connection.Close();
                        connection.Dispose();
                        Adapter.Dispose();
                        SqlCmd.Dispose();
                    }
                }
            }
            return dataTable;
        }
        public DataTable GetEmployee(string ID = "")
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(MiddleStore.ConnectPath))
            {
                string cmd;
                if (ID != "")
                {
                    cmd = $"Select * from dbo.Employees as e INNER Join dbo.EmployeeAccounts as ea On ea.EmpID = e.EmpID Where e.EmpID = '{ID}'";
                }
                else
                {
                    cmd = "select * from dbo.Employees e order by e.EmpID desc";
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
        public DataTable GetFullEmployee(string WhereID, string ID,string Table, string orderID = "", string[] JoinTable = null, string[] JoinId = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(MiddleStore.ConnectPath))
            {
                string cmd;
                cmd = $"select * from dbo.{Table}";
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
        public DataTable GetData(string ColumnSelect, string[] CallTable, string IDSelect, string[] Table, string orderID = "", string[] JoinColumn = null)
        {
            DataTable dataTable = new DataTable();
            string cmd;
            
            cmd = $"select * from dbo.{Table[0]} ";
            if (Table.Length > 1)
            {
                    for (int i = 1; i < Table.Length; i++)
                    {
                        string[] col = JoinColumn[i-1].Split(',');
                    string[] asName = CallTable[i-1].Split(',');
                    if (i == 1)
                    {
                    cmd += $" {asName[0]} inner join dbo.{Table[i]} {asName[1]} on {asName[0]}.{col[0]} = {asName[1]}.{col[1]} ";
                    }
                    else
                    {
                        cmd += $" inner join dbo.{Table[i]} {asName[1]} on {asName[0]}.{col[0]} = {asName[1]}.{col[1]} ";
                    }
                }
            }
            if (IDSelect != "")
            {
                cmd += $"Where {ColumnSelect} = '{IDSelect}'";
            }
            if (orderID != "")
            {
                cmd += $"order by {orderID} asc";
            }
            Console.WriteLine(cmd);
            try
            {
                using (SqlConnection connection = new SqlConnection(MiddleStore.ConnectPath))
                {
                    using (SqlCommand SqlCmd = new SqlCommand(cmd, connection))
                    {
                        using (SqlDataAdapter Adapter = new SqlDataAdapter())
                        {
                            Adapter.SelectCommand = SqlCmd;
                            Adapter.Fill(dataTable);
                            connection.Close();
                            connection.Dispose();
                            Adapter.Dispose();
                            SqlCmd.Dispose();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Toast.Error("Error sss");
            }
            return dataTable;
        }
        public DataTable GetEmployee(string ID = "", string username = "")
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
