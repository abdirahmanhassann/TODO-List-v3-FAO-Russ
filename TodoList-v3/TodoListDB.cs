using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TodoList_v3.Models;
using static TodoList_v3.DatabaseConnectivity;
using Microsoft.Data.SqlClient;
using System.Data;
namespace TodoList_v3
{
    public class TodoListDB
    {
        public DatabaseConnectivity db;
        public DatabaseConnectivityOptimised dbOptimal;
        public TodoListDB()
        {
            string path = "Data Source=LAPTOP-KFNM01SG\\SQLEXPRESS;Initial Catalog=Project2;"
            + "Integrated Security=True;TrustServerCertificate=True;";
            db = new DatabaseConnectivity(path);
            dbOptimal = new DatabaseConnectivityOptimised(path);
        }

        public DataRow CheckDuplicateUsernameDB(User user)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(db.GenerateInputString("@loginID", user.userName));
            DataRow duplicateCheck = db.ExecuteStoredProcedureAsDataRow("CheckDuplicateUserName", sqlParams.ToArray());
            return duplicateCheck;
        }
        public DataRow CreateNewUserDB(User user)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(db.GenerateInputString("@loginID", user.userName));
            sqlParams.Add(db.GenerateInputString("@password", user.password));
            sqlParams.Add(db.GenerateInputString("@name", user.name));
            DataRow created = db.ExecuteStoredProcedureAsDataRow("CreateNewUser",sqlParams.ToArray());
            return created;
        }
        public DataRow LoginDB(User user)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(db.GenerateInputString("@loginID", user.userName));
            sqlParams.Add(db.GenerateInputString("@password", user.password));
            DataRow loggedIn = db.ExecuteStoredProcedureAsDataRow("Login", sqlParams.ToArray());
            return loggedIn;
        }
        public DataTable GetAllTasksDB(int userID)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(db.GenerateInputInteger("@loginID", userID));
            DataTable tasks = db.ExecuteStoredProcedureAsDataTable("GetAllTasks", sqlParams.ToArray());
            return tasks;
        }
        public bool AddNewTaskDB(Tasks task)
        {
            try
            {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(db.GenerateInputString("@title", task.title));
            sqlParams.Add(db.GenerateInputString("@description", task.description));
            sqlParams.Add(db.GenerateInputInteger("@loginID", task.userID));
            DataRow added = db.ExecuteStoredProcedureAsDataRow("AddNewTask", sqlParams.ToArray());
            return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public DataRow UpdateTaskDB(Tasks task)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(db.GenerateInputInteger("@id", task.id));
            sqlParams.Add(db.GenerateInputString("@title", task.title));
            sqlParams.Add(db.GenerateInputString("@description", task.description));
            sqlParams.Add(db.GenerateInputBit("@isCompleted", task.isCompleted));
            sqlParams.Add(db.GenerateInputBit("@isDeleted", task.isDeleted));
            DataRow updated = db.ExecuteStoredProcedureAsDataRow("UpdateTask", sqlParams.ToArray());
            return updated;
        }
        public object AddOptimalInsertionsDB(Tasks task)
        {
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(db.GenerateInputString("@title", task.title));
                sqlParams.Add(db.GenerateInputString("@description", task.description));
                sqlParams.Add(db.GenerateInputInteger("@loginID", task.userID));
                var added = dbOptimal.ExecuteStoredProcedureNoReturn("AddNewTask", sqlParams.ToArray());
                return added;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public object AddSubOptimalInsertionsDB(Tasks task)
        {
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(db.GenerateInputString("@title", task.title));
                sqlParams.Add(db.GenerateInputString("@description", task.description));
                sqlParams.Add(db.GenerateInputInteger("@loginID", task.userID));
                var added = db.ExecuteStoredProcedureNoReturn("AddNewTask", sqlParams.ToArray());
                return added;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
