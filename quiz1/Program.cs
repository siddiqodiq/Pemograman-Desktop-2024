using System;
using System.Xml;
using quiz1;

class Program
{
    static void Main(string[] args)
    {
        Toko toko = new Toko();

        User adminUser = new User("admin", "1234");

        List<Produk> MyProduk =
       [
        new("Buku Tuntunan Shalat", 20000, 25),
        new("Buku Siksa Kubur", 50000, 35),
        new("Buku Belajar Jetpack Compose", 120000, 45)
        ];
        foreach (var produk in MyProduk)
        {
            toko.TambahProduk(produk.Nama, produk.Harga, produk.Stok);
        }

        Console.WriteLine("Silakan login untuk melanjutkan.");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        if (username == adminUser.Username && password == adminUser.Password)
        {
            Console.WriteLine("Login berhasil.");

            bool lanjut = true;
            while (lanjut)
            {
                Console.WriteLine("  _        _           _           _          \r\n | |      | |         | |         | |         \r\n | |_ ___ | | _____   | |__  _   _| | ___   _ \r\n | __/ _ \\| |/ / _ \\  | '_ \\| | | | |/ / | | |\r\n | || (_) |   < (_) | | |_) | |_| |   <| |_| |\r\n  \\__\\___/|_|\\_\\___/  |_.__/ \\__,_|_|\\_\\\\__,_|\r\n                                              \r\n                                              ");
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Cari Produk");
                Console.WriteLine("2. Urutkan Produk berdasarkan Stok");
                Console.WriteLine("3. Tambah Produk");
                Console.WriteLine("4. Hapus Produk");
                Console.WriteLine("5. Keluar");

                Console.Write("\nMasukkan pilihan Anda: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Masukkan nama produk yang ingin dicari: ");
                        string nama = Console.ReadLine();
                        Console.Write("Masukkan harga minimum: ");
                        double minHarga = double.Parse(Console.ReadLine());
                        Console.Write("Masukkan harga maksimum: ");
                        double maxHarga = double.Parse(Console.ReadLine());
                        toko.CariProduk(nama, minHarga, maxHarga);
                        break;
                    case "2":
                        toko.UrutStok();
                        break;
                    case "3":
                        Console.Write("Masukkan nama produk: ");
                        string productName = Console.ReadLine();
                        Console.Write("Masukkan harga produk: ");
                        double harga = double.Parse(Console.ReadLine());
                        Console.Write("Masukkan stok produk: ");
                        int stok = int.Parse(Console.ReadLine());
                        toko.TambahProduk(productName, harga, stok);
                        Console.WriteLine($"Produk '{productName}' telah ditambahkan.");
                        break;
                    case "4":
                        Console.Write("Masukkan nama produk yang ingin dihapus: ");
                        string ProdukHapus = Console.ReadLine();
                        toko.HapusProduk(ProdukHapus);
                        break;
                    case "5":
                        Console.WriteLine("Keluar dari program. Sampai jumpa!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                        break;
                }
                Console.Write("\nApakah Anda ingin melanjutkan (ya/tidak)? ");
                string jawaban = Console.ReadLine();
                lanjut = (jawaban.ToLower() == "ya");
            }
        }
        else
        {
            Console.WriteLine("Username atau password salah. Keluar dari program.");
        }
    }
}
