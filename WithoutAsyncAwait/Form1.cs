using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WithoutAsyncAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            var price =  FetchProductPrice(10000);
            pictureBox1.Hide();
            MessageBox.Show($"The actual price of product is {price}");

        }

        public int FetchProductPrice(int productId)
        {
           Thread.Sleep(5000);
           HttpClient client = new HttpClient();
            var price =  client.GetStringAsync("http://localhost:63922/api/Coupon/" + productId).Result;
            return Convert.ToInt32(price);
        }

    }
}
