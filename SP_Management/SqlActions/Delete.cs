using SP_Management.Others;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Management.SqlActions
{
    public class Delete
    {
        public void DeleteData(string Table, string[] ColumnSelect,string[] ColumnValue)
        {
            Console.WriteLine("sdsds");
            string cmd;
            try
            {
                cmd = $"DELETE FROM [dbo].[{Table}] Where ";
                for (int i = 0; i < ColumnSelect.Length; i++)
                {
                    cmd += $"( {ColumnSelect[i]} = '{ColumnValue[i]}') ";
                }
                Console.WriteLine(cmd);
                using (SqlConnection connection = new SqlConnection(MiddleStore.ConnectPath))
                {
                   
                    connection.Open();
                    using (SqlCommand SqlCmd = new SqlCommand(cmd, connection))
                    {
                        SqlCmd.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                        SqlCmd.Dispose();
                    }  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Toast.Error("กรอกข้อมูลผิดรูปแบบ");
            }
        }
    }
}
