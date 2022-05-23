using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Management.Classes.CRUD.Postitions
{
    public class GetAll
    {
        public DataTable GetPosition()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(MiddleStore.ConnectPath))
            {
                string cmd;
                    cmd = "select * from dbo.Positions p order by p.PositionID Asc";
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
}
