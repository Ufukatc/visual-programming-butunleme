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
    public partial class ordersScreen : Form
    {
        string sql;
        public int userId;
        int rec0 = 1, i=0;
        List<int> productCart = new List<int>();
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        MySqlCommand cmd;
        MySqlDataReader reader;
        public ordersScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ordersScreen_Load(object sender, EventArgs e)
        {
            sql = "SELECT * FROM basket WHERE userid ='" + userId + "' AND controller= '" + rec0 + "'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productCart.Add(Convert.ToInt32(reader["productid"]));
            }
            conn.Close();
            if (i == 0 && productCart.Count > 0)
            {
                sql = "SELECT * FROM products WHERE id = '" + productCart[i] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    price1.Text = reader["price"].ToString();
                    product1.ImageLocation = reader["image1"].ToString();
                    p1.Text = reader["name"].ToString();
                }
                i++;
                conn.Close();
                price1.Visible = true;
                product1.Visible = true;
                p1.Visible = true;
                l1.Visible = true;
            }
            if (i == 1 && productCart.Count > 1)
            {
                sql = "SELECT * FROM products WHERE id = '" + productCart[i] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    price2.Text = reader["price"].ToString();
                    product2.ImageLocation = reader["image1"].ToString();
                    p2.Text = reader["name"].ToString();
                }
                i++;
                conn.Close();
                price2.Visible = true;
                product2.Visible = true;
                p2.Visible = true;
                l2.Visible = true;
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
                    p3.Text = reader["name"].ToString();
                }
                i++;
                conn.Close();
                price3.Visible = true;
                product3.Visible = true;
                p3.Visible = true;
                l3.Visible = true;
            }
            if (i == 3 && productCart.Count > 3)
            {
                sql = "SELECT * FROM products WHERE id = '" + productCart[i] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    price4.Text = reader["price"].ToString();
                    product4.ImageLocation = reader["image1"].ToString();
                    p4.Text = reader["name"].ToString();
                }
                i++;
                conn.Close();
                price4.Visible = true;
                product4.Visible = true;
                p4.Visible = true;
                l4.Visible = true;
            }
            if (i == 4 && productCart.Count > 4)
            {
                sql = "SELECT * FROM products WHERE id = '" + productCart[i] + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    price5.Text = reader["price"].ToString();
                    product5.ImageLocation = reader["image1"].ToString();
                    p5.Text = reader["name"].ToString();
                }
                i++;
                conn.Close();
                price5.Visible = true;
                product5.Visible = true;
                p5.Visible = true;
                l5.Visible = true;
            }
        }
    }
}
