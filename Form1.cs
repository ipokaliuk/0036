using System;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
record DogApi(string message, string status );
namespace _0036
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public  async Task UpdateImage()
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://dog.ceo/api/breeds/image/random");
                response.EnsureSuccessStatusCode();
                DogApi data = await response.Content.ReadFromJsonAsync<DogApi>();
                string url = data.message;
                pictureBox1.ImageLocation = url;
             
            }
            catch(Exception ex)
            {
                MessageBox.Show($"oops {ex.Message}");
            }
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            await UpdateImage();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += async (e , args) => await UpdateImage();
            timer.Interval = 6000;
            timer.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private async void pictureBox1_Click_1(object sender, EventArgs e)
        {
            await UpdateImage();
        }
    }
}