using System;
using System.Collections.Generic;
using System.Data.SQLite;   // NuGet: System.Data.SQLite.Core
using System.Drawing;
using System.Globalization;

namespace e_pet_desk_deneme1
{
    /// <summary>
    /// Takvimin veritabanı işleri: hekimler, bir günün randevuları, çakışma kontrolü, yeni randevu.
    /// Bağlantıyı Veritabani.Ac() verir (exe'nin yanındaki vettakip.db).
    /// Saatler veritabanında 'yyyy-MM-dd HH:mm' biçiminde metin olarak durur, ör. '2026-10-26 09:30'.
    /// </summary>
    public static class RandevuVeri
    {
        private const string Bicim = "yyyy-MM-dd HH:mm";
        private static string Metin(DateTime t) { return t.ToString(Bicim, CultureInfo.InvariantCulture); }
        private static DateTime Zaman(string s) { return DateTime.ParseExact(s, Bicim, CultureInfo.InvariantCulture); }

        /// <summary>Takvimdeki sütunlar: aktif hekimler, sıraya göre.</summary>
        public static List<TakvimHekim> HekimleriGetir()
        {
            var liste = new List<TakvimHekim>();
            using (SQLiteConnection baglanti = Veritabani.Ac())
            using (var komut = new SQLiteCommand("SELECT id, ad, renk FROM hekim WHERE aktif = 1 ORDER BY sira, ad", baglanti))
            using (SQLiteDataReader oku = komut.ExecuteReader())
            {
                while (oku.Read())
                    liste.Add(new TakvimHekim(Convert.ToInt32(oku["id"]), oku["ad"].ToString(), ColorTranslator.FromHtml(oku["renk"].ToString())));
            }
            return liste;
        }

        /// <summary>Randevu formundaki hasta listesi: "Pamuk (Zeynep Arslan)" biçiminde, Id ile birlikte.</summary>
        public static List<KeyValuePair<int, string>> HastalariGetir()
        {
            var liste = new List<KeyValuePair<int, string>>();
            const string sorgu =
                "SELECT h.id, h.ad, COALESCE(m.ad || ' ' || m.soyad, '-') AS sahip " +
                "FROM hasta h LEFT JOIN musteri m ON m.id = h.musteri_id " +
                "ORDER BY h.ad, m.ad";
            using (SQLiteConnection baglanti = Veritabani.Ac())
            using (var komut = new SQLiteCommand(sorgu, baglanti))
            using (SQLiteDataReader oku = komut.ExecuteReader())
            {
                while (oku.Read())
                    liste.Add(new KeyValuePair<int, string>(Convert.ToInt32(oku["id"]), oku["ad"] + " (" + oku["sahip"] + ")"));
            }
            return liste;
        }

        /// <summary>Verilen günün randevuları (gece yarısını aşanlar dahil).</summary>
        public static List<TakvimRandevu> GunuGetir(DateTime gun)
        {
            var liste = new List<TakvimRandevu>();
            const string sorgu =
                "SELECT r.id, r.hekim_id, r.baslangic, r.bitis, " +
                "       COALESCE(h.ad, 'Hasta #' || r.hasta_id) AS hayvan, " +
                "       COALESCE(m.ad || ' ' || m.soyad, '-') AS sahip, r.islem, r.durum " +
                "FROM randevu r " +
                "LEFT JOIN hasta h ON h.id = r.hasta_id " +          // hasta silinmiş olsa da randevu görünsün
                "LEFT JOIN musteri m ON m.id = h.musteri_id " +
                "WHERE r.baslangic < @gunSonu AND r.bitis > @gunBasi " +
                "ORDER BY r.baslangic";
            using (SQLiteConnection baglanti = Veritabani.Ac())
            using (var komut = new SQLiteCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@gunBasi", Metin(gun.Date));
                komut.Parameters.AddWithValue("@gunSonu", Metin(gun.Date.AddDays(1)));
                using (SQLiteDataReader oku = komut.ExecuteReader())
                {
                    while (oku.Read())
                    {
                        string durum = oku["durum"].ToString();
                        liste.Add(new TakvimRandevu
                        {
                            Id = Convert.ToInt32(oku["id"]),
                            HekimId = Convert.ToInt32(oku["hekim_id"]),
                            Baslangic = Zaman(oku["baslangic"].ToString()),
                            Bitis = Zaman(oku["bitis"].ToString()),
                            Baslik = oku["hayvan"] + " (" + oku["sahip"] + ")",              // "Pamuk (Zeynep Arslan)"
                            Aciklama = oku["islem"] == DBNull.Value ? null : oku["islem"].ToString(),   // "Kuduz aşısı"
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
            const string sorgu =
                "SELECT COUNT(*) FROM randevu " +
                "WHERE hekim_id = @hekim AND id <> @haric AND durum <> 'İptal' " +
                "AND baslangic < @bitis AND bitis > @baslangic";
            using (SQLiteConnection baglanti = Veritabani.Ac())
            using (var komut = new SQLiteCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@hekim", hekimId);
                komut.Parameters.AddWithValue("@haric", haricId);
                komut.Parameters.AddWithValue("@baslangic", Metin(baslangic));
                komut.Parameters.AddWithValue("@bitis", Metin(bitis));
                return Convert.ToInt64(komut.ExecuteScalar()) > 0;
            }
        }

        /// <summary>Yeni randevu ekler ve kimliğini döndürür. Çakışma varsa hata fırlatır.</summary>
        public static long RandevuEkle(int hastaId, int hekimId, DateTime baslangic, DateTime bitis, string islem)
        {
            if (bitis <= baslangic) throw new ArgumentException("Bitiş saati başlangıçtan sonra olmalı.");
            if (CakismaVar(hekimId, baslangic, bitis)) throw new InvalidOperationException("Hekimin bu saatte başka bir randevusu var.");

            const string sorgu =
                "INSERT INTO randevu (hasta_id, hekim_id, baslangic, bitis, islem) " +
                "VALUES (@hasta, @hekim, @baslangic, @bitis, @islem); SELECT last_insert_rowid();";
            using (SQLiteConnection baglanti = Veritabani.Ac())
            using (var komut = new SQLiteCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@hasta", hastaId);
                komut.Parameters.AddWithValue("@hekim", hekimId);
                komut.Parameters.AddWithValue("@baslangic", Metin(baslangic));
                komut.Parameters.AddWithValue("@bitis", Metin(bitis));
                komut.Parameters.AddWithValue("@islem", string.IsNullOrWhiteSpace(islem) ? (object)DBNull.Value : islem.Trim());
                return Convert.ToInt64(komut.ExecuteScalar());
            }
        }

        /// <summary>Durumu değiştirir: 'Bekliyor', 'Geldi', 'Tamamlandı', 'Gelmedi' ya da 'İptal'.</summary>
        public static void DurumDegistir(int randevuId, string durum)
        {
            using (SQLiteConnection baglanti = Veritabani.Ac())
            using (var komut = new SQLiteCommand("UPDATE randevu SET durum = @durum WHERE id = @id", baglanti))
            {
                komut.Parameters.AddWithValue("@durum", durum);
                komut.Parameters.AddWithValue("@id", randevuId);
                komut.ExecuteNonQuery();
            }
        }
    }
}