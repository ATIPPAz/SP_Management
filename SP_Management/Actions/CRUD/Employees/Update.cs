using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Management.Classes.CRUD.Employees
{
    public class Update
    {
        public void UpdateEmployee(SP_Management.Classes.Data.Employee.Employees emp)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MiddleStore.ConnectPath))
                {
                    string cmd;

                    cmd = $"UPDATE [dbo].[Employees] SET [PositionID] = '{emp.EmpPosition}' ,[DeptID] = '{emp.EmpDepartment}' ,[EmpEmail] = '{emp.EmpEmail}',[EmpFName] = '{emp.EmpFName}',[EmpLName] = '{emp.EmpLName}',[EmpGender] = '{emp.EmpGender}',[EmpSalary] = '{emp.EmpSalary}',[EmpHire] = '{emp.DateHire}',[EmpBirthDay] = '{emp.DateBirth}',[EmpPName] = '{emp.EmpPName}',[EmpPhone] = '{emp.EmpPhone}'WHERE [EmpID] = '{emp.EmpID}'";
                    connection.Open();
                    SqlCommand SqlCmd = new SqlCommand(cmd, connection);
                    SqlCmd.ExecuteNonQuery();
                    connection.Close();
                    connection.Dispose();
                    SqlCmd.Dispose();
                }
                Toast.Success("แก้ไขสำเร็จ");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Toast.Error("กรอกข้อมูลผิดรูปแบบ");
            }
        }
    }
}
