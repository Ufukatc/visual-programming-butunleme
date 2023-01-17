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
    public partial class singUpScreen : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        MySqlCommand cmd;

        mainScreen ms = new mainScreen();

        public singUpScreen()
        {
            InitializeComponent();
        }

        string userText = "User Name";
        string passwordText = "Password";
        string mailText = "E-mail Adress";
        string confirmPasswordText = "Confirm Password";

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true ) { signUpButton.Enabled = true; }
            else { signUpButton.Enabled = false; }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ms.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (userKeyTextBox.UseSystemPasswordChar == true)
            {
                userKeyTextBox.UseSystemPasswordChar = false;
                confirmPasswordTextBox.UseSystemPasswordChar = false;
                button1.ImageIndex = 1 ;
            }
            else
            {
                userKeyTextBox.UseSystemPasswordChar = true;
                confirmPasswordTextBox.UseSystemPasswordChar = true;
                button1.ImageIndex = 0;
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            bool control=false;
            if(string.IsNullOrEmpty(userNameTextBox.Text)||userNameTextBox.Text== "User Name"||string.IsNullOrEmpty(userKeyTextBox.Text)||userKeyTextBox.Text=="Password"|| string.IsNullOrEmpty(mailTextBox.Text)||mailTextBox.Text== "E-mail Adress"|| string.IsNullOrEmpty(confirmPasswordTextBox.Text)||confirmPasswordTextBox.Text== "Confirm Password"||PhoneTextBox.Text== "(   )        ")
            {
                MessageBox.Show("Please fill all the blanks.");
            }
            else if(userKeyTextBox.Text!=confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Passwords must match,please correct it.");
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM users WHERE phone=@phone or mail=@mail";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@phone", PhoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@mail", mailTextBox.Text);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (PhoneTextBox.Text == reader["phone"].ToString())
                        {
                            MessageBox.Show("you can register once with the same phone.");
                            PhoneTextBox.Focus();
                        }
                        else if (mailTextBox.Text == reader["mail"].ToString())
                        {
                            MessageBox.Show("you can register once with the same mail.");
                            mailTextBox.Focus();
                        }
                    }
                    else { control = true; }
                    conn.Close();
                    if (control == true)
                    {
                        sql = "INSERT INTO users(name,password,phone,mail) VALUES (@name,@password,@phone,@mail)";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@name", userNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@password", userKeyTextBox.Text);
                        cmd.Parameters.AddWithValue("@phone", PhoneTextBox.Text);
                        cmd.Parameters.AddWithValue("@mail", mailTextBox.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Welcome to Eyes Optical");
                        signInScreen sis = new signInScreen();
                        sis.Show();
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("An unknown error was encountered!");
                }

            }
        }

        private void singUpScreen_Shown(object sender, EventArgs e)
        {
            mailTextBox.Focus();
        }
    }
}
