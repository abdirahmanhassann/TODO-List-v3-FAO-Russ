using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TodoList_v3
{
    public class TodoListLogic
    {
        public TodoListDB dbLogic;
        public TodoListLogic()
        {
            dbLogic = new TodoListDB();
        }

        public User CreateNewUser(User user)
        {
            User createUser = new User();
            DataRow duplicateCheck= dbLogic.CheckDuplicateUsernameDB(user);
            if (duplicateCheck != null)
            {
                return null;
            }
            DataRow addUser = dbLogic.CreateNewUserDB(user);
            User userLogin = Login(user);
            return userLogin;
        }
        public User Login(User user)
        {
            User loggedInUser = new User();
            DataRow row = dbLogic.LoginDB(user);
            if (row == null)
            {
                return null;
            }
            loggedInUser.ID = row.Field<int>("id");
            loggedInUser.userName = row.Field<string>("loginID");
            loggedInUser.name = row.Field<string>("name");
            return loggedInUser;
        }
        public List<Tasks> GetAllTasks (User user)
        {
           DataTable allTasks=dbLogic.GetAllTasksDB(user.ID);
            List <Tasks> tasks = new List <Tasks>();
            foreach(DataRow row in allTasks.Rows)
            {
            Tasks task = new Tasks();
                task.id = row.Field<int>("id");
                task.title = row.Field<string>("title");
                task.description = row.Field<string>("description");
                task.userID = row.Field<int>("userID");
                task.isCompleted = row.Field<bool>("isCompleted");
                task.isDeleted = row.Field<bool>("isDeleted");
                tasks.Add(task);
            }
            return tasks;
        }

        public bool AddNewTask(Tasks task)
        {
            if (dbLogic.AddNewTaskDB(task))
            {
                return true;
            }

            return false;
        }
        public Tasks UpdateTask(Tasks task)
        {
            Tasks newTask = new Tasks();
            DataRow row = dbLogic.UpdateTaskDB(task);
            newTask.title = row.Field<string>("title");
            newTask.description = row.Field<string>("description");
            newTask.userID = row.Field<int>("userID");
            newTask.isCompleted = row.Field<bool>("isCompleted");
            newTask.isDeleted = row.Field<bool>("isDeleted");
            return newTask;
        }
        public bool AddOptimalInsertions()
        {
            Tasks newTask = new Tasks();
            newTask.title = "new task";
            newTask.description = "new description";
            newTask.userID = (1);
            for(int i = 0; i < 1000; i++)
            {
                dbLogic.AddOptimalInsertionsDB(newTask);
            }
            return true;
        }
        public bool AddSubOptimalInsertions()
        {
            Tasks newTask = new Tasks();
            newTask.title = "new task";
            newTask.description = "new description";
            newTask.userID = (1);
            for (int i = 0; i < 1000; i++)
            {
                dbLogic.AddSubOptimalInsertionsDB(newTask);
            }
            return true;
        }

    }
}
