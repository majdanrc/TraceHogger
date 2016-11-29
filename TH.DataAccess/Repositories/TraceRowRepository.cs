using System;
using System.Collections.Generic;
using System.Diagnostics;
using TH.DataAccess.Blocks;

namespace TH.DataAccess.Repositories
{
    public class TraceRowRepository
    {
        //private const string QuerySql = @"select * from {0} where TextData not like 'exec sp_reset_connection' and LoginName is not NULL and LoginName<>'NT SERVICE\ReportServer'";
        private const string QuerySql = @"select * from {0} where TextData not like 'exec sp_reset_connection'";

        public static List<TraceRow> GetRows(string tableName)
        {
            var result = new List<TraceRow>();

            var query = string.Format(QuerySql, tableName);

            using (var reader = DbAccess.GetReaderSimple(query))
            {
                try
                {
                    while (reader.Read())
                    {
                        var row = new TraceRow
                        {
                            RowNumber = !reader.IsDBNull(reader.GetOrdinal("RowNumber"))
                                ? reader.GetInt32(reader.GetOrdinal("RowNumber"))
                                : -1,
                            TextData = !reader.IsDBNull(reader.GetOrdinal("TextData"))
                                ? reader.GetString(reader.GetOrdinal("TextData"))
                                : string.Empty,
                            Duration = !reader.IsDBNull(reader.GetOrdinal("Duration"))
                                ? reader.GetInt64(reader.GetOrdinal("Duration"))
                                : -1,
                            StartTime = !reader.IsDBNull(reader.GetOrdinal("StartTime"))
                                ? reader.GetDateTime(reader.GetOrdinal("StartTime"))
                                : DateTime.MinValue,
                            EndTime = !reader.IsDBNull(reader.GetOrdinal("EndTime"))
                                ? reader.GetDateTime(reader.GetOrdinal("EndTime"))
                                : DateTime.MaxValue
                        };

                        result.Add(row);
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
