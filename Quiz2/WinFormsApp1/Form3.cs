using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        private List<Product> products;

        public Form3()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {


            string csvFilePath = "products.csv";

            if (File.Exists(csvFilePath))
            {
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    products = csv.GetRecords<Product>().ToList();
                    dataGridView1.DataSource = products;
                }
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select a Product Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = openFileDialog.FileName;
            }
        }

      

        private void textBox6_TextChanged(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string searchText = textBox6.Text.ToLower();
            var filteredProducts = products.Where(p => p.Name.ToLower().Contains(searchText)).ToList();
            dataGridView1.DataSource = filteredProducts;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedProduct = (Product)dataGridView1.SelectedRows[0].DataBoundItem;
                selectedProduct.Id = textBox1.Text;
                selectedProduct.Name = textBox2.Text;
                selectedProduct.Price = textBox3.Text;
                selectedProduct.Stock = textBox4.Text;
                selectedProduct.PhotoPath = textBox5.Text;

                SaveProducts();
                LoadProducts();
            }
            else
            {
                MessageBox.Show("Pilih produk yang ada pada tabel.");
            }
        }
        private void SaveProducts()
        {
            string csvFilePath = "products.csv";

            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(products);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedProduct = (Product)dataGridView1.SelectedRows[0].DataBoundItem;
                textBox1.Text = selectedProduct.Id;
                textBox2.Text = selectedProduct.Name;
                textBox3.Text = selectedProduct.Price;
                textBox4.Text = selectedProduct.Stock;
                textBox5.Text = selectedProduct.PhotoPath;

                if (File.Exists(selectedProduct.PhotoPath))
                {
                    pictureBox1.Image = Image.FromFile(selectedProduct.PhotoPath);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select a Product Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = openFileDialog.FileName;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
