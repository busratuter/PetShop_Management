using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VeterinerOtomasyon
{
    public partial class Homes : Form
    {
        public Homes()
        {
            InitializeComponent();
            CountDogs();
            CountBirds();
            CountCats();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\busra\Documents\PetshopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void CountDogs()
        {
            string Cat = "Dog";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DogsLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void CountBirds()
        {
            string Cat = "Bird";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BirdsLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void CountCats()
        {
            string Cat = "Cat";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CatsLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Products Obj = new Products();
            Obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
            Obj.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Homes_Load(object sender, EventArgs e)
        {

        }


        private void label6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
            Obj.Show();
            this.Hide();
        }

        
        private void UpdateChart()
        {
            // Grafikteki mevcut verileri temizleyin.
            chart1.Series.Clear();

            // Kedi, köpek ve kuş sayılarını veritabanından çekin.
            int catCount = Convert.ToInt32(CountAnimals("Cat"));
            int dogCount = Convert.ToInt32(CountAnimals("Dog"));
            int birdCount = Convert.ToInt32(CountAnimals("Bird"));

            // Serileri oluşturun.
            Series series = chart1.Series.Add("Animals");
            series.ChartType = SeriesChartType.Pie;

            // Verileri serilere ekleyin.
            series.Points.AddXY("Cats", catCount);
            series.Points.AddXY("Dogs", dogCount);
            series.Points.AddXY("Birds", birdCount);
        }

        private string CountAnimals(string category)
        {
            string query = $"Select Count(*) from ProductTbl where PrCat='{category}'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt.Rows[0][0].ToString();
        }


        private void chart1_Click_1(object sender, EventArgs e)
        {
            UpdateChart();
        }


    }
}
