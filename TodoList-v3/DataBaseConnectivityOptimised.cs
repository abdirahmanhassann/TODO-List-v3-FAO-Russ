using Microsoft.
    Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TodoList_v3
{
    public class DatabaseConnectivityOptimised
    {
        public string path;
        public SqlConnection _conn;
        public DatabaseConnectivityOptimised(string dbPath)
        {
            path = dbPath;
            using ( _conn = new SqlConnection(path))
            {
                path = dbPath;
                _conn.Open();
            }
        }
        public object ExecuteStoredProcedureNoReturn(string spName, SqlParameter[]? sqlParams)
        {

            try {
                using (SqlCommand command = new SqlCommand(spName, _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (sqlParams != null)
                    {
                        command.Parameters.AddRange(sqlParams);
                    }
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception e)
            {
                return e;
            }
            }
        
    }
}
