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
    public partial class basketScreen : Form
    {
        public int userId, productID;
        int i = 0, rec0 = 0, rec1 = 1;
        double p1=0, p2=0, p3=0, p4=0, total=0;
        string sql;
        List<int> productCart = new List<int>();
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        MySqlCommand cmd;
        MySqlDataReader reader;

        private void ConfirmCartButton_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked==false&&checkBox2.Checked==false&&checkBox3.Checked==false&&checkBox4.Checked==false)
            {
                MessageBox.Show("Please select the products you want to buy");
            }
            else
            {
                try
                {
                    if (checkBox1.Checked == true)
                    {
                        p1 = double.Parse(price1.Text);
                        sql = "UPDATE basket SET controller=@controller, price=@price WHERE userid = '" + userId + "' AND productid = '" + productCart[0] + "'";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("controller", rec1);
                        cmd.Parameters.AddWithValue("price", p1);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        
                    }
                    if (checkBox2.Checked == true)
                    {
                        p2 = double.Parse(price2.Text);
                        sql = "UPDATE basket SET controller=@controller, price=@price WHERE userid = '" + userId + "' AND productid = '" + productCart[1] + "'";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("controller", rec1);
                        cmd.Parameters.AddWithValue("price", p2);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        
                    }
                    if (checkBox3.Checked == true)
                    {
                        p3 = double.Parse(price3.Text);
                        sql = "UPDATE basket SET controller=@controller, price=@price WHERE userid = '" + userId + "' AND productid = '" + productCart[2] + "'";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("controller", rec1);
                        cmd.Parameters.AddWithValue("price", p3);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        
                    }
                    if (checkBox4.Checked == true)
                    {
                        p4 = double.Parse(price4.Text);
                        sql = "UPDATE basket SET controller=@controller, price=@price WHERE userid = '" + userId + "' AND productid = '" + productCart[3] + "'";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("controller", rec1);
                        cmd.Parameters.AddWithValue("price", p4);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    MessageBox.Show("Feel Happy While Using It.");
                }
                catch
                {
                    MessageBox.Show("Error");
                }
               
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                l2.Visible = true;
                p2 = double.Parse(price2.Text);
                total = p1 + p2 + p3 + p4;
                label3.Text = total.ToString() + "  ₺";
            }
            else
            {
                l2.Visible = false;
                p2 = 0;
                total = p1 + p2 + p3 + p4;
                label3.Text = total.ToString() + "  ₺";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                l3.Visible = true;
                p3 = double.Parse(price3.Text);
                total = p1 + p2 + p3 + p4;
                label3.Text = total.ToString() + "  ₺";
            }
            else
            {
                l3.Visible = false;
                p3 = 0;
                total = p1 + p2 + p3 + p4;
                label3.Text = total.ToString() + "  ₺";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                l4.Visible= true;
                p4 = double.Parse(price4.Text);
                total = p1 + p2 + p3 + p4;
                label3.Text = total.ToString() + "  ₺";
            }
            else
            {
                l4.Visible = false;
                p4 = 0;
                total = p1 + p2 + p3 + p4;
                label3.Text = total.ToString() + "  ₺";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                p1 = double.Parse(price1.Text);
                total = p1 + p2 + p3 + p4;
                label3.Text = total.ToString() + "  ₺";
                l1.Visible = true;
            }
            else
            {
                l1.Visible = false;
                p1 = 0;
                total = p1 + p2 + p3 + p4;
                label3.Text = total.ToString() + "  ₺";
            }
        }

        public basketScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            mainScreen ms = new mainScreen();
            this.Close();
            ms.Show();
        }

        private void basketScreen_Load(object sender, EventArgs e)
        {
            sql = "SELECT * FROM basket WHERE userid ='" + userId + "' AND controller= '" + rec0 +"'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productCart.Add(Convert.ToInt32(reader["productid"]));
            }
            conn.Close();
            if (i == 0 && productCart.Count>0)
            {
                sql = "SELECT * FROM products WHERE id = '" + productCart[i] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    price1.Text = reader["price"].ToString();
                    product1.ImageLocation = reader["image1"].ToString();
                    productName1.Text = reader["name"].ToString();
                }
                i++;
                conn.Close();
                price1.Visible = true;
                product1.Visible = true;
                productName1.Visible = true;
                checkBox1.Visible = true;
            }
            if ( i == 1 && productCart.Count > 1)
            {
                sql = "SELECT * FROM products WHERE id = '" + productCart[i] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    price2.Text = reader["price"].ToString();
                    product2.ImageLocation = reader["image1"].ToString();
                    productName2.Text = reader["name"].ToString();
                }
                i++;
                conn.Close();
                price2.Visible = true;
                product2.Visible = true;
                productName2.Visible = true;
                checkBox2.Visible = true;
            }
            if (i == 2 && productCart.Count > 2)
            {
                sql = "SELECT * FROM products WHERE id = '" + productCart[i] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    price3.Text = reader["price"].ToString();
                    product3.ImageLocation = reader["image1"].ToString();
                    productName3.Text = reader["name"].ToString();
                }
                i++;
                conn.Close();
                price3.Visible = true;
                product3.Visible = true;
                productName3.Visible = true;
                checkBox3.Visible = true;
            }
            if(i == 3 && productCart.Count > 3)
            {
                sql = "SELECT * FROM products WHERE id = '" + productCart[i] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    price4.Text = reader["price"].ToString();
                    product4.ImageLocation = reader["image1"].ToString();
                    productName4.Text = reader["name"].ToString();
                }
                i++;
                conn.Close();
                price4.Visible = true;
                product4.Visible = true;
                productName4.Visible = true;
                checkBox4.Visible = true;
            }
        }

        private void FavoritesButton_Click(object sender, EventArgs e)
        {
            favoritesScreen fs = new favoritesScreen();
            fs.userId = userId;
            fs.ShowDialog();
        }
    }
}
