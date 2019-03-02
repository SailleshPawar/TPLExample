using CommanLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeApi
{
    public partial class Form1 : Form
    {
        private HttpClient _client;

        public Form1()
        {

            InitializeComponent();
            dataGridView1.Hide();
            pictureBox1.Hide();
            _client = new HttpClient();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            var users = await GetUserFromApi();
            dataGridView1.DataSource = users.data;
            DataGridViewColumn column = dataGridView1.Columns[3];
            column.Width = 300;
            dataGridView1.Show();
            pictureBox1.Hide();

        }

        public async Task<User> GetUserFromApi()
        {
            var response=await _client.GetStreamAsync("https://reqres.in/api/users?page=2");
            var responseString = new StreamReader(response).ReadToEnd();
            return JsonConvert.DeserializeObject<User>(responseString);
       }


        
    }
}
