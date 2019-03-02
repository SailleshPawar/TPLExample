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

namespace AsyncAndAwaitDeadlock
{
    public partial class Form1 : Form
    {
        HttpClient _client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
           

        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();

            //Task<int> tskPrice =FetchProductPriceAsync(10000);
            //var price=await tskPrice;
            var price=  FetchProductPriceAsync(10000);
            //var price =await tskPrice;
            pictureBox1.Hide();
            MessageBox.Show($"The actual price of product is {price}");
        }

       
        public  async Task<int> FetchProductPriceAsync(int productId)
        {
           // await Task.Delay(10000);
           
           var price=await _client.GetStringAsync("http://localhost:63922/api/Coupon/"+ productId);
            return Convert.ToInt32(price);
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
