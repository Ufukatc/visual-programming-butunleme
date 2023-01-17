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
    public partial class favoritesScreen : Form
    {
        string sql;
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        MySqlCommand cmd;
        MySqlDataReader reader;
        List<int> productID = new List<int>();
        List<string> productImage = new List<string>();
        List<double> productPrice = new List<double>();
        mainScreen ms = new mainScreen();
        public int userId;
        public favoritesScreen()
        {
            InitializeComponent();
        }

        private void favoritesScreen_Load(object sender, EventArgs e)
        {
            
            sql = "SELECT * FROM favorites WHERE userid = '" + userId + "'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productID.Add(Convert.ToInt32(reader["productid"]));
            }
            conn.Close();
            bringFavorites();
            showFavorites();
        }
        private void showFavorites()
        {
            if (productImage.Count > 0)
            {
                product1.ImageLocation = productImage[0].ToString();
                price1.Text = productPrice[0].ToString() + "₺";
                product1.Visible = true;
                price1.Visible = true;
            }
            if (productImage.Count > 1)
            {
                product2.ImageLocation = productImage[1].ToString();
                price2.Text = productPrice[1].ToString() + "₺";
                product2.Visible = true;
                price2.Visible = true;
            }
            if (productImage.Count > 2)
            {
                product3.ImageLocation = productImage[2].ToString();
                price3.Text = productPrice[2].ToString() + "₺";
                product3.Visible = true;
                price3.Visible = true;
            }
            if (productImage.Count > 3)
            {
                product4.ImageLocation = productImage[3].ToString();
                price4.Text = productPrice[3].ToString() + "₺";
                product4.Visible = true;
                price4.Visible = true;
            }
            if (productImage.Count > 4)
            {
                product5.ImageLocation = productImage[4].ToString();
                price5.Text = productPrice[4].ToString() + "₺";
                product5.Visible = true;
                price5.Visible = true;
            }
            if (productImage.Count > 5)
            {
                product6.ImageLocation = productImage[5].ToString();
                price6.Text = productPrice[5].ToString() + "₺";
                product6.Visible = true;
                price6.Visible = true;
            }
            if (productImage.Count > 6)
            {
                product7.ImageLocation = productImage[6].ToString();
                price7.Text = productPrice[6].ToString() + "₺";
                product7.Visible = true;
                price7.Visible = true;
            }
            if (productImage.Count > 7)
            {
                product8.ImageLocation = productImage[7].ToString();
                price8.Text = productPrice[7].ToString() + "₺";
                product8.Visible = true;
                price8.Visible = true;
            }
            if (productImage.Count > 8)
            {
                product9.ImageLocation = productImage[8].ToString();
                price9.Text = productPrice[8].ToString() + "₺";
                product9.Visible = true;
                price9.Visible = true;
            }
            if (productImage.Count > 9)
            {
                product10.ImageLocation = productImage[9].ToString();
                price10.Text = productPrice[9].ToString() + "₺";
                product10.Visible = true;
                price10.Visible = true;
            }
        }
            private void bringFavorites()
        {
            if (productID.Count > 0)
            {
                sql = "SELECT * FROM products WHERE id='" + productID[0] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    while (reader.Read())
                    {
                        productImage.Add(reader["image1"].ToString());
                        productPrice.Add(Convert.ToDouble(reader["price"]));
                    }
                    conn.Close();
                }
                
            }
            if (productID.Count > 1)
            {
                sql = "SELECT * FROM products WHERE id='" + productID[1] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productImage.Add(reader["image1"].ToString());
                    productPrice.Add(Convert.ToDouble(reader["price"]));
                }
                conn.Close();
            }
            if (productID.Count > 2)
            {
                sql = "SELECT * FROM products WHERE id='" + productID[2] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productImage.Add(reader["image1"].ToString());
                    productPrice.Add(Convert.ToDouble(reader["price"]));
                }
                conn.Close();
            }
            if (productID.Count > 3)
            {
                sql = "SELECT * FROM products WHERE id='" + productID[3] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productImage.Add(reader["image1"].ToString());
                    productPrice.Add(Convert.ToDouble(reader["price"]));
                }
                conn.Close();
            }
            if (productID.Count > 4)
            {
                sql = "SELECT * FROM products WHERE id='" + productID[4] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productImage.Add(reader["image1"].ToString());
                    productPrice.Add(Convert.ToDouble(reader["price"]));
                }
                conn.Close();
            }
            if (productID.Count > 5)
            {
                sql = "SELECT * FROM products WHERE id='" + productID[5] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productImage.Add(reader["image1"].ToString());
                    productPrice.Add(Convert.ToDouble(reader["price"]));
                }
                conn.Close();
            }
            if (productID.Count > 6)
            {
                sql = "SELECT * FROM products WHERE id='" + productID[6] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productImage.Add(reader["image1"].ToString());
                    productPrice.Add(Convert.ToDouble(reader["price"]));
                }
                conn.Close();
            }
            if (productID.Count > 7)
            {
                sql = "SELECT * FROM products WHERE id='" + productID[7] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productImage.Add(reader["image1"].ToString());
                    productPrice.Add(Convert.ToDouble(reader["price"]));
                }
                conn.Close();
            }
            if (productID.Count > 8)
            {
                sql = "SELECT * FROM products WHERE id='" + productID[8] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productImage.Add(reader["image1"].ToString());
                    productPrice.Add(Convert.ToDouble(reader["price"]));
                }
                conn.Close();
            }
            if (productID.Count > 9)
            {
                sql = "SELECT * FROM products WHERE id='" + productID[9] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productImage.Add(reader["image1"].ToString());
                    productPrice.Add(Convert.ToDouble(reader["price"]));
                }
                conn.Close();
            }
            if (productID.Count > 10)
            {
                sql = "SELECT * FROM products WHERE id='" + productID[10] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productImage.Add(reader["image1"].ToString());
                    productPrice.Add(Convert.ToDouble(reader["price"]));
                }
                conn.Close();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ms.userLogin = true;
            this.Close();
        }
    }
}
