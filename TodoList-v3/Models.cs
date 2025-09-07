using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList_v3
{
    internal class Models
    {
    }

    public class User
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string rePassword { get; set; }
    }
    public class Tasks
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool isCompleted { get; set; }
        public bool isDeleted { get; set; }
        public int userID { get; set; }
    }

}
