using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz1
{
    internal class Produk(String nama, Double harga, int stok)
    {
        public String Nama { get; set; } = nama;
        public Double Harga { get; set;} = harga;
        public int Stok { get; set;}   = stok;
    }
}
