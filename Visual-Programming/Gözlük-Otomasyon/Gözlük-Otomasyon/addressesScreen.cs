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
    public partial class addressesScreen : Form
    {
        mainScreen ms = new mainScreen();
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        MySqlCommand cmd;
        MySqlDataReader reader;
        public string userName;
        int i=0;

        public addressesScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ms.userLogin = true;
            this.Close();
        }

        private void addNewAddress_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                Size = new Size(800, 317);
                addNewAddress.Location = new Point(133, 269);
                saveButton.Location = new Point(681, 269);
                Address2.Visible = true;
                richTextBox2.Visible = true;
                i++;
            }
            else if (i == 1)
            {
                Size = new Size(800, 428);
                saveButton.Location = new Point(681, 377);
                Address3.Visible = true;
                richTextBox3.Visible = true;
                addNewAddress.Visible = false;
                i++;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (i == 0)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE users SET address1=@address1,numberofaddresses=@numberofaddresses WHERE name=@name", conn);
                    cmd.Parameters.AddWithValue("@name", nameLabel.Text);
                    cmd.Parameters.AddWithValue("@address1", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@numberofaddresses", i);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("address registered");
                }
                else if (i == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE users SET address1=@address1,address2=@address2,numberofaddresses=@numberofaddresses WHERE name=@name", conn);
                    cmd.Parameters.AddWithValue("@name", nameLabel.Text);
                    cmd.Parameters.AddWithValue("@address1", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@address2", richTextBox2.Text);
                    cmd.Parameters.AddWithValue("@numberofaddresses", i);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("address registered");
                }
                else
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE users SET address1=@address1,address2=@address2,address3=@address3,numberofaddresses=@numberofaddresses WHERE name=@name", conn);
                    cmd.Parameters.AddWithValue("@name", nameLabel.Text);
                    cmd.Parameters.AddWithValue("@address1", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@address2", richTextBox2.Text);
                    cmd.Parameters.AddWithValue("@address3", richTextBox3.Text);
                    cmd.Parameters.AddWithValue("@numberofaddresses", i);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("address registered");
                }
            }
            catch
            {
                MessageBox.Show("An unknown error was encountered!");
            }
        }

        private void addressesScreen_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM users WHERE name=@name";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", userName );
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    i = Convert.ToInt32(reader["numberofaddresses"]);
                    nameLabel.Text = reader["name"].ToString();
                    if (i == 0)
                    {
                        richTextBox1.Text = reader["address1"].ToString();
                    }
                    else if (i == 1)
                    {
                        Size = new Size(800, 317);
                        addNewAddress.Location = new Point(133, 269);
                        saveButton.Location = new Point(681, 269);
                        Address2.Visible = true;
                        richTextBox2.Visible = true;
                        richTextBox1.Text = reader["address1"].ToString();
                        richTextBox2.Text = reader["address2"].ToString();
                    }
                    else if (i == 2)
                    {
                        Size = new Size(800, 428);
                        saveButton.Location = new Point(681, 377);
                        Address2.Visible = true;
                        richTextBox2.Visible = true;
                        Address3.Visible = true;
                        richTextBox3.Visible = true;
                        addNewAddress.Visible = false;
                        richTextBox1.Text = reader["address1"].ToString();
                        richTextBox2.Text = reader["address2"].ToString();
                        richTextBox3.Text = reader["address3"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Veri Tabanından adres sayısını oto 0 vermesini sağla");
                    }

                }
                else
                {
                    MessageBox.Show("User information not found."+ ms.userName);
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
