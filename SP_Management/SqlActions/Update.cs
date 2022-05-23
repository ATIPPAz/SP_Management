using SP_Management.Others;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Management.SqlActions
{
    public class Update
    {
        public void Updatedata(string Table, string[] ColoumnUpdate, string[] ColumnValue,string SelectRowUpdate,string SelectValue)
        {
            string cmd;
            try
            {
                cmd = $"UPDATE [dbo].[{Table}] ";
                cmd += $"SET ";
                for (int i = 0; i < ColoumnUpdate.Length; i++)
                {
                    if (i == ColoumnUpdate.Length - 1)
                    {
                        cmd += $"[{ColoumnUpdate[i]}] = '{ColumnValue[i]}' ";
                    }
                    else
                    {
                        cmd += $"[{ColoumnUpdate[i]}] = '{ColumnValue[i]}',";
                    }
                }
                cmd += $"WHERE [{SelectRowUpdate}] = '{SelectValue}'";
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
