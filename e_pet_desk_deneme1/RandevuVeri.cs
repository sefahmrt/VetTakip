using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Microsoft.Data.Sqlite;   // NuGet: Microsoft.Data.Sqlite

namespace e_pet_desk_deneme1   // Kendi projenizin namespace'i ile değiştirin
{
    /// <summary>
    /// Takvimin veritabanı işleri: hekimler, bir günün randevuları, çakışma kontrolü, yeni randevu.
    /// Tablolar randevu_tablolari.sql dosyasında.
    /// </summary>
    public static class RandevuVeri
    {
        public static string BaglantiCumlesi = "Data Source=vettakip.db;Foreign Keys=True";

        private const string Bicim = "yyyy-MM-dd HH:mm";   // veritabanındaki saat biçimi
        private static string Metin(DateTime t) { return t.ToString(Bicim, CultureInfo.InvariantCulture); }
        private static DateTime Zaman(string s) { return DateTime.ParseExact(s, Bicim, CultureInfo.InvariantCulture); }

        private static SqliteConnection Ac()
        {
            var baglanti = new SqliteConnection(BaglantiCumlesi);
            baglanti.Open();
            return baglanti;
        }

        // ------------------------------------------------------------ kurulum ve örnek kayıtlar

        // randevu_tablolari.sql ile aynı tablolar; "IF NOT EXISTS" sayesinde varsa dokunulmaz
        private const string TablolarSql =
            "CREATE TABLE IF NOT EXISTS hekim (" +
            "  id INTEGER PRIMARY KEY," +
            "  ad TEXT NOT NULL," +
            "  renk TEXT NOT NULL DEFAULT '#0F766E' CHECK (renk GLOB '#[0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f][0-9A-Fa-f]')," +
            "  sira INTEGER NOT NULL DEFAULT 0," +
            "  aktif INTEGER NOT NULL DEFAULT 1 CHECK (aktif IN (0, 1)));" +
            "CREATE TABLE IF NOT EXISTS randevu (" +
            "  id INTEGER PRIMARY KEY," +
            "  hasta_id INTEGER NOT NULL REFERENCES hasta (id) ON DELETE RESTRICT," +
            "  hekim_id INTEGER NOT NULL REFERENCES hekim (id) ON DELETE RESTRICT," +
            "  baslangic TEXT NOT NULL CHECK (strftime('%Y-%m-%d %H:%M', baslangic) IS baslangic)," +
            "  bitis TEXT NOT NULL CHECK (strftime('%Y-%m-%d %H:%M', bitis) IS bitis AND bitis > baslangic)," +
            "  islem TEXT," +
            "  durum TEXT NOT NULL DEFAULT 'Bekliyor' CHECK (durum IN ('Bekliyor', 'Geldi', 'Tamamlandı', 'Gelmedi', 'İptal'))," +
            "  notlar TEXT," +
            "  kayit_tarihi TEXT NOT NULL DEFAULT (datetime('now', 'localtime')));" +
            "CREATE INDEX IF NOT EXISTS ix_randevu_hekim ON randevu (hekim_id, baslangic);" +
            "CREATE INDEX IF NOT EXISTS ix_randevu_hasta ON randevu (hasta_id);";

        private static void Calistir(SqliteConnection b, string sql)
        {
            using (var k = b.CreateCommand()) { k.CommandText = sql; k.ExecuteNonQuery(); }
        }
        private static long Sayi(SqliteConnection b, string sql)
        {
            using (var k = b.CreateCommand()) { k.CommandText = sql; return Convert.ToInt64(k.ExecuteScalar()); }
        }
        private static List<int> Kimlikler(SqliteConnection b, string sql)
        {
            var liste = new List<int>();
            using (var k = b.CreateCommand())
            {
                k.CommandText = sql;
                using (var oku = k.ExecuteReader()) while (oku.Read()) liste.Add(oku.GetInt32(0));
            }
            return liste;
        }
        private static bool TabloVar(SqliteConnection b, string tablo)
        {
            using (var k = b.CreateCommand())
            {
                k.CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = $ad";
                k.Parameters.AddWithValue("$ad", tablo);
                return Convert.ToInt64(k.ExecuteScalar()) > 0;
            }
        }

        /// <summary>hekim ve randevu tabloları yoksa kurar. Var olan tablolara ve kayıtlara dokunmaz.</summary>
        public static void TablolariHazirla()
        {
            using (var b = Ac()) Calistir(b, TablolarSql);
        }

        /// <summary>
        /// Deneme için örnek kayıtlar: hiç hekim yoksa 3 hekim, hiç randevu yoksa bugüne 6 randevu ekler.
        /// Randevu bir hastaya bağlı olduğundan hasta tablosunda hiç kayıt yoksa örnek bir sahip ve hayvan da ekler.
        /// Gerçek veriler girildikten sonra hiçbir şey eklemez. Dönen metin ne yapıldığını anlatır.
        /// </summary>
        public static string OrnekKayitlariEkle()
        {
            var yapilan = new List<string>();
            using (var b = Ac())
            {
                Calistir(b, TablolarSql);
                if (Sayi(b, "SELECT COUNT(*) FROM hekim") == 0)
                {
                    Calistir(b, "INSERT INTO hekim (ad, renk, sira) VALUES " +
                                "('Dr. Elif Kaya', '#0F766E', 1), ('Dr. Can Yıldız', '#2563EB', 2), ('Dr. Deniz Aydın', '#7C3AED', 3)");
                    yapilan.Add("3 örnek hekim");
                }
                if (Sayi(b, "SELECT COUNT(*) FROM randevu") > 0) return Ozet(yapilan);

                if (!TabloVar(b, "hasta") || !TabloVar(b, "musteri"))
                    throw new InvalidOperationException("Veritabanında hasta ve musteri tabloları yok. Önce veteriner_tablolar.sql dosyasını çalıştırın.");
                if (Sayi(b, "SELECT COUNT(*) FROM hasta") == 0)
                {
                    // veteriner_tablolar.sql'deki yapıya göre örnek bir sahip ve hayvan
                    if (Sayi(b, "SELECT COUNT(*) FROM tur") == 0) Calistir(b, "INSERT INTO tur (ad) VALUES ('Kedi')");
                    Calistir(b, "INSERT INTO musteri (ad, soyad, tel) VALUES ('Örnek', 'Sahip', '05000000099')");
                    Calistir(b, "INSERT INTO hasta (musteri_id, ad, tur_id, cinsiyet) " +
                                "VALUES (last_insert_rowid(), 'Pamuk', (SELECT MIN(id) FROM tur), 'Dişi')");
                    yapilan.Add("1 örnek hasta");
                }

                List<int> hastalar = Kimlikler(b, "SELECT id FROM hasta ORDER BY id LIMIT 3");
                List<int> hekimler = Kimlikler(b, "SELECT id FROM hekim WHERE aktif = 1 ORDER BY sira, id LIMIT 3");
                string g = DateTime.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                var ornekler = new[]
                {
                    new { Hekim = 0, Bas = "09:30", Bit = "10:00", Islem = "Kontrol muayenesi", Durum = "Bekliyor" },
                    new { Hekim = 0, Bas = "10:00", Bit = "11:00", Islem = "Karma aşı", Durum = "Bekliyor" },
                    new { Hekim = 1, Bas = "10:00", Bit = "11:00", Islem = "Kısırlaştırma ön muayene", Durum = "Geldi" },
                    new { Hekim = 1, Bas = "13:00", Bit = "15:00", Islem = "Kısırlaştırma ameliyatı", Durum = "Bekliyor" },
                    new { Hekim = 2, Bas = "11:30", Bit = "12:00", Islem = "Tırnak kesimi", Durum = "İptal" },
                    new { Hekim = 2, Bas = "14:00", Bit = "14:30", Islem = "Aşı karnesi kontrolü", Durum = "Bekliyor" }
                };
                int i = 0;
                foreach (var o in ornekler)
                {
                    using (var k = b.CreateCommand())
                    {
                        k.CommandText = "INSERT INTO randevu (hasta_id, hekim_id, baslangic, bitis, islem, durum) " +
                                        "VALUES ($hasta, $hekim, $bas, $bit, $islem, $durum)";
                        k.Parameters.AddWithValue("$hasta", hastalar[i++ % hastalar.Count]);
                        k.Parameters.AddWithValue("$hekim", hekimler[o.Hekim % hekimler.Count]);
                        k.Parameters.AddWithValue("$bas", g + " " + o.Bas);
                        k.Parameters.AddWithValue("$bit", g + " " + o.Bit);
                        k.Parameters.AddWithValue("$islem", o.Islem);
                        k.Parameters.AddWithValue("$durum", o.Durum);
                        k.ExecuteNonQuery();
                    }
                }
                yapilan.Add("bugüne " + ornekler.Length + " örnek randevu");
            }
            return Ozet(yapilan);
        }

        private static string Ozet(List<string> yapilan)
        {
            return yapilan.Count == 0 ? "" : "Eklendi: " + string.Join(", ", yapilan) + ".";
        }

        /// <summary>Takvimdeki sütunlar: aktif hekimler, sıraya göre.</summary>
        public static List<TakvimHekim> HekimleriGetir()
        {
            var liste = new List<TakvimHekim>();
            using (var baglanti = Ac())
            using (var komut = baglanti.CreateCommand())
            {
                komut.CommandText = "SELECT id, ad, renk FROM hekim WHERE aktif = 1 ORDER BY sira, ad";
                using (var oku = komut.ExecuteReader())
                    while (oku.Read())
                        liste.Add(new TakvimHekim(oku.GetInt32(0), oku.GetString(1), ColorTranslator.FromHtml(oku.GetString(2))));
            }
            return liste;
        }

        /// <summary>Verilen günün randevuları (gece yarısını aşanlar dahil).</summary>
        public static List<TakvimRandevu> GunuGetir(DateTime gun)
        {
            var liste = new List<TakvimRandevu>();
            using (var baglanti = Ac())
            using (var komut = baglanti.CreateCommand())
            {
                komut.CommandText =
                    "SELECT r.id, r.hekim_id, r.baslangic, r.bitis, " +
                    "COALESCE(h.ad, 'Hasta #' || r.hasta_id), COALESCE(m.ad || ' ' || m.soyad, '-'), r.islem, r.durum " +
                    "FROM randevu r " +
                    "LEFT JOIN hasta h ON h.id = r.hasta_id " +          // hasta silinmiş olsa da randevu görünsün
                    "LEFT JOIN musteri m ON m.id = h.musteri_id " +
                    "WHERE r.baslangic < $gunSonu AND r.bitis > $gunBasi " +
                    "ORDER BY r.baslangic";
                komut.Parameters.AddWithValue("$gunBasi", Metin(gun.Date));
                komut.Parameters.AddWithValue("$gunSonu", Metin(gun.Date.AddDays(1)));
                using (var oku = komut.ExecuteReader())
                {
                    while (oku.Read())
                    {
                        string durum = oku.GetString(7);
                        liste.Add(new TakvimRandevu
                        {
                            Id = oku.GetInt32(0),
                            HekimId = oku.GetInt32(1),
                            Baslangic = Zaman(oku.GetString(2)),
                            Bitis = Zaman(oku.GetString(3)),
                            Baslik = oku.GetString(4) + " (" + oku.GetString(5) + ")",   // "Pamuk (Zeynep Arslan)"
                            Aciklama = oku.IsDBNull(6) ? null : oku.GetString(6),        // "Kuduz aşısı"
                            Soluk = durum == "İptal" || durum == "Gelmedi",
                            Etiket = durum
                        });
                    }
                }
            }
            return liste;
        }

        /// <summary>Hekimin bu saatlerde iptal edilmemiş başka randevusu var mı? (düzenlemede haricId = randevunun kendisi)</summary>
        public static bool CakismaVar(int hekimId, DateTime baslangic, DateTime bitis, int haricId = 0)
        {
            using (var baglanti = Ac())
            using (var komut = baglanti.CreateCommand())
            {
                komut.CommandText =
                    "SELECT COUNT(*) FROM randevu " +
                    "WHERE hekim_id = $hekim AND id <> $haric AND durum <> 'İptal' " +
                    "AND baslangic < $bitis AND bitis > $baslangic";
                komut.Parameters.AddWithValue("$hekim", hekimId);
                komut.Parameters.AddWithValue("$haric", haricId);
                komut.Parameters.AddWithValue("$baslangic", Metin(baslangic));
                komut.Parameters.AddWithValue("$bitis", Metin(bitis));
                return Convert.ToInt64(komut.ExecuteScalar()) > 0;
            }
        }

        /// <summary>Yeni randevu ekler ve kimliğini döndürür. Çakışma varsa hata fırlatır.</summary>
        public static long RandevuEkle(int hastaId, int hekimId, DateTime baslangic, DateTime bitis, string islem)
        {
            if (bitis <= baslangic) throw new ArgumentException("Bitiş saati başlangıçtan sonra olmalı.");
            if (CakismaVar(hekimId, baslangic, bitis)) throw new InvalidOperationException("Hekimin bu saatte başka bir randevusu var.");
            using (var baglanti = Ac())
            using (var komut = baglanti.CreateCommand())
            {
                komut.CommandText =
                    "INSERT INTO randevu (hasta_id, hekim_id, baslangic, bitis, islem) " +
                    "VALUES ($hasta, $hekim, $baslangic, $bitis, $islem); SELECT last_insert_rowid();";
                komut.Parameters.AddWithValue("$hasta", hastaId);
                komut.Parameters.AddWithValue("$hekim", hekimId);
                komut.Parameters.AddWithValue("$baslangic", Metin(baslangic));
                komut.Parameters.AddWithValue("$bitis", Metin(bitis));
                komut.Parameters.AddWithValue("$islem", string.IsNullOrWhiteSpace(islem) ? (object)DBNull.Value : islem.Trim());
                return Convert.ToInt64(komut.ExecuteScalar());
            }
        }

        /// <summary>Durumu değiştirir: 'Bekliyor', 'Geldi', 'Tamamlandı', 'Gelmedi' ya da 'İptal'.</summary>
        public static void DurumDegistir(int randevuId, string durum)
        {
            using (var baglanti = Ac())
            using (var komut = baglanti.CreateCommand())
            {
                komut.CommandText = "UPDATE randevu SET durum = $durum WHERE id = $id";
                komut.Parameters.AddWithValue("$durum", durum);
                komut.Parameters.AddWithValue("$id", randevuId);
                komut.ExecuteNonQuery();
            }
        }
    }
}
