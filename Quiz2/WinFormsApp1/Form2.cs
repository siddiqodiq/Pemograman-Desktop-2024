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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            string price = textBox3.Text;
            string stock = textBox4.Text;
            string photoPath = textBox5.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(price) ||
                string.IsNullOrEmpty(stock) || string.IsNullOrEmpty(photoPath))
            {
                MessageBox.Show("Penuhi semua kolom");
                return;
            }

            // Path ke file CSV
            string csvFilePath = "products.csv";

            // Buat daftar produk untuk disimpan
            var products = new List<Product>
            {
                new Product { Id = id, Name = name, Price = price, Stock = stock, PhotoPath = photoPath }
            };

            // Simpan data produk ke file CSV
            using (var writer = new StreamWriter(csvFilePath, true))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = !File.Exists(csvFilePath) }))
            {
                csv.WriteRecords(products);
            }

            MessageBox.Show("Produk berhasil disimpan!");
            ClearFields();
        }
        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 formEditProduct = new Form3();
            formEditProduct.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
