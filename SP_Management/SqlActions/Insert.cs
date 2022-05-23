using SP_Management.Others;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Management.SqlActions
{
    public class Insert
    {
        public void Create(string Table,string[] ColumnCreate ,string[] ColumnValue)
        {
            try
            {
                string cmd;
                cmd = $"insert into dbo.{Table}";
                cmd += " (";
                for (int i = 0; i < ColumnCreate.Length; i++)
                {
                    if (i == ColumnCreate.Length - 1)
                    {
                        cmd += $"[{ColumnCreate[i]}]";
                    }
                    else
                    {
                        cmd += $"[{ColumnCreate[i]}],";
                    }
                }
                cmd += ") Values (";
                for (int i = 0; i < ColumnValue.Length; i++)
                {
                    if (i == ColumnValue.Length - 1)
                    {
                        cmd += $"'{ColumnValue[i]}'";
                    }
                    else
                    {
                        cmd += $"'{ColumnValue[i]}',";
                    }
                }
                cmd += ");";
                using (SqlConnection connections = new SqlConnection(MiddleStore.ConnectPath))
                {
                    Console.WriteLine(cmd);
                    using (SqlCommand SqlCmd = new SqlCommand(cmd,connections))
                    {
                        connections.Open();
                        SqlCmd.ExecuteNonQuery();
                        connections.Close();
                        connections.Dispose();
                        SqlCmd.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Toast.Error(ex.Message);
            }

        }
    }
}
