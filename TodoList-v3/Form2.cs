using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using TodoList_v3;
using Microsoft.VisualBasic.ApplicationServices;
using System.Timers;
using System.Diagnostics;

namespace TodoList_v3
{
    public partial class Form2 : Form
    {

        public Tasks task = new Tasks();
        List<Tasks> tasks = new List<Tasks>();
        TodoListLogic todoListLogic1;
        User user1;
        public Form2(User user, TodoListLogic todoListLogic)
        {
            InitializeComponent();
            todoListLogic1 = todoListLogic;
            task.userID = user.ID;
            user1 = user;
            tasks = todoListLogic.GetAllTasks(user);
            listBox.Items.Clear();
            foreach (var t in tasks)
            {
                listBox.Items.Add(t.title);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            task.description = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            task.title = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!todoListLogic1.AddNewTask(task))
            {
                MessageBox.Show("there was an error uploading the task");
                return;
            }
            textBox1.Text = "";
            textBox2.Text = "";
            tasks = todoListLogic1.GetAllTasks(user1);
            listBox.Items.Clear();
            foreach (var t in tasks)
            {
                listBox.Items.Add(t.title);
            }

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index < 0 || index >= tasks.Count) return;
            textBox3.Text = tasks[index].description;
            button2.Enabled = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false;
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                button2.Enabled = false;
                return;
            }

            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tasks[listBox.SelectedIndex].description = textBox3.Text;
            Tasks newTask = todoListLogic1.UpdateTask(tasks[listBox.SelectedIndex]);
            tasks[listBox.SelectedIndex] = newTask;
            button2.Enabled = false;
            textBox3.ReadOnly = true;
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start(); 
            todoListLogic1.AddSubOptimalInsertions();
            stopWatch.Stop(); 
            MessageBox.Show("suboptimal time: ",stopWatch.Elapsed.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            todoListLogic1.AddOptimalInsertions();
            stopWatch.Stop();
            MessageBox.Show("Optimal time: ", stopWatch.Elapsed.ToString());


        }
    }
}