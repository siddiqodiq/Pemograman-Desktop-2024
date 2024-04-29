using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace quiz1
{
    public class Toko
    {
        private List<Produk> produkList;

        public Toko()
        {
            produkList = new List<Produk>();
        }

        public void TambahProduk(String nama, double harga, int stok)
        {
            produkList.Add(new Produk(nama, harga, stok));
        }

        public void HapusProduk(string nama)
        {
            Produk ProdukHapus = produkList.FirstOrDefault( p => p.Nama.Equals(nama, StringComparison.OrdinalIgnoreCase) );
            if (ProdukHapus != null)
            {
                produkList.Remove(ProdukHapus);
                Console.WriteLine($"Produk '{nama}' sudah di hapus.");
            }
            else
            {
                Console.WriteLine($"Produk '{nama}' tidak ditemukan.");
            }
        }
        public void CariProduk(string nama, double minHarga, double maxHarga)
        {
            var FilterProduk = produkList.Where(p => p.Nama.Contains(nama, StringComparison.OrdinalIgnoreCase)
                                                    && p.Harga >= minHarga && p.Harga <= maxHarga);
            if (FilterProduk.Any())
            {
                Console.WriteLine("Hasil Pencarian:");
                foreach (var produk in FilterProduk)
                {
                    Console.WriteLine($"Nama: {produk.Nama}\nHarga: Rp.{produk.Harga}\nStok: {produk.Stok}\n-------------------\n");
                }
            }
            else
            {
                Console.WriteLine("Tidak ditemukan.");
            }
        }
        public void UrutStok()
        {
            var UrutProduk = produkList.OrderBy(p => p.Stok);
            Console.WriteLine("Daftar produk berdasarkan stok:");
            foreach (var produk in UrutProduk)
            {
                Console.WriteLine($"Nama: {produk.Nama}\nHarga: Rp.{produk.Harga}\nStok: {produk.Stok}\n-----------------------\n");
            }
        }
    }
}
