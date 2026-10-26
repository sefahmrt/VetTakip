using System;
using System.Data.SQLite;   // NuGet: System.Data.SQLite.Core
using System.IO;

namespace VetTakip
{
    /// <summary>
    /// Uygulamanın tek veritabanı: programın (exe'nin) yanındaki vettakip.db.
    /// vettakip.db projenin içinde durur ve "Copy to Output Directory = Copy if newer" olduğu için
    /// her derlemede bin\Debug klasörüne kopyalanır. Böylece git'ten projeyi çeken herkeste aynı veritabanı olur.
    ///
    /// Bütün ekranlar bağlantıyı buradan alır:
    ///     using (SQLiteConnection baglanti = Veritabani.Ac())
    ///     using (SQLiteCommand komut = new SQLiteCommand("SELECT ...", baglanti)) { ... }
    /// </summary>
    public static class Veritabani
    {
        /// <summary>Veritabanı dosyasının tam yolu (bin\Debug\vettakip.db).</summary>
        public static string DosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vettakip.db");

        public static string BaglantiCumlesi
        {
            get
            {
                var b = new SQLiteConnectionStringBuilder();
                b.DataSource = DosyaYolu;
                b.Version = 3;
                b.ForeignKeys = true;      // tablolar arası ilişkiler (REFERENCES) denetlensin
                b.FailIfMissing = true;    // dosya yoksa boş veritabanı oluşturup "no such table" hatası vermesin
                return b.ConnectionString;
            }
        }

        /// <summary>Açık bir bağlantı döndürür. using içinde kullanın.</summary>
        public static SQLiteConnection Ac()
        {
            if (!File.Exists(DosyaYolu))
                throw new FileNotFoundException(
                    "Veritabanı dosyası bulunamadı: " + DosyaYolu + Environment.NewLine +
                    "Çözüm: Solution Explorer'da vettakip.db dosyasının projede olduğunu ve özelliklerinde " +
                    "\"Copy to Output Directory\" = \"Copy if newer\" olduğunu kontrol edip projeyi yeniden derleyin (Rebuild).",
                    DosyaYolu);

            var baglanti = new SQLiteConnection(BaglantiCumlesi);
            baglanti.Open();
            return baglanti;
        }

        /// <summary>Veritabanı hatasını kullanıcıya gösterilecek anlaşılır bir Türkçe cümleye çevirir.</summary>
        public static string HataMetni(Exception ex)
        {
            Exception ic = ex;
            for (Exception x = ex; x != null; x = x.InnerException)
            {
                ic = x;
                if (x is DllNotFoundException || x is BadImageFormatException ||
                    x.Message.IndexOf("SQLite.Interop", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return "SQLite kütüphanesi yüklenemedi. Projeye sağ tıklayıp \"Manage NuGet Packages\" ekranında " +
                           "System.Data.SQLite.Core paketinin kurulu olduğunu kontrol edin, sonra Build > Rebuild Solution yapın." +
                           Environment.NewLine + "Ayrıntı: " + x.Message;
                }
            }
            if (ic is FileNotFoundException) return ic.Message;
            return "Veritabanı hatası: " + ic.Message.Replace("\r", " ").Replace("\n", " ");
        }
    }
}
