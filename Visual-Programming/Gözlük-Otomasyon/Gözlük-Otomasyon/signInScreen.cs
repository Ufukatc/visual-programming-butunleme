using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gözlük_Otomasyon
{
    public partial class signInScreen : Form
    {
        mainScreen ms = new mainScreen();
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        MySqlCommand cmd;
        MySqlDataReader reader;
        string admin = "root";

        public signInScreen()
        {
            InitializeComponent();
        }

        string userText = "User Name";
        string passwordText = "Password";

        private void button2_Click(object sender, EventArgs e)
        {
            ms.Show();
            this.Close();
        }

        private void userNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void userNameTextBox_Enter(object sender, EventArgs e)
        {
            if (userNameTextBox.Text == userText)
            {
                userNameTextBox.Text = "";
            }
        }

        private void userNameTextBox_Leave(object sender, EventArgs e)
        {
            if (userNameTextBox.Text == "")
            {
                userNameTextBox.Text = userText;
            }
        }

        private void userKeyTextBox_Enter(object sender, EventArgs e)
        {
            if (userKeyTextBox.Text == passwordText)
            {
                userKeyTextBox.Text = "";
            }
        }

        private void userKeyTextBox_Leave(object sender, EventArgs e)
        {
            if (userKeyTextBox.Text == "")
            {
                userKeyTextBox.Text = passwordText;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { signInButton.Enabled = true; }
            else { signInButton.Enabled = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userKeyTextBox.UseSystemPasswordChar == true) 
            { 
                userKeyTextBox.UseSystemPasswordChar = false;
                button1.ImageIndex = 1;
            }
            else 
            { 
                userKeyTextBox.UseSystemPasswordChar=true;
                button1.ImageIndex = 0;
            }
        }

        private void passwordResetLabel_Click(object sender, EventArgs e)
        {
            passwordResetScreen prs = new passwordResetScreen();
            prs.ShowDialog();
            this.Close();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM users WHERE name=@name";
                cmd = new MySqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("@name", userNameTextBox.Text);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if( admin == reader["password"].ToString())
                    {
                        ms.adminLogin = true;
                        ms.userLogin = false;
                        ms.Show();
                        this.Close();
                    }
                    else if (userKeyTextBox.Text == reader["password"].ToString())
                    {
                        ms.userLogin = true;
                        ms.adminLogin = false;
                        ms.userId = Convert.ToInt32(reader["id"]);
                        ms.userName = reader["name"].ToString();
                        ms.Show();
                        
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password is wrong.");
                    }
                }
                else
                {
                    MessageBox.Show("No such user found.");
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("An unknown error was encountered!");
            }
        }
    }
}
