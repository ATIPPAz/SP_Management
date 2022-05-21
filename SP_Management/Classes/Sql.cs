﻿using System.Data.SqlClient;

namespace SP_Management.Classes
{
    public static class Sql
    {
        static SqlConnection _sqlConnection = null;
        static string _sqlConnectionString = @"Server=localhost\SQLSERVER;Database=ShopDB;User Id=user1;Password=mypass1;";
        public static SqlCommand _command = null;
        public static SqlDataAdapter _adapter = null;
        public static void SqlConnectionOpen() {
            _sqlConnection = new SqlConnection(_sqlConnectionString);
            _adapter = new SqlDataAdapter();
            _sqlConnection.Open();
        }
        public static void SqlConnectionClose() {
             _sqlConnection.Close();
             _sqlConnection.Dispose();
        }
        public static void RunCommand(string cmd)
        {
            _command = new SqlCommand(cmd,_sqlConnection);
        }
    }
}
