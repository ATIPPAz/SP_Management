using System.Data.SqlClient;

namespace SP_Management.Classes
{
    public class Sql
    {
        SqlConnection _sqlConnection = null;
        public string _sqlConnectionString = @"Server=localhost\SQLSERVER;Database=ShopDB;User Id=user1;Password=mypass1;";
        public  SqlCommand _command = null;
        public  SqlDataAdapter _adapter = null;
        public  void SqlConnectionOpen() {
            _sqlConnection = new SqlConnection(_sqlConnectionString);
            _adapter = new SqlDataAdapter();
            _sqlConnection.Open();
        }
        public  void SqlConnectionClose() {
             _sqlConnection.Close();
             _sqlConnection.Dispose();
        }
        public  void destroyCmd()
        {
            _command.Dispose();
        }
        public  void RunCommand(string cmd)
        {
            _command = new SqlCommand(cmd,_sqlConnection);
        }
    }
}
