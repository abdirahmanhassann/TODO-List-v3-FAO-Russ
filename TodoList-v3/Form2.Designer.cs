using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace TodoList_v3

{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            listBox = new ListBox();
            textBox3 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(221, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(169, 31);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(171, 30);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 1;
            label1.Text = "Title";
            // 
            // textBox2
            // 
            textBox2.AllowDrop = true;
            textBox2.Location = new Point(561, 24);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(227, 89);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(415, 24);
            label2.Name = "label2";
            label2.Size = new Size(140, 25);
            label2.TabIndex = 3;
            label2.Text = "Task Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 30);
            label3.Name = "label3";
            label3.Size = new Size(137, 25);
            label3.TabIndex = 4;
            label3.Text = "Create new Task";
            // 
            // button1
            // 
            button1.Location = new Point(21, 58);
            button1.Name = "button1";
            button1.Size = new Size(369, 34);
            button1.TabIndex = 5;
            button1.Text = "save new task";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 25;
            listBox.Location = new Point(36, 145);
            listBox.Name = "listBox";
            listBox.Size = new Size(289, 129);
            listBox.TabIndex = 6;
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
            // 
            // textBox3
            // 
            textBox3.AllowDrop = true;
            textBox3.Location = new Point(389, 141);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(406, 185);
            textBox3.TabIndex = 7;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(389, 331);
            button2.Name = "button2";
            button2.Size = new Size(404, 68);
            button2.TabIndex = 8;
            button2.Text = "Save Changes";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(26, 314);
            button3.Name = "button3";
            button3.Size = new Size(137, 68);
            button3.TabIndex = 9;
            button3.Text = "Suboptimal insertion";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(184, 314);
            button4.Name = "button4";
            button4.Size = new Size(141, 68);
            button4.TabIndex = 10;
            button4.Text = "Optimised insertion";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(listBox);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Button button1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ListBox listBox;
        private TextBox textBox3;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}