using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TodoList_v3
{
    public class DatabaseConnectivity
    {
        public DatabaseConnectivity(string dbPath)
        {
            path = dbPath;
        }
        public string path;

        public SqlParameter GenerateInputInteger(string paramName, int val)

        {

            return new SqlParameter(paramName, SqlDbType.Int, 0)

            {

                Value = val

            };

        }
        public SqlParameter GenerateInputString(string paramName, string val)
        {
            return new SqlParameter(paramName, SqlDbType.NVarChar, 50)
            {
                Value = val
            };
        }

        public SqlParameter GenerateInputBit(string paramName, bool val)
        {
            return new SqlParameter(paramName, SqlDbType.Bit, 0)
            {
                Value = val
            };
        }
        public DataTable ExecuteStoredProcedureAsDataTable(string spName, SqlParameter[]? sqlParams)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(path))
            {
                using (SqlCommand command = new SqlCommand(spName, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (sqlParams != null)
                    {
                        command.Parameters.AddRange(sqlParams);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataRow ExecuteStoredProcedureAsDataRow (string spName, SqlParameter[]? sqlParams)
        {
            DataTable dt = ExecuteStoredProcedureAsDataTable(spName, sqlParams);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }
        public object ExecuteStoredProcedureNoReturn(string spName, SqlParameter[]? sqlParams)
        {
            try
            {

            using (SqlConnection conn = new SqlConnection(path))
            {
                using (SqlCommand command = new SqlCommand(spName, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (sqlParams != null)
                    {
                        command.Parameters.AddRange(sqlParams);
                    }
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public DataTable ExecuteRawSQLAsDataTable (string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn= new SqlConnection(path))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public DataRow ExecuteRawSQLAsDataRow(string query)
        {
            DataTable dt = ExecuteRawSQLAsDataTable(query);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }
        public void ExecuteRawSQLNoReturn(string query)
        {
            using (SqlConnection conn = new SqlConnection(path))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.CommandType = CommandType.Text;
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
