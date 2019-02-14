using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAndAwait
{
    public partial class Form1 : Form
    {
        //HttpClient _client = new HttpClient();
        //public Form1()
        //{
           


        //}
        private  HttpClient _client;

        public Form1()
        {
            InitializeComponent();
        }


        private async void btnFetch_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            var price = await FetchProductPriceAsync(10000);
            var t = FetchProductPriceAsync(10000).ContinueWith(x =>
                  {
                      CallMe(x.Result);
                      // MessageBox.Show($"The actual price of product is {x.Result}");
                  });

            await t;
            pictureBox1.Hide();
             MessageBox.Show($"The actual price of product is {price}");
        }

        public static void CallMe (int result){
            MessageBox.Show($"The actual price of product is {result}");
        }

        public async Task<int> FetchProductPriceAsync(int productId)
        {

            _client = new HttpClient();
          var price=await _client.GetStringAsync("http://localhost:63922/api/Coupon/"+ productId);
            return Convert.ToInt32(price);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
