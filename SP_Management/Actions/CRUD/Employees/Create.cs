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
    public class Create
    {

        public void CreateNewEmployee(SP_Management.Classes.Data.Employee.Employees emp)
        {
            try
            {
                using (SqlConnection connections = new SqlConnection(MiddleStore.ConnectPath))
                {
                    string cmd;
                    cmd = $"insert into dbo.Employees ([PositionID],[DeptID] ,[EmpEmail] ,[EmpFName] ,[EmpLName] ,[EmpGender] ,[EmpSalary],[EmpHire],[EmpBirthDay],[EmpPName],[EmpPhone]) Values('{emp.EmpPosition}','{emp.EmpDepartment}','{emp.EmpEmail}','{emp.EmpFName}','{emp.EmpLName}','{emp.EmpGender}','{emp.EmpSalary}','{emp.DateHire}','{emp.DateBirth}','{emp.EmpPName}','{emp.EmpPhone}');";
                    //cmd = $"insert into dbo.Employees ([PositionID],[DeptID] ,[EmpEmail] ,[EmpFName] ,[EmpLName] ,[EmpGender] ,[EmpSalary],[EmpHire],[EmpBirthDay],[EmpPName],[EmpPhone])VALUES ( @PositionID , @DeptID ,@EmpEmail,@EmpFName,@EmpLName,@EmpGender,@EmpSalary,@EmpHire,@EmpBirthDay,@EmpPName,@EmpPhone)";
                    Console.WriteLine(cmd);
                    connections.Open();
                    Console.WriteLine("add");
                    SqlCommand SqlCmd = new SqlCommand(cmd, connections);
                    Console.WriteLine("addfi");
                    /*SqlCmd.CommandType = System.Data.CommandType.Text;
                    SqlCmd.Parameters.AddWithValue("@PositionID", emp.EmpPosition);
                    SqlCmd.Parameters.AddWithValue("@DeptID", emp.EmpDepartment);
                    SqlCmd.Parameters.AddWithValue("@EmpEmail", emp.EmpEmail);
                    SqlCmd.Parameters.AddWithValue("@EmpFName", emp.EmpFName);
                    SqlCmd.Parameters.AddWithValue("@EmpLName", emp.EmpLName);
                    SqlCmd.Parameters.AddWithValue("@EmpGender", emp.EmpFName);
                    SqlCmd.Parameters.AddWithValue("@EmpSalary", emp.EmpSalary);
                    SqlCmd.Parameters.AddWithValue("@EmpHire", emp.DateHire);
                    SqlCmd.Parameters.AddWithValue("@EmpBirthDay", emp.DateBirth);
                    SqlCmd.Parameters.AddWithValue("@EmpPName ", emp.EmpPName);
                    SqlCmd.Parameters.AddWithValue("@EmpPhone", emp.EmpPhone);*/
                   SqlCmd.ExecuteNonQuery();
                    cmd = $"select EmpID from dbo.Employees e Where e.EmpFName= '{emp.EmpFName}' And e.EmpLName = '{emp.EmpLName}'";
                    SqlCmd = new SqlCommand(cmd, connections);
                    SqlDataAdapter adap = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    adap.SelectCommand = SqlCmd;
                    adap.Fill(dt);
                    foreach (DataRow s in dt.Rows)
                    {
                        emp.EmpID = s["EmpID"].ToString();
                    }
                    connections.Close();
                    connections.Dispose();
                    /*Adapter.Dispose();*/
                    SqlCmd.Dispose();
                 
                }
                using (SqlConnection connection = new SqlConnection(MiddleStore.ConnectPath))
                {
                    string cmd;
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword("1234", GetRandomSalt());
                    Console.WriteLine(passwordHash);
                    connection.Open();
                    cmd = $"insert into dbo.EmployeeAccounts([EmpID],[EmpUsername],[EmpPassword]) Values('{emp.EmpID}','{emp.EmpUsername}','{passwordHash}');";
                    SqlCommand SqlCmd = new SqlCommand(cmd, connection);
                    SqlDataAdapter Adapter = new SqlDataAdapter();
                    Console.WriteLine("add");
                    SqlCmd.ExecuteNonQuery();
                    Console.WriteLine("added");
                    connection.Close();
                    connection.Dispose();
                    Adapter.Dispose();
                    SqlCmd.Dispose();
                    Console.WriteLine("fimi");

                }
                Toast.Success("เพิ่มสำเร็จ");
            }
            catch (Exception ex)
            {
                Toast.Error("กรอกข้อมูลผิดรูปแบบ");
            }
          
        }

        private string GetRandomSalt()
        {
           return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
    }
}
