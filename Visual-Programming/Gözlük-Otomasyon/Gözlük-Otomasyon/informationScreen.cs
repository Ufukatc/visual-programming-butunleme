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
    public partial class informationScreen : Form
    {
        public int productID, userID;
        string sql;
        int rec0 = 0;
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        MySqlCommand cmd;
        MySqlDataReader reader;
        public int i = 0;
        public double p1, p2, p3, p4;
        public string n1, n2, n3, n4, i1, i2, i3, i4;

        public informationScreen()
        {
            InitializeComponent();
        }

        private void informationScreen_Load(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM products WHERE id ='" + productID + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    pName.Text = reader["name"].ToString();
                    pDescription.Text = reader["description"].ToString();
                    pCategory.Text = reader["category"].ToString();
                    pPrice.Text = reader["price"].ToString();
                    if (reader["image1"].ToString() != "openFileDialog1")
                    {
                        product1.ImageLocation = reader["image1"].ToString();
                        product1.Visible = true;
                    }
                    if (reader["image2"].ToString() != "openFileDialog2")
                    {
                        pictureBox1.ImageLocation = reader["image2"].ToString();
                        pictureBox1.Visible = true;
                    }
                    if (reader["image3"].ToString() != "openFileDialog3")
                    {
                        pictureBox2.ImageLocation = reader["image3"].ToString();
                        pictureBox2.Visible = true;
                    }
                    if (reader["image4"].ToString() != "openFileDialog4")
                    {
                        pictureBox3.ImageLocation = reader["image4"].ToString();
                        pictureBox3.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Product not found!");
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            mainScreen ms = new mainScreen();
            ms.userLogin = true;
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            if (i == 0)
            {
                sql = "INSERT INTO basket (userid,productid,controller) VALUES (@userid,@productid,@controller)";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("userid", userID);
                cmd.Parameters.AddWithValue("productid", productID);
                cmd.Parameters.AddWithValue("controller", rec0);
                cmd.ExecuteNonQuery();
                conn.Close();
                i++;
                MessageBox.Show("Added to Cart");
                this.Close();
            }
            else if (i == 1)
            {
                sql = "INSERT INTO basket (userid,productid,controller) VALUES (@userid,@productid,@controller)";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("userid", userID);
                cmd.Parameters.AddWithValue("productid", productID);
                cmd.Parameters.AddWithValue("controller", rec0);
                cmd.ExecuteNonQuery();
                conn.Close();
                i++;
                MessageBox.Show("Added to Cart");
                this.Close();
            }
            else if (i == 2)
            {
                sql = "INSERT INTO basket (userid,productid,controller) VALUES (@userid,@productid,@controller)";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("userid", userID);
                cmd.Parameters.AddWithValue("productid", productID);
                cmd.Parameters.AddWithValue("controller", rec0);
                cmd.ExecuteNonQuery();
                conn.Close();
                i++;
                MessageBox.Show("Added to Cart");
                this.Close();
            }
            else if (i == 3)
            {
                sql = "INSERT INTO basket (userid,productid,controller) VALUES (@userid,@productid,@controller)";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("userid", userID);
                cmd.Parameters.AddWithValue("productid", productID);
                cmd.Parameters.AddWithValue("controller", rec0);
                cmd.ExecuteNonQuery();
                conn.Close();
                i++;
                MessageBox.Show("Added to Cart");
                this.Close();
            }
            else
            {
                MessageBox.Show("your cart is full.");
            }

        }
    }
}
