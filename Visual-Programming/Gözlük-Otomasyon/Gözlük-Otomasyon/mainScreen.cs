using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gözlük_Otomasyon
{
    public partial class mainScreen : Form
    {
        bool menuVisibleAudit = false, adminMenu = false, favoritesAudit1, favoritesAudit2, favoritesAudit3, favoritesAudit4, favoritesAudit5, favoritesAudit6, favoritesAudit7, favoritesAudit8, favoritesAudit9, favoritesAudit10, favoritesAudit11, favoritesAudit12;
        public bool userLogin = false, adminLogin = false;
        public string userName;
        public int userId;
        int p1ID, p2ID, p3ID, p4ID, p5ID, p6ID, p7ID, p8ID, p9ID, p10ID, p11ID, p12ID;
        int fav = 0;
        int productID, productController;
        string sql;
        List<string> bestseller = new List<string>();
        List<int> bestsellerID = new List<int>();
        List<double> bestsellerPrice = new List<double>();
        List<string> women = new List<string>();
        List<int> womenID = new List<int>();
        List<double> womenPrice = new List<double>();
        List<string> men = new List<string>();
        List<int> menID = new List<int>();
        List<double> menPrice = new List<double>();
        List<string> kid = new List<string>();
        List<int> kidID = new List<int>();
        List<double> kidPrice = new List<double>();
        List<string> sunglasses = new List<string>();
        List<int> sunglassesID = new List<int>();
        List<double> sunglassesPrice = new List<double>();
        List<string> blp = new List<string>();
        List<int> blpID = new List<int>();
        List<double> blpPrice = new List<double>();
        List<string> lens = new List<string>();
        List<int> lensID = new List<int>();
        List<double> lensPrice = new List<double>();
        List<string> newSeason = new List<string>();
        List<int> newSeasonID = new List<int>();
        List<double> newSeasonPrice = new List<double>();
        List<string> accessory = new List<string>();
        List<int> accessoryID = new List<int>();
        List<double> accessoryPrice = new List<double>();
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        MySqlCommand cmd;
        MySqlDataReader reader;
        informationScreen infoScreen = new informationScreen();

        public mainScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            signInScreen sis = new signInScreen();
            sis.Show();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            singUpScreen su = new singUpScreen();
            su.Show();
            this.Hide();
        }

        private void minimazedButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ColorChange()
        {
            bestsellerButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            womenButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            menButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            kidButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            sunglassesButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            blueLPButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            lensButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            newSeasonButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            accessoryButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
        }

        private void bestsellerButton_Click(object sender, EventArgs e)
        {
            ColorChange();
            bestsellerButton.BackColor = System.Drawing.Color.FromArgb(228, 229, 116);
            productVisible();
            productController = 1;
            listOfPricesBestseller(bestsellerPrice);
            listOfProductsBestseller();
        }

        private void womenButton_Click(object sender, EventArgs e)
        {
            ColorChange();
            womenButton.BackColor = System.Drawing.Color.FromArgb(228, 229, 116);
            productVisible();
            productController = 2;
            listOfPricesWomen(womenPrice);
            listOfProductsWomen();
        }

        private void menButton_Click(object sender, EventArgs e)
        {
            ColorChange();
            menButton.BackColor = System.Drawing.Color.FromArgb(228, 229, 116);
            productVisible();
            productController = 3;
            listOfPricesMen(menPrice);
            listOfProductsMen();
        }

        private void kidButton_Click(object sender, EventArgs e)
        {
            ColorChange();
            kidButton.BackColor = System.Drawing.Color.FromArgb(228, 229, 116);
            productVisible();
            productController = 4;
            listOfPricesKid(kidPrice);
            listOfProductsKid();
        }

        private void sunglassesButton_Click(object sender, EventArgs e)
        {
            ColorChange();
            sunglassesButton.BackColor = System.Drawing.Color.FromArgb(228, 229, 116);
            productVisible();
            productController = 5;
            listOfPricesSunglasses(sunglassesPrice);
            listOfProductsSunglasses();
        }

        private void blueLPButton_Click(object sender, EventArgs e)
        {
            ColorChange();
            blueLPButton.BackColor = System.Drawing.Color.FromArgb(228, 229, 116);
            productVisible();
            productController = 6;
            listOfPricesBLP(blpPrice);
            listOfProductsBLP();
        }

        private void lensButton_Click(object sender, EventArgs e)
        {
            ColorChange();
            lensButton.BackColor = System.Drawing.Color.FromArgb(228, 229, 116);
            productVisible();
            productController = 7;
            listOfPricesLens(lensPrice);
            listOfProductsLens();
        }

        private void newSeasonButton_Click(object sender, EventArgs e)
        {
            ColorChange();
            newSeasonButton.BackColor = System.Drawing.Color.FromArgb(228, 229, 116);
            productVisible();
            productController = 8;
            listOfPricesNewSeason(newSeasonPrice);
            listOfProductsNewSeason();
        }

        private void accessoryButton_Click(object sender, EventArgs e)
        {
            ColorChange();
            accessoryButton.BackColor = System.Drawing.Color.FromArgb(228, 229, 116);
            productVisible();
            productController = 9;
            listOfPricesAccessory(accessoryPrice);
            listOfProductsAccessory();
        }

        private void AccountButton_MouseEnter(object sender, EventArgs e)
        {
            AccountButton.BackColor = System.Drawing.Color.FromArgb(0, 110, 95);
        }

        private void AccountButton_Click(object sender, EventArgs e)
        {
            if (menuVisibleAudit == false)
            {
                AccountInfo.Visible = true;
                Orders.Visible = true;
                Favorites.Visible = true;
                Coupons.Visible = true;
                Addresses.Visible = true;
                WhereAreWe.Visible = true;
                AboutUs.Visible = true;
                FAQ.Visible = true;
                AccountSignOut.Visible = true;
                menuVisibleAudit = true;
            }
            else 
            {
                AccountInfo.Visible = false;
                Orders.Visible = false;
                Favorites.Visible = false;
                Coupons.Visible = false;
                Addresses.Visible = false;
                WhereAreWe.Visible = false;
                AboutUs.Visible = false;
                FAQ.Visible = false;
                AccountSignOut.Visible = false;
                menuVisibleAudit = false;
            }
        }

        private void menuVisibleChange()
        {
            AccountInfo.Visible = false;
            Orders.Visible = false;
            Favorites.Visible = false;
            Coupons.Visible = false;
            Addresses.Visible = false;
            WhereAreWe.Visible = false;
            AboutUs.Visible = false;
            FAQ.Visible = false;
            AccountSignOut.Visible = false;
            menuVisibleAudit = false;
        }

        private void AccountSignOut_Click(object sender, EventArgs e)
        {
            menuVisibleChange();
            userLogin = false;
            Application.Restart();
        }

        private void Basket_Click(object sender, EventArgs e)
        {
            basketScreen bs = new basketScreen();
            bs.userId = userId;
            bs.ShowDialog();
        }

        public void favoritesEnabledTrue()
        {
            fav1Button.Enabled = true;
            fav2Button.Enabled = true;
            fav3Button.Enabled = true;
            fav4Button.Enabled = true;
            fav5Button.Enabled = true;
            fav6Button.Enabled = true;
            fav7Button.Enabled = true;
            fav8Button.Enabled = true;
            fav9Button.Enabled = true;
            fav10Button.Enabled = true;
            fav11Button.Enabled = true;
            fav12Button.Enabled = true;
        }

        public void favoritesEnabledFalse()
        {
            fav1Button.Enabled = false;
            fav2Button.Enabled = false;
            fav3Button.Enabled = false;
            fav4Button.Enabled = false;
            fav5Button.Enabled = false;
            fav6Button.Enabled = false;
            fav7Button.Enabled = false;
            fav8Button.Enabled = false;
            fav9Button.Enabled = false;
            fav10Button.Enabled = false;
            fav11Button.Enabled = false;
            fav12Button.Enabled = false;
        }

        private void fav1Button_Click(object sender, EventArgs e)
        {
            productID = 0;
            fav = 1;
            if (favoritesAudit1==false)
            {
                if(productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else 
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void mainScreen_Load(object sender, EventArgs e)
        {
            productController = 1;
            if (userLogin == true)
            {
                AccountButton.Visible = true;
                Basket.Visible = true;
                SignInButton.Visible = false;
                SignUpButton.Visible = false;
                favoritesEnabledTrue();
            }
            else if (adminLogin == true)
            {
                adminEditButton.Visible = true;
                AccountButton.Visible = false;
                Basket.Visible = false;
                SignInButton.Visible = false;
                SignUpButton.Visible = false;
                favoritesEnabledFalse();
            }
            else
            {
                AccountButton.Visible = false;
                Basket.Visible = false;
                SignInButton.Visible = true;
                SignUpButton.Visible = true;
                favoritesEnabledFalse();
            }
            sql = "SELECT * FROM products WHERE category = 'bestseller'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                bestseller.Add(reader["image1"].ToString());
                bestsellerID.Add(Convert.ToInt32(reader["id"]));
                bestsellerPrice.Add(Convert.ToDouble(reader["price"]));
            }
            conn.Close();
            listOfPricesBestseller(bestsellerPrice);
            listOfProductsBestseller();
            sql = "SELECT * FROM products WHERE category = 'women'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                women.Add(reader["image1"].ToString());
                womenID.Add(Convert.ToInt32(reader["id"]));
                womenPrice.Add(Convert.ToDouble(reader["price"]));
            }
            conn.Close();
            sql = "SELECT * FROM products WHERE category = 'men'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                men.Add(reader["image1"].ToString());
                menID.Add(Convert.ToInt32(reader["id"]));
                menPrice.Add(Convert.ToDouble(reader["price"]));
            }
            conn.Close();
            sql = "SELECT * FROM products WHERE category = 'kid'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                kid.Add(reader["image1"].ToString());
                kidID.Add(Convert.ToInt32(reader["id"]));
                kidPrice.Add(Convert.ToDouble(reader["price"]));
            }
            conn.Close();
            sql = "SELECT * FROM products WHERE category = 'sunglasses'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sunglasses.Add(reader["image1"].ToString());
                sunglassesID.Add(Convert.ToInt32(reader["id"]));
                sunglassesPrice.Add(Convert.ToDouble(reader["price"]));
            }
            conn.Close();
            sql = "SELECT * FROM products WHERE category = 'bluelightprotection'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                blp.Add(reader["image1"].ToString());
                blpID.Add(Convert.ToInt32(reader["id"]));
                blpPrice.Add(Convert.ToDouble(reader["price"]));
            }
            conn.Close();
            sql = "SELECT * FROM products WHERE category = 'lens'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lens.Add(reader["image1"].ToString());
                lensID.Add(Convert.ToInt32(reader["id"]));
                lensPrice.Add(Convert.ToDouble(reader["price"]));
            }
            conn.Close();
            sql = "SELECT * FROM products WHERE category = 'newseason'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                newSeason.Add(reader["image1"].ToString());
                newSeasonID.Add(Convert.ToInt32(reader["id"]));
                newSeasonPrice.Add(Convert.ToDouble(reader["price"]));
            }
            conn.Close();
            sql = "SELECT * FROM products WHERE category = 'accessory'";
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                accessory.Add(reader["image1"].ToString());
                accessoryID.Add(Convert.ToInt32(reader["id"]));
                accessoryPrice.Add(Convert.ToDouble(reader["price"]));
            }
            conn.Close();
        }

        private void listOfPricesBestseller(List<double> bestsellerPrice)
        {   if (bestsellerPrice.Count > 0)
            {
                price1.Text = bestsellerPrice[0].ToString() + "₺";
                price1.Visible = true;
            }
            if (bestsellerPrice.Count > 1)
            {
                price2.Text = bestsellerPrice[1].ToString() + "₺";
                price2.Visible = true;
            }
            if (bestsellerPrice.Count > 2)
            { 
                price3.Text = bestsellerPrice[2].ToString() + "₺";
                price3.Visible = true;
            }
            if (bestsellerPrice.Count > 3) 
            {
                price4.Text = bestsellerPrice[3].ToString() + "₺";
                price4.Visible = true;
            }
            if (bestsellerPrice.Count > 4) 
            {
                price5.Text = bestsellerPrice[4].ToString() + "₺";
                price5.Visible = true;
            }
            if (bestsellerPrice.Count > 5) 
            {
                price6.Text = bestsellerPrice[5].ToString() + "₺";
                price6.Visible = true;
            }
            if (bestsellerPrice.Count > 6) 
            { 
                price7.Text = bestsellerPrice[6].ToString() + "₺";
                price7.Visible = true;
            }
            if (bestsellerPrice.Count > 7) 
            { 
                price8.Text = bestsellerPrice[7].ToString() + "₺";
                price8.Visible = true;
            }
            if (bestsellerPrice.Count > 8) 
            { 
                price9.Text = bestsellerPrice[8].ToString() + "₺";
                price9.Visible = true;
            }
            if (bestsellerPrice.Count > 9) 
            { 
                price10.Text = bestsellerPrice[9].ToString() + "₺";
                price10.Visible = true;
            }
            if (bestsellerPrice.Count > 10)
            { 
                price11.Text = bestsellerPrice[10].ToString() + "₺";
                price11.Visible = true;
            }
            if (bestsellerPrice.Count > 11) 
            { 
                price12.Text = bestsellerPrice[11].ToString() + "₺";
                price12.Visible = true;
            }
        }

        private void listOfPricesWomen(List<double> womenPrice)
        {
            if (womenPrice.Count > 0)
            {
                price1.Text = womenPrice[0].ToString() + "₺";
                price1.Visible = true;
            }
            if (womenPrice.Count > 1)
            {
                price2.Text = womenPrice[1].ToString() + "₺";
                price2.Visible = true;
            }
            if (womenPrice.Count > 2)
            {
                price3.Text = womenPrice[2].ToString() + "₺";
                price3.Visible = true;
            }
            if (womenPrice.Count > 3)
            {
                price4.Text = womenPrice[3].ToString() + "₺";
                price4.Visible = true;
            }
            if (womenPrice.Count > 4)
            {
                price5.Text = womenPrice[4].ToString() + "₺";
                price5.Visible = true;
            }
            if (womenPrice.Count > 5)
            {
                price6.Text = womenPrice[5].ToString() + "₺";
                price6.Visible = true;
            }
            if (womenPrice.Count > 6)
            {
                price7.Text = womenPrice[6].ToString() + "₺";
                price7.Visible = true;
            }
            if (womenPrice.Count > 7)
            {
                price8.Text = womenPrice[7].ToString() + "₺";
                price8.Visible = true;
            }
            if (womenPrice.Count > 8)
            {
                price9.Text = womenPrice[8].ToString() + "₺";
                price9.Visible = true;
            }
            if (womenPrice.Count > 9)
            {
                price10.Text = womenPrice[9].ToString() + "₺";
                price10.Visible = true;
            }
            if (womenPrice.Count > 10)
            {
                price11.Text = womenPrice[10].ToString() + "₺";
                price11.Visible = true;
            }
            if (womenPrice.Count > 11)
            {
                price12.Text = womenPrice[11].ToString() + "₺";
                price12.Visible = true;
            }
        }

        private void listOfPricesMen(List<double> menPrice)
        {
            if (menPrice.Count > 0)
            {
                price1.Text = menPrice[0].ToString() + "₺";
                price1.Visible = true;
            }
            if (menPrice.Count > 1)
            {
                price2.Text = menPrice[1].ToString() + "₺";
                price2.Visible = true;
            }
            if (menPrice.Count > 2)
            {
                price3.Text = menPrice[2].ToString() + "₺";
                price3.Visible = true;
            }
            if (menPrice.Count > 3)
            {
                price4.Text = menPrice[3].ToString() + "₺";
                price4.Visible = true;
            }
            if (menPrice.Count > 4)
            {
                price5.Text = menPrice[4].ToString() + "₺";
                price5.Visible = true;
            }
            if (menPrice.Count > 5)
            {
                price6.Text = menPrice[5].ToString() + "₺";
                price6.Visible = true;
            }
            if (menPrice.Count > 6)
            {
                price7.Text = menPrice[6].ToString() + "₺";
                price7.Visible = true;
            }
            if (menPrice.Count > 7)
            {
                price8.Text = menPrice[7].ToString() + "₺";
                price8.Visible = true;
            }
            if (menPrice.Count > 8)
            {
                price9.Text = menPrice[8].ToString() + "₺";
                price9.Visible = true;
            }
            if (menPrice.Count > 9)
            {
                price10.Text = menPrice[9].ToString() + "₺";
                price10.Visible = true;
            }
            if (menPrice.Count > 10)
            {
                price11.Text = menPrice[10].ToString() + "₺";
                price11.Visible = true;
            }
            if (menPrice.Count > 11)
            {
                price12.Text = menPrice[11].ToString() + "₺";
                price12.Visible = true;
            }
        }

        private void listOfPricesKid(List<double> kidPrice)
        {
            if (kidPrice.Count > 0)
            {
                price1.Text = kidPrice[0].ToString() + "₺";
                price1.Visible = true;
            }
            if (kidPrice.Count > 1)
            {
                price2.Text = kidPrice[1].ToString() + "₺";
                price2.Visible = true;
            }
            if (kidPrice.Count > 2)
            {
                price3.Text = kidPrice[2].ToString() + "₺";
                price3.Visible = true;
            }
            if (kidPrice.Count > 3)
            {
                price4.Text = kidPrice[3].ToString() + "₺";
                price4.Visible = true;
            }
            if (kidPrice.Count > 4)
            {
                price5.Text = kidPrice[4].ToString() + "₺";
                price5.Visible = true;
            }
            if (kidPrice.Count > 5)
            {
                price6.Text = kidPrice[5].ToString() + "₺";
                price6.Visible = true;
            }
            if (kidPrice.Count > 6)
            {
                price7.Text = kidPrice[6].ToString() + "₺";
                price7.Visible = true;
            }
            if (kidPrice.Count > 7)
            {
                price8.Text = kidPrice[7].ToString() + "₺";
                price8.Visible = true;
            }
            if (kidPrice.Count > 8)
            {
                price9.Text = kidPrice[8].ToString() + "₺";
                price9.Visible = true;
            }
            if (kidPrice.Count > 9)
            {
                price10.Text = kidPrice[9].ToString() + "₺";
                price10.Visible = true;
            }
            if (kidPrice.Count > 10)
            {
                price11.Text = kidPrice[10].ToString() + "₺";
                price11.Visible = true;
            }
            if (kidPrice.Count > 11)
            {
                price12.Text = kidPrice[11].ToString() + "₺";
                price12.Visible = true;
            }
        }

        private void listOfPricesSunglasses(List<double> sunglassesPrice)
        {
            if (sunglassesPrice.Count > 0)
            {
                price1.Text = sunglassesPrice[0].ToString() + "₺";
                price1.Visible = true;
            }
            if (sunglassesPrice.Count > 1)
            {
                price2.Text = sunglassesPrice[1].ToString() + "₺";
                price2.Visible = true;
            }
            if (sunglassesPrice.Count > 2)
            {
                price3.Text = sunglassesPrice[2].ToString() + "₺";
                price3.Visible = true;
            }
            if (sunglassesPrice.Count > 3)
            {
                price4.Text = sunglassesPrice[3].ToString() + "₺";
                price4.Visible = true;
            }
            if (sunglassesPrice.Count > 4)
            {
                price5.Text = sunglassesPrice[4].ToString() + "₺";
                price5.Visible = true;
            }
            if (sunglassesPrice.Count > 5)
            {
                price6.Text = sunglassesPrice[5].ToString() + "₺";
                price6.Visible = true;
            }
            if (sunglassesPrice.Count > 6)
            {
                price7.Text = sunglassesPrice[6].ToString() + "₺";
                price7.Visible = true;
            }
            if (sunglassesPrice.Count > 7)
            {
                price8.Text = sunglassesPrice[7].ToString() + "₺";
                price8.Visible = true;
            }
            if (sunglassesPrice.Count > 8)
            {
                price9.Text = sunglassesPrice[8].ToString() + "₺";
                price9.Visible = true;
            }
            if (sunglassesPrice.Count > 9)
            {
                price10.Text = sunglassesPrice[9].ToString() + "₺";
                price10.Visible = true;
            }
            if (sunglassesPrice.Count > 10)
            {
                price11.Text = sunglassesPrice[10].ToString() + "₺";
                price11.Visible = true;
            }
            if (sunglassesPrice.Count > 11)
            {
                price12.Text = sunglassesPrice[11].ToString() + "₺";
                price12.Visible = true;
            }
        }

        private void listOfPricesBLP(List<double> blpPrice)
        {
            if (blpPrice.Count > 0)
            {
                price1.Text = blpPrice[0].ToString() + "₺";
                price1.Visible = true;
            }
            if (blpPrice.Count > 1)
            {
                price2.Text = blpPrice[1].ToString() + "₺";
                price2.Visible = true;
            }
            if (blpPrice.Count > 2)
            {
                price3.Text = blpPrice[2].ToString() + "₺";
                price3.Visible = true;
            }
            if (blpPrice.Count > 3)
            {
                price4.Text = blpPrice[3].ToString() + "₺";
                price4.Visible = true;
            }
            if (blpPrice.Count > 4)
            {
                price5.Text = blpPrice[4].ToString() + "₺";
                price5.Visible = true;
            }
            if (blpPrice.Count > 5)
            {
                price6.Text = blpPrice[5].ToString() + "₺";
                price6.Visible = true;
            }
            if (blpPrice.Count > 6)
            {
                price7.Text = blpPrice[6].ToString() + "₺";
                price7.Visible = true;
            }
            if (blpPrice.Count > 7)
            {
                price8.Text = blpPrice[7].ToString() + "₺";
                price8.Visible = true;
            }
            if (blpPrice.Count > 8)
            {
                price9.Text = blpPrice[8].ToString() + "₺";
                price9.Visible = true;
            }
            if (blpPrice.Count > 9)
            {
                price10.Text = blpPrice[9].ToString() + "₺";
                price10.Visible = true;
            }
            if (blpPrice.Count > 10)
            {
                price11.Text = blpPrice[10].ToString() + "₺";
                price11.Visible = true;
            }
            if (blpPrice.Count > 11)
            {
                price12.Text = blpPrice[11].ToString() + "₺";
                price12.Visible = true;
            }
        }

        private void listOfPricesLens(List<double> lensPrice)
        {
            if (lensPrice.Count > 0)
            {
                price1.Text = lensPrice[0].ToString() + "₺";
                price1.Visible = true;
            }
            if (lensPrice.Count > 1)
            {
                price2.Text = lensPrice[1].ToString() + "₺";
                price2.Visible = true;
            }
            if (lensPrice.Count > 2)
            {
                price3.Text = lensPrice[2].ToString() + "₺";
                price3.Visible = true;
            }
            if (lensPrice.Count > 3)
            {
                price4.Text = lensPrice[3].ToString() + "₺";
                price4.Visible = true;
            }
            if (lensPrice.Count > 4)
            {
                price5.Text = lensPrice[4].ToString() + "₺";
                price5.Visible = true;
            }
            if (lensPrice.Count > 5)
            {
                price6.Text = lensPrice[5].ToString() + "₺";
                price6.Visible = true;
            }
            if (lensPrice.Count > 6)
            {
                price7.Text = lensPrice[6].ToString() + "₺";
                price7.Visible = true;
            }
            if (lensPrice.Count > 7)
            {
                price8.Text = lensPrice[7].ToString() + "₺";
                price8.Visible = true;
            }
            if (lensPrice.Count > 8)
            {
                price9.Text = lensPrice[8].ToString() + "₺";
                price9.Visible = true;
            }
            if (lensPrice.Count > 9)
            {
                price10.Text = lensPrice[9].ToString() + "₺";
                price10.Visible = true;
            }
            if (lensPrice.Count > 10)
            {
                price11.Text = lensPrice[10].ToString() + "₺";
                price11.Visible = true;
            }
            if (lensPrice.Count > 11)
            {
                price12.Text = lensPrice[11].ToString() + "₺";
                price12.Visible = true;
            }
        }

        private void listOfPricesNewSeason(List<double> newSeasonPrice)
        {
            if (newSeasonPrice.Count > 0)
            {
                price1.Text = newSeasonPrice[0].ToString() + "₺";
                price1.Visible = true;
            }
            if (newSeasonPrice.Count > 1)
            {
                price2.Text = newSeasonPrice[1].ToString() + "₺";
                price2.Visible = true;
            }
            if (newSeasonPrice.Count > 2)
            {
                price3.Text = newSeasonPrice[2].ToString() + "₺";
                price3.Visible = true;
            }
            if (newSeasonPrice.Count > 3)
            {
                price4.Text = newSeasonPrice[3].ToString() + "₺";
                price4.Visible = true;
            }
            if (newSeasonPrice.Count > 4)
            {
                price5.Text = newSeasonPrice[4].ToString() + "₺";
                price5.Visible = true;
            }
            if (newSeasonPrice.Count > 5)
            {
                price6.Text = newSeasonPrice[5].ToString() + "₺";
                price6.Visible = true;
            }
            if (newSeasonPrice.Count > 6)
            {
                price7.Text = newSeasonPrice[6].ToString() + "₺";
                price7.Visible = true;
            }
            if (newSeasonPrice.Count > 7)
            {
                price8.Text = newSeasonPrice[7].ToString() + "₺";
                price8.Visible = true;
            }
            if (newSeasonPrice.Count > 8)
            {
                price9.Text = newSeasonPrice[8].ToString() + "₺";
                price9.Visible = true;
            }
            if (newSeasonPrice.Count > 9)
            {
                price10.Text = newSeasonPrice[9].ToString() + "₺";
                price10.Visible = true;
            }
            if (newSeasonPrice.Count > 10)
            {
                price11.Text = newSeasonPrice[10].ToString() + "₺";
                price11.Visible = true;
            }
            if (newSeasonPrice.Count > 11)
            {
                price12.Text = newSeasonPrice[11].ToString() + "₺";
                price12.Visible = true;
            }
        }

        private void listOfPricesAccessory(List<double> accessoryPrice)
        {
            if (accessoryPrice.Count > 0)
            {
                price1.Text = accessoryPrice[0].ToString() + "₺";
                price1.Visible = true;
            }
            if (accessoryPrice.Count > 1)
            {
                price2.Text = accessoryPrice[1].ToString() + "₺";
                price2.Visible = true;
            }
            if (accessoryPrice.Count > 2)
            {
                price3.Text = accessoryPrice[2].ToString() + "₺";
                price3.Visible = true;
            }
            if (accessoryPrice.Count > 3)
            {
                price4.Text = accessoryPrice[3].ToString() + "₺";
                price4.Visible = true;
            }
            if (accessoryPrice.Count > 4)
            {
                price5.Text = accessoryPrice[4].ToString() + "₺";
                price5.Visible = true;
            }
            if (accessoryPrice.Count > 5)
            {
                price6.Text = accessoryPrice[5].ToString() + "₺";
                price6.Visible = true;
            }
            if (accessoryPrice.Count > 6)
            {
                price7.Text = accessoryPrice[6].ToString() + "₺";
                price7.Visible = true;
            }
            if (accessoryPrice.Count > 7)
            {
                price8.Text = accessoryPrice[7].ToString() + "₺";
                price8.Visible = true;
            }
            if (accessoryPrice.Count > 8)
            {
                price9.Text = accessoryPrice[8].ToString() + "₺";
                price9.Visible = true;
            }
            if (accessoryPrice.Count > 9)
            {
                price10.Text = accessoryPrice[9].ToString() + "₺";
                price10.Visible = true;
            }
            if (accessoryPrice.Count > 10)
            {
                price11.Text = accessoryPrice[10].ToString() + "₺";
                price11.Visible = true;
            }
            if (accessoryPrice.Count > 11)
            {
                price12.Text = accessoryPrice[11].ToString() + "₺";
                price12.Visible = true;
            }
        }

        private void listOfProductsBestseller()
        {
            if (bestseller.Count > 0) 
            {
                product1.ImageLocation = bestseller[0];
                p1ID = bestsellerID[0];
                product1.Visible = true;
                fav1Button.Visible = true;
            }
            if (bestseller.Count > 1) 
            { 
                product2.ImageLocation = bestseller[1];
                p2ID = bestsellerID[1];
                product2.Visible = true;
                fav2Button.Visible = true;
            }
            if (bestseller.Count > 2) 
            { 
                product3.ImageLocation = bestseller[2];
                p3ID = bestsellerID[2];
                product3.Visible = true;
                fav3Button.Visible = true;
            }
            if (bestseller.Count > 3)
            { 
                product4.ImageLocation = bestseller[3];
                p4ID = bestsellerID[3];
                product4.Visible = true;
                fav4Button.Visible = true;
            }
            if (bestseller.Count > 4) 
            { 
                product5.ImageLocation = bestseller[4];
                p5ID = bestsellerID[4];
                product5.Visible = true;
                fav5Button.Visible = true;
            }
            if (bestseller.Count > 5) 
            { 
                product6.ImageLocation = bestseller[5];
                p6ID = bestsellerID[5];
                product6.Visible = true;
                fav6Button.Visible = true;
            }
            if (bestseller.Count > 6) 
            { 
                product7.ImageLocation = bestseller[6];
                p7ID = bestsellerID[6];
                product7.Visible = true;
                fav7Button.Visible = true;
            }
            if (bestseller.Count > 7) 
            {
                product8.ImageLocation = bestseller[7];
                p8ID = bestsellerID[7];
                product8.Visible = true;
                fav8Button.Visible = true;
            }
            if (bestseller.Count > 8) 
            { 
                product9.ImageLocation = bestseller[8];
                p9ID = bestsellerID[8];
                product9.Visible = true;
                fav9Button.Visible = true;
            }
            if (bestseller.Count > 9) 
            { 
                product10.ImageLocation = bestseller[9];
                p10ID = bestsellerID[9];
                product10.Visible = true;
                fav10Button.Visible = true;
            }
            if (bestseller.Count > 10) 
            { 
                product11.ImageLocation = bestseller[10];
                p11ID = bestsellerID[10];
                product11.Visible = true;
                fav11Button.Visible = true;
            }
            if (bestseller.Count > 11) 
            { 
                product12.ImageLocation = bestseller[11];
                p12ID = bestsellerID[11];
                product12.Visible = true;
                fav12Button.Visible = true;
            }
        }

        private void listOfProductsWomen()
        {
            if (women.Count > 0)
            {
                product1.ImageLocation = women[0];
                p1ID = womenID[0];
                product1.Visible = true;
                fav1Button.Visible = true;
            }
            if (women.Count > 1)
            {
                product2.ImageLocation = women[1];
                p2ID = womenID[1];
                product2.Visible = true;
                fav2Button.Visible = true;
            }
            if (women.Count > 2)
            {
                product3.ImageLocation = women[2];
                p3ID = womenID[2];
                product3.Visible = true;
                fav3Button.Visible = true;
            }
            if (women.Count > 3)
            {
                product4.ImageLocation = women[3];
                p4ID = womenID[3];
                product4.Visible = true;
                fav4Button.Visible = true;
            }
            if (women.Count > 4)
            {
                product5.ImageLocation = women[4];
                p5ID = womenID[4];
                product5.Visible = true;
                fav5Button.Visible = true;
            }
            if (women.Count > 5)
            {
                product6.ImageLocation = women[5];
                p6ID = womenID[5];
                product6.Visible = true;
                fav6Button.Visible = true;
            }
            if (women.Count > 6)
            {
                product7.ImageLocation = women[6];
                p7ID = womenID[6];
                product7.Visible = true;
                fav7Button.Visible = true;
            }
            if (women.Count > 7)
            {
                product8.ImageLocation = women[7];
                p8ID = womenID[7];
                product8.Visible = true;
                fav8Button.Visible = true;
            }
            if (women.Count > 8)
            {
                product9.ImageLocation = women[8];
                p9ID = womenID[8];
                product9.Visible = true;
                fav9Button.Visible = true;
            }
            if (women.Count > 9)
            {
                product10.ImageLocation = women[9];
                p10ID = womenID[9];
                product10.Visible = true;
                fav10Button.Visible = true;
            }
            if (women.Count > 10)
            {
                product11.ImageLocation = women[10];
                p11ID = womenID[10];
                product11.Visible = true;
                fav11Button.Visible = true;
            }
            if (women.Count > 11)
            {
                product12.ImageLocation = women[11];
                p12ID = womenID[11];
                product12.Visible = true;
                fav12Button.Visible = true;
            }
        }

        private void listOfProductsMen()
        {
            if (men.Count > 0)
            {
                product1.ImageLocation = men[0];
                p1ID = menID[0];
                product1.Visible = true;
                fav1Button.Visible = true;
            }
            if (men.Count > 1)
            {
                product2.ImageLocation = men[1];
                p2ID = menID[1];
                product2.Visible = true;
                fav2Button.Visible = true;
            }
            if (men.Count > 2)
            {
                product3.ImageLocation = men[2];
                p3ID = menID[2];
                product3.Visible = true;
                fav3Button.Visible = true;
            }
            if (men.Count > 3)
            {
                product4.ImageLocation = men[3];
                p4ID = menID[3];
                product4.Visible = true;
                fav4Button.Visible = true;
            }
            if (men.Count > 4)
            {
                product5.ImageLocation = men[4];
                p5ID = menID[4];
                product5.Visible = true;
                fav5Button.Visible = true;
            }
            if (men.Count > 5)
            {
                product6.ImageLocation = men[5];
                p6ID = menID[5];
                product6.Visible = true;
                fav6Button.Visible = true;
            }
            if (men.Count > 6)
            {
                product7.ImageLocation = men[6];
                p7ID = menID[6];
                product7.Visible = true;
                fav7Button.Visible = true;
            }
            if (men.Count > 7)
            {
                product8.ImageLocation = men[7];
                p8ID = menID[7];
                product8.Visible = true;
                fav8Button.Visible = true;
            }
            if (men.Count > 8)
            {
                product9.ImageLocation = men[8];
                p9ID = menID[8];
                product9.Visible = true;
                fav9Button.Visible = true;
            }
            if (men.Count > 9)
            {
                product10.ImageLocation = men[9];
                p10ID = menID[9];
                product10.Visible = true;
                fav10Button.Visible = true;
            }
            if (men.Count > 10)
            {
                product11.ImageLocation = men[10];
                p11ID = menID[10];
                product11.Visible = true;
                fav11Button.Visible = true;
            }
            if (men.Count > 11)
            {
                product12.ImageLocation = men[11];
                p12ID = menID[11];
                product12.Visible = true;
                fav12Button.Visible = true;
            }
        }

        private void listOfProductsKid()
        {
            if (kid.Count > 0)
            {
                product1.ImageLocation = kid[0];
                p1ID = kidID[0];
                product1.Visible = true;
                fav1Button.Visible = true;
            }
            if (kid.Count > 1)
            {
                product2.ImageLocation = kid[1];
                p2ID = kidID[1];
                product2.Visible = true;
                fav2Button.Visible = true;
            }
            if (kid.Count > 2)
            {
                product3.ImageLocation = kid[2];
                p3ID = kidID[2];
                product3.Visible = true;
                fav3Button.Visible = true;
            }
            if (kid.Count > 3)
            {
                product4.ImageLocation = kid[3];
                p4ID = kidID[3];
                product4.Visible = true;
                fav4Button.Visible = true;
            }
            if (kid.Count > 4)
            {
                product5.ImageLocation = kid[4];
                p5ID = kidID[4];
                product5.Visible = true;
                fav5Button.Visible = true;
            }
            if (kid.Count > 5)
            {
                product6.ImageLocation = kid[5];
                p6ID = kidID[5];
                product6.Visible = true;
                fav6Button.Visible = true;
            }
            if (kid.Count > 6)
            {
                product7.ImageLocation = kid[6];
                p7ID = kidID[6];
                product7.Visible = true;
                fav7Button.Visible = true;
            }
            if (kid.Count > 7)
            {
                product8.ImageLocation = kid[7];
                p8ID = kidID[7];
                product8.Visible = true;
                fav8Button.Visible = true;
            }
            if (kid.Count > 8)
            {
                product9.ImageLocation = kid[8];
                p9ID = kidID[8];
                product9.Visible = true;
                fav9Button.Visible = true;
            }
            if (kid.Count > 9)
            {
                product10.ImageLocation = kid[9];
                p10ID = kidID[9];
                product10.Visible = true;
                fav10Button.Visible = true;
            }
            if (kid.Count > 10)
            {
                product11.ImageLocation = kid[10];
                p11ID = kidID[10];
                product11.Visible = true;
                fav11Button.Visible = true;
            }
            if (kid.Count > 11)
            {
                product12.ImageLocation = kid[11];
                p12ID = kidID[11];
                product12.Visible = true;
                fav12Button.Visible = true;
            }
        }

        private void product2_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p2ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void WhereAreWe_Click(object sender, EventArgs e)
        {
            whereAreWe waw = new whereAreWe();
            waw.ShowDialog();
        }

        private void AboutUs_Click(object sender, EventArgs e)
        {
            aboutUs au = new aboutUs();
            au.ShowDialog();
        }

        private void FAQ_Click(object sender, EventArgs e)
        {
            faqScreen fs = new faqScreen();
            fs.ShowDialog();
        }

        private void product3_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p3ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void product4_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p4ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void product5_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p5ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void product6_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p6ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void product7_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p7ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void product8_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p8ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void product9_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p9ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void product10_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p10ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void product11_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p11ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void product12_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p12ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void Orders_Click(object sender, EventArgs e)
        {
            ordersScreen os = new ordersScreen();
            os.userId = userId;
            os.ShowDialog();
        }

        private void listOfProductsSunglasses()
        {
            if (sunglasses.Count > 0)
            {
                product1.ImageLocation = sunglasses[0];
                p1ID = sunglassesID[0];
                product1.Visible = true;
                fav1Button.Visible = true;
            }
            if (sunglasses.Count > 1)
            {
                product2.ImageLocation = sunglasses[1];
                p2ID = sunglassesID[1];
                product2.Visible = true;
                fav2Button.Visible = true;
            }
            if (sunglasses.Count > 2)
            {
                product3.ImageLocation = sunglasses[2];
                p3ID = sunglassesID[2];
                product3.Visible = true;
                fav3Button.Visible = true;
            }
            if (sunglasses.Count > 3)
            {
                product4.ImageLocation = sunglasses[3];
                p4ID = sunglassesID[3];
                product4.Visible = true;
                fav4Button.Visible = true;
            }
            if (sunglasses.Count > 4)
            {
                product5.ImageLocation = sunglasses[4];
                p5ID = sunglassesID[4];
                product5.Visible = true;
                fav5Button.Visible = true;
            }
            if (sunglasses.Count > 5)
            {
                product6.ImageLocation = sunglasses[5];
                p6ID = sunglassesID[5];
                product6.Visible = true;
                fav6Button.Visible = true;
            }
            if (sunglasses.Count > 6)
            {
                product7.ImageLocation = sunglasses[6];
                p7ID = sunglassesID[6];
                product7.Visible = true;
                fav7Button.Visible = true;
            }
            if (sunglasses.Count > 7)
            {
                product8.ImageLocation = sunglasses[7];
                p8ID = sunglassesID[7];
                product8.Visible = true;
                fav8Button.Visible = true;
            }
            if (sunglasses.Count > 8)
            {
                product9.ImageLocation = sunglasses[8];
                p9ID = sunglassesID[8];
                product9.Visible = true;
                fav9Button.Visible = true;
            }
            if (sunglasses.Count > 9)
            {
                product10.ImageLocation = sunglasses[9];
                p10ID = sunglassesID[9];
                product10.Visible = true;
                fav10Button.Visible = true;
            }
            if (sunglasses.Count > 10)
            {
                product11.ImageLocation = sunglasses[10];
                p11ID = sunglassesID[10];
                product11.Visible = true;
                fav11Button.Visible = true;
            }
            if (sunglasses.Count > 11)
            {
                product12.ImageLocation = sunglasses[11];
                p12ID = sunglassesID[11];
                product12.Visible = true;
                fav12Button.Visible = true;
            }
        }

        private void listOfProductsBLP()
        {
            if (blp.Count > 0)
            {
                product1.ImageLocation = blp[0];
                p1ID = blpID[0];
                product1.Visible = true;
                fav1Button.Visible = true;
            }
            if (blp.Count > 1)
            {
                product2.ImageLocation = blp[1];
                p2ID = blpID[1];
                product2.Visible = true;
                fav2Button.Visible = true;
            }
            if (blp.Count > 2)
            {
                product3.ImageLocation = blp[2];
                p3ID = blpID[2];
                product3.Visible = true;
                fav3Button.Visible = true;
            }
            if (blp.Count > 3)
            {
                product4.ImageLocation = blp[3];
                p4ID = blpID[3];
                product4.Visible = true;
                fav4Button.Visible = true;
            }
            if (blp.Count > 4)
            {
                product5.ImageLocation = blp[4];
                p5ID = blpID[4];
                product5.Visible = true;
                fav5Button.Visible = true;
            }
            if (blp.Count > 5)
            {
                product6.ImageLocation = blp[5];
                p6ID = blpID[5];
                product6.Visible = true;
                fav6Button.Visible = true;
            }
            if (blp.Count > 6)
            {
                product7.ImageLocation = blp[6];
                p7ID = blpID[6];
                product7.Visible = true;
                fav7Button.Visible = true;
            }
            if (blp.Count > 7)
            {
                product8.ImageLocation = blp[7];
                p8ID = blpID[7];
                product8.Visible = true;
                fav8Button.Visible = true;
            }
            if (blp.Count > 8)
            {
                product9.ImageLocation = blp[8];
                p9ID = blpID[8];
                product9.Visible = true;
                fav9Button.Visible = true;
            }
            if (blp.Count > 9)
            {
                product10.ImageLocation = blp[9];
                p10ID = blpID[9];
                product10.Visible = true;
                fav10Button.Visible = true;
            }
            if (blp.Count > 10)
            {
                product11.ImageLocation = blp[10];
                p11ID = blpID[10];
                product11.Visible = true;
                fav11Button.Visible = true;
            }
            if (blp.Count > 11)
            {
                product12.ImageLocation = blp[11];
                p12ID = blpID[11];
                product12.Visible = true;
                fav12Button.Visible = true;
            }
        }

        private void listOfProductsNewSeason()
        {
            if (newSeason.Count > 0)
            {
                product1.ImageLocation = newSeason[0];
                p1ID = newSeasonID[0];
                product1.Visible = true;
                fav1Button.Visible = true;
            }
            if (newSeason.Count > 1)
            {
                product2.ImageLocation = newSeason[1];
                p2ID = newSeasonID[1];
                product2.Visible = true;
                fav2Button.Visible = true;
            }
            if (newSeason.Count > 2)
            {
                product3.ImageLocation = newSeason[2];
                p3ID = newSeasonID[2];
                product3.Visible = true;
                fav3Button.Visible = true;
            }
            if (newSeason.Count > 3)
            {
                product4.ImageLocation = newSeason[3];
                p4ID = newSeasonID[3];
                product4.Visible = true;
                fav4Button.Visible = true;
            }
            if (newSeason.Count > 4)
            {
                product5.ImageLocation = newSeason[4];
                p5ID = newSeasonID[4];
                product5.Visible = true;
                fav5Button.Visible = true;
            }
            if (newSeason.Count > 5)
            {
                product6.ImageLocation = newSeason[5];
                p6ID = newSeasonID[5];
                product6.Visible = true;
                fav6Button.Visible = true;
            }
            if (newSeason.Count > 6)
            {
                product7.ImageLocation = newSeason[6];
                p7ID = newSeasonID[6];
                product7.Visible = true;
                fav7Button.Visible = true;
            }
            if (newSeason.Count > 7)
            {
                product8.ImageLocation = newSeason[7];
                p8ID = newSeasonID[7];
                product8.Visible = true;
                fav8Button.Visible = true;
            }
            if (newSeason.Count > 8)
            {
                product9.ImageLocation = newSeason[8];
                p9ID = newSeasonID[8];
                product9.Visible = true;
                fav9Button.Visible = true;
            }
            if (newSeason.Count > 9)
            {
                product10.ImageLocation = newSeason[9];
                p10ID = newSeasonID[9];
                product10.Visible = true;
                fav10Button.Visible = true;
            }
            if (newSeason.Count > 10)
            {
                product11.ImageLocation = newSeason[10];
                p11ID = newSeasonID[10];
                product11.Visible = true;
                fav11Button.Visible = true;
            }
            if (newSeason.Count > 11)
            {
                product12.ImageLocation = newSeason[11];
                p12ID = newSeasonID[11];
                product12.Visible = true;
                fav12Button.Visible = true;
            }
        }

        private void listOfProductsLens()
        {
            if (lens.Count > 0)
            {
                product1.ImageLocation = lens[0];
                p1ID = lensID[0];
                product1.Visible = true;
                fav1Button.Visible = true;
            }
            if (lens.Count > 1)
            {
                product2.ImageLocation = lens[1];
                p2ID = lensID[1];
                product2.Visible = true;
                fav2Button.Visible = true;
            }
            if (lens.Count > 2)
            {
                product3.ImageLocation = lens[2];
                p3ID = lensID[2];
                product3.Visible = true;
                fav3Button.Visible = true;
            }
            if (lens.Count > 3)
            {
                product4.ImageLocation = lens[3];
                p4ID = lensID[3];
                product4.Visible = true;
                fav4Button.Visible = true;
            }
            if (lens.Count > 4)
            {
                product5.ImageLocation = lens[4];
                p5ID = lensID[4];
                product5.Visible = true;
                fav5Button.Visible = true;
            }
            if (lens.Count > 5)
            {
                product6.ImageLocation = lens[5];
                p6ID = lensID[5];
                product6.Visible = true;
                fav6Button.Visible = true;
            }
            if (lens.Count > 6)
            {
                product7.ImageLocation = lens[6];
                p7ID = lensID[6];
                product7.Visible = true;
                fav7Button.Visible = true;
            }
            if (lens.Count > 7)
            {
                product8.ImageLocation = lens[7];
                p8ID = lensID[7];
                product8.Visible = true;
                fav8Button.Visible = true;
            }
            if (lens.Count > 8)
            {
                product9.ImageLocation = lens[8];
                p9ID = lensID[8];
                product9.Visible = true;
                fav9Button.Visible = true;
            }
            if (lens.Count > 9)
            {
                product10.ImageLocation = lens[9];
                p10ID = lensID[9];
                product10.Visible = true;
                fav10Button.Visible = true;
            }
            if (lens.Count > 10)
            {
                product11.ImageLocation = lens[10];
                p11ID = lensID[10];
                product11.Visible = true;
                fav11Button.Visible = true;
            }
            if (lens.Count > 11)
            {
                product12.ImageLocation = lens[11];
                p12ID = lensID[11];
                product12.Visible = true;
                fav12Button.Visible = true;
            }
        }

        private void listOfProductsAccessory()
        {
            if (accessory.Count > 0)
            {
                product1.ImageLocation = accessory[0];
                p1ID = accessoryID[0];
                product1.Visible = true;
                fav1Button.Visible = true;
            }
            if (accessory.Count > 1)
            {
                product2.ImageLocation = accessory[1];
                p2ID = accessoryID[1];
                product2.Visible = true;
                fav2Button.Visible = true;
            }
            if (accessory.Count > 2)
            {
                product3.ImageLocation = accessory[2];
                p3ID = accessoryID[2];
                product3.Visible = true;
                fav3Button.Visible = true;
            }
            if (accessory.Count > 3)
            {
                product4.ImageLocation = accessory[3];
                p4ID = accessoryID[3];
                product4.Visible = true;
                fav4Button.Visible = true;
            }
            if (accessory.Count > 4)
            {
                product5.ImageLocation = accessory[4];
                p5ID = accessoryID[4];
                product5.Visible = true;
                fav5Button.Visible = true;
            }
            if (accessory.Count > 5)
            {
                product6.ImageLocation = accessory[5];
                p6ID = accessoryID[5];
                product6.Visible = true;
                fav6Button.Visible = true;
            }
            if (accessory.Count > 6)
            {
                product7.ImageLocation = accessory[6];
                p7ID = accessoryID[6];
                product7.Visible = true;
                fav7Button.Visible = true;
            }
            if (accessory.Count > 7)
            {
                product8.ImageLocation = accessory[7];
                p8ID = accessoryID[7];
                product8.Visible = true;
                fav8Button.Visible = true;
            }
            if (accessory.Count > 8)
            {
                product9.ImageLocation = accessory[8];
                p9ID = accessoryID[8];
                product9.Visible = true;
                fav9Button.Visible = true;
            }
            if (accessory.Count > 9)
            {
                product10.ImageLocation = accessory[9];
                p10ID = accessoryID[9];
                product10.Visible = true;
                fav10Button.Visible = true;
            }
            if (accessory.Count > 10)
            {
                product11.ImageLocation = accessory[10];
                p11ID = accessoryID[10];
                product11.Visible = true;
                fav11Button.Visible = true;
            }
            if (accessory.Count > 11)
            {
                product12.ImageLocation = accessory[11];
                p12ID = accessoryID[11];
                product12.Visible = true;
                fav12Button.Visible = true;
            }
        }

        private void productVisible()
        {
            product1.Visible = false;
            product2.Visible = false;
            product3.Visible = false;
            product4.Visible = false;
            product5.Visible = false;
            product6.Visible = false;
            product7.Visible = false;
            product8.Visible = false;
            product9.Visible = false;
            product10.Visible = false;
            product11.Visible = false;
            product12.Visible = false;
            price1.Visible = false;
            price2.Visible = false;
            price3.Visible = false;
            price4.Visible = false;
            price5.Visible = false;
            price6.Visible = false;
            price7.Visible = false;
            price8.Visible = false;
            price9.Visible = false;
            price10.Visible = false;
            price11.Visible = false;
            price12.Visible = false;
            fav1Button.Visible = false;
            fav2Button.Visible = false;
            fav3Button.Visible = false;
            fav4Button.Visible = false;
            fav5Button.Visible = false;
            fav6Button.Visible = false;
            fav7Button.Visible = false;
            fav8Button.Visible = false;
            fav9Button.Visible = false;
            fav10Button.Visible = false;
            fav11Button.Visible = false;
            fav12Button.Visible = false;
        }

        private void favController()
        {
            if (fav == 1 && favoritesAudit1 == false)
            {
                fav1Button.ImageIndex = 1;
                favoritesAudit1 = true;
            }
            else
            {
                fav1Button.ImageIndex = 0;
                favoritesAudit1 = false;
            }
            if (fav == 2 && favoritesAudit2 == false)
            {
                fav2Button.ImageIndex = 1;
                favoritesAudit2 = true;
            }
            else
            {
                fav2Button.ImageIndex = 0;
                favoritesAudit2 = false;
            }
            if (fav == 3 && favoritesAudit3 == false)
            {
                fav3Button.ImageIndex = 1;
                favoritesAudit3 = true;
            }
            else
            {
                fav3Button.ImageIndex = 0;
                favoritesAudit3 = false;
            }
            if (fav == 4 && favoritesAudit4 == false)
            {
                fav4Button.ImageIndex = 1;
                favoritesAudit4 = true;
            }
            else
            {
                fav4Button.ImageIndex = 0;
                favoritesAudit4 = false;
            }
            if (fav == 5 && favoritesAudit5 == false)
            {
                fav5Button.ImageIndex = 1;
                favoritesAudit5 = true;
            }
            else
            {
                fav5Button.ImageIndex = 0;
                favoritesAudit5 = false;
            }
            if (fav == 6 && favoritesAudit6 == false)
            {
                fav6Button.ImageIndex = 1;
                favoritesAudit6 = true;
            }
            else
            {
                fav6Button.ImageIndex = 0;
                favoritesAudit6 = false;
            }
            if (fav == 7 && favoritesAudit7 == false)
            {
                fav7Button.ImageIndex = 1;
                favoritesAudit7 = false;
            }
            else
            {
                fav7Button.ImageIndex = 0;
                favoritesAudit7 = false;
            }
            if (fav == 8 && favoritesAudit8 == false)
            {
                fav8Button.ImageIndex = 1;
                favoritesAudit8 = true;
            }
            else
            {
                fav8Button.ImageIndex = 0;
                favoritesAudit8 = false;
            }
            if (fav == 9 && favoritesAudit9 == false)
            {
                fav9Button.ImageIndex = 1;
                favoritesAudit9 = true;
            }
            else
            {
                fav9Button.ImageIndex = 0;
                favoritesAudit9 = false;
            }
            if (fav == 10 && favoritesAudit10 == false)
            {
                fav10Button.ImageIndex = 1;
                favoritesAudit10 = true;
            }
            else
            {
                fav10Button.ImageIndex = 0;
                favoritesAudit10 = false;
            }
            if (fav == 11 && favoritesAudit11 == false)
            {
                fav11Button.ImageIndex = 1;
                favoritesAudit11 = true;
            }
            else
            {
                fav11Button.ImageIndex = 0;
                favoritesAudit11 = false;
            }
            if (fav == 12 && favoritesAudit12 == false)
            {
                fav12Button.ImageIndex = 1;
                favoritesAudit12 = true;
            }
            else
            {
                fav12Button.ImageIndex = 0;
                favoritesAudit12 = false;
            }
        }

        private void adminEditButton_Click(object sender, EventArgs e)
        {
            if (adminMenu==false)
            {
                addProductButton.Visible = true;
                editPruductButton.Visible = true;
                signOut.Visible = true;
                adminMenu = true;
            }
            else
            {
                addProductButton.Visible = false;
                editPruductButton.Visible = false;
                signOut.Visible = false;
                adminMenu = false;
            }
        }

        private void signOut_Click(object sender, EventArgs e)
        {
            menuVisibleChange();
            adminLogin = false;
            Application.Restart();
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            addProductPanel app = new addProductPanel();
            app.Show();
            this.Hide();
        }

        private void product1_Click(object sender, EventArgs e)
        {
            infoScreen.productID = p1ID;
            infoScreen.userID = userId;
            infoScreen.ShowDialog();
        }

        private void fav2Button_Click(object sender, EventArgs e)
        {
            productID = 1;
            fav = 2;
            if (favoritesAudit1 == false)
            {
                if (productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void fav3Button_Click(object sender, EventArgs e)
        {
            productID = 2;
            fav = 3;
            if (favoritesAudit1 == false)
            {
                if (productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void fav4Button_Click(object sender, EventArgs e)
        {
            productID = 3;
            fav = 4;
            if (favoritesAudit1 == false)
            {
                if (productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void fav5Button_Click(object sender, EventArgs e)
        {
            productID = 4;
            fav = 5;
            if (favoritesAudit1 == false)
            {
                if (productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void fav6Button_Click(object sender, EventArgs e)
        {
            productID = 5;
            fav = 6;
            if (favoritesAudit1 == false)
            {
                if (productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void fav7Button_Click(object sender, EventArgs e)
        {
            productID = 6;
            fav = 7;
            if (favoritesAudit1 == false)
            {
                if (productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void fav8Button_Click(object sender, EventArgs e)
        {
            productID = 7;
            fav = 8;
            if (favoritesAudit1 == false)
            {
                if (productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void fav9Button_Click(object sender, EventArgs e)
        {
            productID = 8;
            fav = 9;
            if (favoritesAudit1 == false)
            {
                if (productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void fav10Button_Click(object sender, EventArgs e)
        {
            productID = 9;
            fav = 10;
            if (favoritesAudit1 == false)
            {
                if (productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void fav11Button_Click(object sender, EventArgs e)
        {
            productID = 10;
            fav = 11;
            if (favoritesAudit1 == false)
            {
                if (productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void fav12Button_Click(object sender, EventArgs e)
        {
            productID = 11;
            fav = 12;
            if (favoritesAudit1 == false)
            {
                if (productController == 1)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", bestsellerID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", womenID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", menID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", kidID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", sunglassesID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", blpID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", lensID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", newSeasonID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    sql = "INSERT INTO favorites (userid,productid) VALUES (@userid,@productid)";
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@productid", accessoryID[productID].ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
            else
            {
                if (productController == 1)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + bestsellerID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 2)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + womenID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 3)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + menID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 4)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + kidID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 5)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + sunglassesID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 6)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + blpID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 7)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + lensID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 8)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + newSeasonID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (productController == 9)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE userid='" + userId + "' AND productid='" + accessoryID[productID].ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                favController();
            }
        }

        private void editPruductButton_Click(object sender, EventArgs e)
        {
            editProductPanel epp = new editProductPanel();
            epp.Show();
            this.Hide();
        }

        private void AccountInfo_Click(object sender, EventArgs e)
        {
            accountInfo ai = new accountInfo();
            ai.userName = userName;
            ai.ShowDialog();
        }

        private void Addresses_Click(object sender, EventArgs e)
        {
            addressesScreen address = new addressesScreen();
            address.userName = userName;
            address.ShowDialog();
        }

        private void Favorites_Click(object sender, EventArgs e)
        {
            favoritesScreen fs = new favoritesScreen();
            fs.userId = userId;
            fs.ShowDialog();
        }
    }
}
