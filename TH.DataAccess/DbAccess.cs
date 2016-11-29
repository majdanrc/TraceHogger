using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace TH.DataAccess
{
    public class DbAccess
    {
        private const string ConnectionString = "Data Source=WS-PF01CX3R;Initial Catalog=MordorEV;Integrated Security=True;Pooling=False";

        public static SqlDataReader GetReaderSimple(string query, string connString = null)
        {
            return GetReader(query, null, CommandType.Text, connString);
        }

        public static SqlDataReader GetReaderWithProcedure(string query, ArrayList parameters, string connString = null)
        {
            return GetReader(query, parameters, CommandType.StoredProcedure, connString);
        }

        private static SqlDataReader GetReader(string query, ArrayList parameters, CommandType commandType, string connString = null)
        {
            var connection = new SqlConnection(string.IsNullOrWhiteSpace(connString) ? ConnectionString : connString);

            var command = new SqlCommand(query, connection)
            {
                CommandTimeout = 120,
                CommandType = commandType
            };

            if (parameters != null && parameters.Count > 0)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return reader;
        }
    }
}
