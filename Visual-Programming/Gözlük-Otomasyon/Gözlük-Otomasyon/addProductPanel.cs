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
    public partial class addProductPanel : Form
    {
        mainScreen ms = new mainScreen();
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");

        public addProductPanel()
        {
            InitializeComponent();
        }
        int i = 0;
        private void exitButton_Click(object sender, EventArgs e)
        {
            ms.adminLogin = true;
            ms.Show();
            this.Close();
        }

        private void addPictureButton_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                openFileDialog1.ShowDialog();
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.Visible = true;
                
                i++;
            }
            else if (i == 1)
            {
                openFileDialog1.ShowDialog();
                pictureBox2.ImageLocation = openFileDialog1.FileName;
                pictureBox1.Location = new Point(236,525);
                pictureBox2.Location = new Point(350,525);
                pictureBox2.Visible = true;
                i++;
            }
            else if (i == 2)
            {
                openFileDialog1.ShowDialog();
                pictureBox3.ImageLocation = openFileDialog1.FileName;
                pictureBox1.Location = new Point(181, 525);
                pictureBox2.Location = new Point(295,525);
                pictureBox3.Location = new Point(409,525);
                pictureBox3.Visible = true;
                i++;
            }
            else if (i == 3)
            {
                openFileDialog1.ShowDialog();
                pictureBox4.ImageLocation = openFileDialog1.FileName;
                pictureBox1.Location = new Point(122, 525);
                pictureBox2.Location = new Point(236, 525);
                pictureBox3.Location = new Point(350,525);
                pictureBox4.Location = new Point(464,525);
                pictureBox4.Visible = true;
                i++;
            }
            else
            {
                MessageBox.Show("You've reached the 4 picture limit!");
            }

        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO products(name,description,price,category,image1,image2,image3,image4) VALUES (@name,@description,@price,@category,@image1,@image2,@image3,@image4)", conn);
                cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
                cmd.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@price", priceTextBox.Text);
                cmd.Parameters.AddWithValue("@category", categorycomboBox.Text);
                cmd.Parameters.AddWithValue("@image1", openFileDialog1.FileName);
                cmd.Parameters.AddWithValue("@image2", openFileDialog2.FileName);
                cmd.Parameters.AddWithValue("@image3", openFileDialog3.FileName);
                cmd.Parameters.AddWithValue("@image4", openFileDialog4.FileName);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Product registered");
                nameTextBox.Text = "";
                descriptionTextBox.Text = "";
                priceTextBox.Text = "";
                categorycomboBox.SelectedIndex = -1;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;
            }
            catch
            {
                MessageBox.Show("An unknown error was encountered!");
            }
        }
    }
}
