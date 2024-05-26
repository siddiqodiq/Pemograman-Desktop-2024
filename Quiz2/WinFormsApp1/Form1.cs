using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // Simpan username dan password hash (untuk contoh ini, kita gunakan hardcoded)
        private const string storedUsername = "admin";
        private const string storedPasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3"; // Hash dari "password"

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Hash password yang diinput
            string hashedPassword = ComputeSha256Hash(password);

            // Cek username dan hashed password
            if (username == storedUsername && hashedPassword == storedPasswordHash)
            {
                // Login berhasil
                MessageBox.Show("Login berhasil!");

                // Tampilkan form tambah produk
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                // Login gagal
                MessageBox.Show("Username atau password salah.");
            }
        }

        private string ComputeSha256Hash(string rawData)
        {
            // Buat SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - mengembalikan byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Konversi byte array menjadi string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
