using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TH.DataAccess.Repositories
{
    public class TableRepository
    {
        private const string QuerySql = @"SELECT TABLE_NAME FROM {0}.INFORMATION_SCHEMA.Tables WHERE TABLE_TYPE = 'BASE TABLE'";

        public static List<string> GetTables(string dbName)
        {
            var result = new List<string>();

            var query = string.Format(QuerySql, dbName);

            using (var reader = DbAccess.GetReaderSimple(query))
            {
                try
                {
                    while (reader.Read())
                    {
                        var tableName = !reader.IsDBNull(reader.GetOrdinal("TABLE_NAME"))
                            ? reader.GetString(reader.GetOrdinal("TABLE_NAME"))
                            : string.Empty;

                        result.Add(tableName);
                    }
                }
                catch (Exception exc)
                {
                    Debug.WriteLine(exc.Message);
                }
            }

            return result;
        }
    }
}
