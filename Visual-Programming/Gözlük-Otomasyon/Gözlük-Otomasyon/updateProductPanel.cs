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
    public partial class updateProductPanel : Form
    {
        mainScreen ms = new mainScreen();
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        public updateProductPanel()
        {
            InitializeComponent();
        }
        int i = 0;
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE products SET id=@id,name=@name,description=@description,price=@price,category=@category WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", idTextBox.Text);
                cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
                cmd.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@price", priceTextBox.Text);
                cmd.Parameters.AddWithValue("@category", categorycomboBox.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Product updated");
                editProductPanel epp = new editProductPanel();
                epp.Show();
                this.Hide();
            }
            else if (i == 1)
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE products SET id=@id,name=@name,description=@description,price=@price,category=@category,image1=@image1 WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", idTextBox.Text);
                cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
                cmd.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@price", priceTextBox.Text);
                cmd.Parameters.AddWithValue("@category", categorycomboBox.Text);
                cmd.Parameters.AddWithValue("@image1", openFileDialog1.FileName);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Product updated");
                editProductPanel epp = new editProductPanel();
                epp.Show();
                this.Hide();
            }
            else if (i == 2)
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE products SET id=@id,name=@name,description=@description,price=@price,category=@category,image1=@image1,image2=@image2 WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", idTextBox.Text);
                cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
                cmd.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@price", priceTextBox.Text);
                cmd.Parameters.AddWithValue("@category", categorycomboBox.Text);
                cmd.Parameters.AddWithValue("@image1", openFileDialog1.FileName);
                cmd.Parameters.AddWithValue("@image2", openFileDialog2.FileName);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Product updated");
                editProductPanel epp = new editProductPanel();
                epp.Show();
                this.Hide();
            }
            else if (i == 3)
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE products SET id=@id,name=@name,description=@description,price=@price,category=@category,image1=@image1,image2=@image2,image3=@image3 WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", idTextBox.Text);
                cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
                cmd.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@price", priceTextBox.Text);
                cmd.Parameters.AddWithValue("@category", categorycomboBox.Text);
                cmd.Parameters.AddWithValue("@image1", openFileDialog1.FileName);
                cmd.Parameters.AddWithValue("@image2", openFileDialog2.FileName);
                cmd.Parameters.AddWithValue("@image3", openFileDialog3.FileName);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Product updated");
                editProductPanel epp = new editProductPanel();
                epp.Show();
                this.Hide();
            }
            else if (i == 4)
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE products SET id=@id,name=@name,description=@description,price=@price,category=@category,image1=@image1,image2=@image2,image3=@image3,image4=@image4 WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", idTextBox.Text);
                cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
                cmd.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@price", priceTextBox.Text);
                cmd.Parameters.AddWithValue("@category", categorycomboBox.Text);
                cmd.Parameters.AddWithValue("@image1", openFileDialog1.FileName);
                cmd.Parameters.AddWithValue("@image2", openFileDialog2.FileName);
                cmd.Parameters.AddWithValue("@image3", openFileDialog3.FileName);
                cmd.Parameters.AddWithValue("@image4", openFileDialog4.FileName);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Product updated");
                editProductPanel epp = new editProductPanel();
                epp.Show();
                this.Hide();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ms.adminLogin = true;
            editProductPanel epp = new editProductPanel();
            epp.Show();
            this.Close();
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {

            if (i == 0)
            {
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;

                openFileDialog1.ShowDialog();
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                i++;
            }
            else if (i == 1)
            {
                openFileDialog2.ShowDialog();
                pictureBox2.ImageLocation = openFileDialog2.FileName;
                i++;
            }
            else if (i == 2)
            {
                openFileDialog3.ShowDialog();
                pictureBox3.ImageLocation = openFileDialog3.FileName;
                i++;
            }
            else if (i == 3)
            {
                openFileDialog4.ShowDialog();
                pictureBox4.ImageLocation = openFileDialog4.FileName;
                i++;
            }
            else
            {
                MessageBox.Show("You've reached the 4 picture limit!");
            }
        }
    }
}
