using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gözlük_Otomasyon
{
    public partial class whereAreWe : Form
    {
        public whereAreWe()
        {
            InitializeComponent();
        }

        private void whereAreWe_Load(object sender, EventArgs e)
        {
            string street, city, state, street2, city2, state2;
            state = "odunpazari";
            city = "eskisehir";
            street = "ataturk bulvari";
            state2 = "merkez";
            city2 = "kutahya";
            street2 = "adnan menderes";
            try
            {
                StringBuilder queryAddress = new StringBuilder();
                queryAddress.Append("http://maps.google.com/maps?q=");
                queryAddress.Append(city + "," + "+");
                queryAddress.Append(state + "," + "+");
                queryAddress.Append(street + "," + "+");
                webBrowser1.Navigate(queryAddress.ToString());

                StringBuilder queryAddress2 = new StringBuilder();
                queryAddress2.Append("http://maps.google.com/maps?q=");
                queryAddress2.Append(city2 + "," + "+");
                queryAddress2.Append(state2 + "," + "+");
                queryAddress2.Append(street2 + "," + "+");
                webBrowser2.Navigate(queryAddress2.ToString());
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
    }
}
