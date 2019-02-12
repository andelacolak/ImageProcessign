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

        public static bool Login( string username, byte[] hashpass )
        {
            byte[] userHash = GetUserHash(username);
            return CompareByteArrays(hashpass, userHash) ? true : throw new Exception();
        }

        public static object GetSalt( string username )
        {
            SqlConnection connection = new SqlConnection( connectionString );
            var sql = @"select [salt] from [dbo].[User] where [username]= @username";
            using ( var cmd = new SqlCommand( sql , connection ) )
            {
                connection.Open();
                cmd.Parameters.AddWithValue( "@username", username );
                return cmd.ExecuteScalar();
            }
        }

        private static bool CompareByteArrays( byte[] array1, byte[] array2 )
        {
            return !array1.Where( ( t, i ) => t != array2[i] ).Any();
        }

        private static byte[] GetUserHash(string username)
        {
            SqlConnection connection = new SqlConnection( connectionString );
            var sql = @"select hashpass from [dbo].[User] where username = @username";
            using ( var cmd = new SqlCommand( sql, connection ) )
            {
                connection.Open();
                cmd.Parameters.AddWithValue( "@username", username );
                return (byte[])cmd.ExecuteScalar();
            }
        }
    }
}