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
    public partial class passwordResetScreen : Form
    {
        mainScreen ms = new mainScreen();
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        MySqlCommand cmd;
        MySqlDataReader reader;

        public passwordResetScreen()
        {
            InitializeComponent();
        }

        string userText = "User Name";
        string passwordText = "New Password";
        string mailText = "E-mail Adress";
        string confirmPasswordText = "Confirm New Password";

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ms.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { signUpButton.Enabled = true; }
            else { signUpButton.Enabled = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userKeyTextBox.UseSystemPasswordChar == true) 
            { 
                userKeyTextBox.UseSystemPasswordChar = false;
                confirmPasswordTextBox.UseSystemPasswordChar = false;
                button1.ImageIndex = 1;
            }
            else 
            { 
                userKeyTextBox.UseSystemPasswordChar = true;
                confirmPasswordTextBox.UseSystemPasswordChar = true;
                button1.ImageIndex = 0;
            }
        }

        private void mailTextBox_Enter(object sender, EventArgs e)
        {
            if (mailTextBox.Text == mailText)
            {
                mailTextBox.Text = "";
            }
        }

        private void mailTextBox_Leave(object sender, EventArgs e)
        {
            if (mailTextBox.Text == "")
            {
                mailTextBox.Text = mailText;
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

        private void confirmPasswordTextBox_Enter(object sender, EventArgs e)
        {
            if (confirmPasswordTextBox.Text == confirmPasswordText)
            {
                confirmPasswordTextBox.Text = "";
            }
        }

        private void confirmPasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (confirmPasswordTextBox.Text == "")
            {
                confirmPasswordTextBox.Text = confirmPasswordText;
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(userNameTextBox.Text) || userNameTextBox.Text == "User Name" || string.IsNullOrEmpty(userKeyTextBox.Text) || userKeyTextBox.Text == "Password" || string.IsNullOrEmpty(mailTextBox.Text) || mailTextBox.Text == "E-mail Adress" || string.IsNullOrEmpty(confirmPasswordTextBox.Text) || confirmPasswordTextBox.Text == "Confirm Password" || phoneTextBox.Text == "(   )        ")
                {
                    MessageBox.Show("Please fill all the blanks.");
                }
                else
                {
                    conn.Open();
                    string sql = "SELECT * FROM users WHERE name=@name";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", userNameTextBox.Text);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (mailTextBox.Text == reader["mail"].ToString() && userNameTextBox.Text == reader["name"].ToString() && phoneTextBox.Text == reader["phone"].ToString())
                        {
                            if (userKeyTextBox.Text == confirmPasswordTextBox.Text)
                            {
                                conn.Close();
                                sql = "UPDATE users SET name=@name,password=@password WHERE name=@name";
                                cmd = new MySqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@name", userNameTextBox.Text);
                                cmd.Parameters.AddWithValue("@password", userKeyTextBox.Text);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Password change successful!");
                                signInScreen sis = new signInScreen();
                                sis.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Passwords must be the same!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Information did not match!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No such user found.");
                    }
                    conn.Close();
                }
            }
            catch
            {
                MessageBox.Show("An unknown error was encountered!");
            }
        }
    }
}
