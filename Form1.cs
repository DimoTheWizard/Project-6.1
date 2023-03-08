using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            transactionsPage1.Hide();
            button4.Hide();
            //dataGridView1.Hide();
            label2.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            transactionsPage1.Hide();
            button4.Hide();
            //dataGridView1.Hide();
            label2.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            transactionsPage1.BringToFront();
            transactionsPage1.Show();
            button4.Show();
            button4.BringToFront();
            //dataGridView1.Show();
            //dataGridView1.BringToFront();
            label2.Show();
            label2.BringToFront();

            this.ApiCall();
            


        }

        private void transactionsPage2_Load(object sender, EventArgs e)
        {
            
        }
        
        private void ApiCall()
        {
            using (HttpClient client = new HttpClient())
            {
                var address = new Uri("https://v2.jokeapi.dev/joke/Pun?blacklistFlags=nsfw,political,racist,sexist,explicit&type=single&amount=2");
                var response = client.GetAsync(address).Result;
                var joke = response.Content.ReadAsAsync<Transactions>().Result;

                label2.Text = joke.Jokes[0].Joke;
                System.Console.WriteLine(joke.Error);
                System.Console.WriteLine(joke.Amount);
                System.Console.WriteLine(joke.Jokes[0].Joke);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            transactionsPage1.Hide();
            button4.Hide();
            //dataGridView1.Hide();
            label2.Hide();
            label2.Text = "";
        }

        private void transactionsPage1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
