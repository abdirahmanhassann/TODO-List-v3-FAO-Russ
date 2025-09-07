using static TodoList_v3.Models;
namespace TodoList_v3
{
    public partial class Form1 : Form
    {
        //private string signInUsername = "";
        //private string signInPassword = "";
        //private string SignUpUserName = "";
        //private string SignUpPassword = "";
        //private string SignUpRePassword = "";
        public User Signin = new User();
        public User Signup = new User();
        TodoListLogic TodoListLogic;
        public Form1()
        {
            InitializeComponent();
            TodoListLogic = new TodoListLogic();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Signin.userName = textBox1.Text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Signin.password = textBox2.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Signup.userName = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Signup.password = textBox4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User isSignedIn = TodoListLogic.Login(Signin);
            if (isSignedIn == null || string.IsNullOrEmpty(Signin.userName))
            {
                MessageBox.Show("Wrong username or password");
                return;
            }
            Form2 form2 = new Form2(isSignedIn,TodoListLogic);
            form2.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Signup.name = textBox6.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Signup.password != Signup.rePassword)
            {
                MessageBox.Show("Passwords don't match");
                return;
            }
            User isSignedUp = TodoListLogic.CreateNewUser(Signup);
            if (isSignedUp == null || string.IsNullOrEmpty(isSignedUp.userName))
            {
                return;
            }
            Form2 form2 = new Form2(isSignedUp,TodoListLogic);
            form2.Show();
            this.Hide();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Signup.rePassword=textBox5.Text;
        }
    }
}