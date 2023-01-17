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
    public partial class accountInfo : Form
    {
        mainScreen ms = new mainScreen();
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        MySqlCommand cmd;
        MySqlDataReader reader;
        public string userName;
        public accountInfo()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ms.userLogin = true;
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE users SET id=@id,personname=@personname,personsurname=@personsurname,phone=@phone,mail=@mail WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("id", userIdTextBox.Text);
                cmd.Parameters.AddWithValue("@personname", nameTextBox.Text);
                cmd.Parameters.AddWithValue("@personsurname", surnameTextBox.Text);
                cmd.Parameters.AddWithValue("@phone", PhoneTextBox.Text);
                cmd.Parameters.AddWithValue("@mail", MailTextBox.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("User İnformation Updated.");
            }
            catch
            {
                MessageBox.Show("An unknown error was encountered!");
            }
        }

        private void accountInfo_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM users WHERE name=@name";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", userName);
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userIdTextBox.Text = reader["id"].ToString();
                    nameTextBox.Text = reader["personname"].ToString();
                    surnameTextBox.Text = reader["personsurname"].ToString();
                    PhoneTextBox.Text = reader["phone"].ToString();
                    MailTextBox.Text = reader["mail"].ToString();
                }
                else
                {
                    MessageBox.Show("User information not found.");
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
