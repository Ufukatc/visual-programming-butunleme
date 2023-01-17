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
using System.IO;

namespace Gözlük_Otomasyon
{
    public partial class editProductPanel : Form
    {
        mainScreen ms = new mainScreen();
        MySqlConnection conn = new MySqlConnection("Server=153.92.220.101;Database=u292344737_eyesoptical;Uid=u292344737_root;PwD='Root1864';");
        DataSet data = new DataSet();
        public editProductPanel()
        {
            InitializeComponent();
        }

        private void editProductPanel_Load(object sender, EventArgs e)
        {
            show_product();
        }

        private void show_product()
        {
            conn.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT * FROM products", conn);
            adtr.Fill(data, "products");
            dataGridView1.DataSource = data.Tables["products"];
            conn.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult delete;
            delete = MessageBox.Show("Are you sure you want to delete this product?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (delete == DialogResult.Yes)
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM products WHERE id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                data.Tables["products"].Clear();
                show_product();
                MessageBox.Show("The product has been deleted!");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ms.adminLogin = true;
            ms.Show();
            this.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                updateProductPanel upp = new updateProductPanel();
                upp.idTextBox.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                upp.nameTextBox.Text = dataGridView1.CurrentRow.Cells["name"].Value.ToString();
                upp.priceTextBox.Text = dataGridView1.CurrentRow.Cells["price"].Value.ToString();
                upp.descriptionTextBox.Text = dataGridView1.CurrentRow.Cells["description"].Value.ToString();
                upp.pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells["image1"].Value.ToString();
                upp.pictureBox2.ImageLocation = dataGridView1.CurrentRow.Cells["image2"].Value.ToString();
                upp.pictureBox3.ImageLocation = dataGridView1.CurrentRow.Cells["image3"].Value.ToString();
                upp.pictureBox4.ImageLocation = dataGridView1.CurrentRow.Cells["image4"].Value.ToString();
                upp.categorycomboBox.Text = dataGridView1.CurrentRow.Cells["category"].Value.ToString();
                upp.pictureBox1.Location = new Point(139, 376);
                upp.pictureBox2.Location = new Point(242, 376);
                upp.pictureBox3.Location = new Point(345, 376);
                upp.pictureBox4.Location = new Point(448, 376);
                upp.pictureBox1.Visible = true;
                upp.pictureBox2.Visible = true;
                upp.pictureBox3.Visible = true;
                upp.pictureBox4.Visible = true;
                upp.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                conn.Open();
                MySqlDataAdapter adtr = new MySqlDataAdapter("SELECT * FROM products WHERE name like '%" + searchTextBox.Text + "%'", conn);
                adtr.Fill(table);
                dataGridView1.DataSource = table;
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            updateButton.Enabled = true;
            deleteButton.Enabled = true;
        }
    }
}
