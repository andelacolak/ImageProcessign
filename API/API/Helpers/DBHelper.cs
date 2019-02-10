using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Helpers
{
    public static class DBHelper
    {
        private static string connectionString { get; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Andela\Desktop\Anđela\pmf\PROMA\API\API\App_Data\AuthDB.mdf;Integrated Security=True;Connect Timeout=30";

        public static int Register(string username, byte[] salt, byte[] hashpass)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sql = @"insert into [dbo].[User] ([username], [salt], [hashpass]) values(@username, @salt, @hashpass)";
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@salt", salt);
                    cmd.Parameters.AddWithValue("@hashpass", hashpass);
                    return  cmd.ExecuteNonQuery();
                }
            }
        }
    }
}