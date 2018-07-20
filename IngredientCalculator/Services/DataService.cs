using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IngredientCalculator.Services
{
    public static class DataService
    {
        private static string SetConnectionString()
        {
            //return ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
            return @"Data Source=.;Initial Catalog=IngredientCalculator;Integrated Security=True";
        }

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(SetConnectionString());
        }

        public static SqlCommand CreateSqlStoredProcCommand(SqlConnection connection, string storedProc)
        {
            return new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = storedProc,
                Connection = connection
            };
        }

        //public static void CreateUpdate(SqlCommand sqlCommand)
        //{
        //    using (var conn = CreateConnection())
        //    {
        //        sqlCommand.Connection = conn;

        //        conn.Open();
        //        sqlCommand.ExecuteNonQuery();
        //    }
        //}

        public static void ClearAllData()
        {
            using (var conn = CreateConnection())
            {
                var command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,

                    CommandText = "sp_ClearAllData",
                    Connection = conn,
                };

                conn.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}