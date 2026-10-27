<div align="center">
<img src="docs/screenshots/vettakip.ico" width="10%"/>
  
# VetTakip

**Veteriner Klinik Takip Sistemi**

Randevuları, hasta sahiplerini ve hayvan kayıtlarını tek bir masaüstü uygulamasından yönetin.

🎓 *Üniversite dönem projesi olarak geliştirilmektedir.*

[![Sürüm](https://img.shields.io/badge/sürüm-v0.1--alpha-orange?style=for-the-badge)](https://github.com/sefahmrt/VetTakip/releases)
[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/platform-Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)](#-kurulum)

[📥 İndir](#-indir) • [✨ Özellikler](#-özellikler) • [📸 Ekran Görüntüleri](#-ekran-görüntüleri) • [🚀 Kurulum](#-kurulum) • [👥 Ekip](#-ekip)


</div>

---

## 📖 Hakkında

**VetTakip**, veteriner kliniklerinin günlük işleyişini kolaylaştırmak için geliştirilen bir Windows masaüstü uygulamasıdır. Günlük randevuları hekim bazlı takvimde görmenizi, hasta sahiplerinin ve hayvanlarının bilgilerini düzenli şekilde saklamanızı sağlar.

Bu proje, **Ondokuz Mayıs Üniversitesi Bafra MYO** **Bilgisayar Programcılığı** bölümü **Görsel Programlama-I** dersi kapsamında arkadaş grubumuzla birlikte geliştirilmektedir.

> ⚠️ **Not:** Proje şu anda **alpha** aşamasındadır. Bazı menüler henüz tamamlanmamıştır ve hatalarla karşılaşabilirsiniz.

## 📥 İndir

<div align="center">

[![İndir](https://img.shields.io/badge/⬇️%20VetTakip%20v0.1--alpha%20İndir-1f6feb?style=for-the-badge)](https://github.com/sefahmrt/VetTakip/releases/download/v0.1-alpha/VetTakip.v0.1-alpha.zip)

</div>

1. Yukarıdaki bağlantıdan `.zip` dosyasını indirin.
2. Klasöre çıkarın.
3. Çalıştırılabilir (`.exe`) dosyaya çift tıklayın.

## ✨ Özellikler

### 🔐 Giriş
- Kullanıcı adı ve şifre ile giriş paneli
- Şifreyi göster/gizle seçeneği
- Rol bilgisi (Admin) ile oturum açma

### 📊 Ana Sayfa (Dashboard)
- **Bugünkü randevular** ve tamamlanan sayısı
- **Bekleme salonundaki** hasta sayısı ve ortalama bekleme süresi
- **Yatan hasta** doluluğu (kafes kapasitesi)
- **Kalan SMS (mesaj) hakkı**
- Günün randevularını saat, hayvan, sahip, işlem, hekim ve durum bilgisiyle listeleme

### 📅 Randevular
- Hekim bazlı sütunlarla **günlük takvim görünümü**
- Önceki / sonraki gün ve **"Bugün"** ile hızlı gezinme
- Yeni randevu oluşturma: hasta sahibi, hekim, tarih, başlangıç saati, süre ve işlem/not
- Randevu durumları (Bekliyor, İptal vb.) ve iptal edilen randevuların ayrı görünümü

### 👤 Hasta Sahipleri
- Sahip listesi: ad soyad, telefon, il/ilçe, hayvan sayısı ve SMS izni
- Arama yapma
- Yeni sahip ekleme: ad, soyad, telefon, TC kimlik, e-posta, il/ilçe, adres, acil durum kişisi ve SMS izni
- Sahip detay paneli: müşteri no, kayıt tarihi, KVKK onayı, not
- Düzenle, SMS gönder ve pasife alma işlemleri
- Sahibe ait **Hayvanlar**, **Ziyaretler** ve **Mesaj Geçmişi** sekmeleri

### 🐶 Hayvan Kayıtları
- Sahibin detay panelinden hızlıca hayvan ekleme
- Ad, tür, ırk, cinsiyet, doğum tarihi, renk ve mikroçip numarası
- Kısır ve agresif durum işaretleri
- Hayvan kartı ile yaş, ırk, çip ve ziyaret durumunu görüntüleme

## 📸 Ekran Görüntüleri

<div align="center">

| Giriş | Ana Sayfa |
|:---:|:---:|
| <img src="docs/screenshots/Giriş.png" alt="Giriş" /> | <img src="docs/screenshots/AnaSayfa.png" alt="Ana Sayfa" /> |

| Randevular | Randevu Oluştur |
|:---:|:---:|
| <img src="docs/screenshots/Randevular.png" alt="Randevular" /> | <img src="docs/screenshots/RandevuEkle.png" alt="Randevu Oluştur" /> |

| Hasta Sahipleri | Yeni Sahip Ekle |
|:---:|:---:|
| <img src="docs/screenshots/Sahipler.png" alt="Hasta Sahipleri" /> | <img src="docs/screenshots/SahipEkle.png" alt="Yeni Sahip Ekle" /> |

| Hayvan Ekle |
|:---:|
| <img src="docs/screenshots/HayvanEkle.png" alt="Hayvan Ekle" width="50%" /> |

</div>

## 🛠️ Teknolojiler

- **Dil:** C#
- **Platform:** .NET (Windows masaüstü uygulaması)
- **IDE:** Visual Studio 2022+

<!-- Arayüz kütüphanesi (WinForms / WPF vb.) ve veritabanını buraya ekleyin -->

## 🚀 Kurulum

Projeyi kaynak koddan çalıştırmak için:

### Gereksinimler

- Windows 10 / 11
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya güncel sürüm

### Adımlar

```bash
# 1. Depoyu klonlayın
git clone https://github.com/sefahmrt/VetTakip.git

# 2. Proje klasörüne girin
cd VetTakip

# 3. Bağımlılıkları yükleyin
dotnet restore

# 4. Derleyin ve çalıştırın
dotnet run --project VetTakip
```

Alternatif olarak `VetTakip.slnx` dosyasını Visual Studio ile açıp **F5** tuşuna basabilirsiniz.

## 📂 Proje Yapısı

```
VetTakip/
├── VetTakip/          # Uygulama kaynak kodu
├── docs/screenshots/  # README görselleri
├── VetTakip.slnx      # Visual Studio çözüm dosyası
├── .gitattributes
├── .gitignore
└── README.md
```

## 🗺️ Yol Haritası

- [x] Giriş paneli
- [x] Ana sayfa (dashboard)
- [x] Randevu takvimi ve randevu oluşturma
- [x] Hasta sahibi yönetimi
- [x] Hayvan ekleme
- [ ] Hayvanlar sayfası
- [ ] Muayene geçmişi
- [ ] Yataklı hasta takibi
- [ ] Mesajlar (SMS gönderimi)
- [ ] Hatırlatma
- [ ] Takvim
- [ ] Ayarlar

<!-- Tamamlanan maddeleri [x] yaparak güncel tutun -->

## 👥 Ekip

<!-- Ekip arkadaşlarınızın bilgilerini ekleyin -->

| Üye | Rol | GitHub |
|---|---|---|
| **Sefa Hamarat** | Geliştirici | [@sefahmrt](https://github.com/sefahmrt) |
| **Yunus Emre Kirli** | Geliştirici | [@acemividyolar-alt](https://github.com/acemividyolar-alt) |
| **--** | Geliştirici | [@--](https://github.com) |

## 🤝 Katkıda Bulunma

1. Projeyi **fork**'layın
2. Yeni bir dal oluşturun: `git checkout -b ozellik/yeni-ozellik`
3. Değişikliklerinizi commit'leyin: `git commit -m "Yeni özellik eklendi"`
4. Dalı gönderin: `git push origin ozellik/yeni-ozellik`
5. Bir **Pull Request** açın

## 🐞 Hata Bildirimi

Bir hata mı buldunuz? [Yeni bir issue açın](https://github.com/sefahmrt/VetTakip/issues/new) ve hatanın açıklamasını, tekrar üretme adımlarını ve varsa ekran görüntüsünü ekleyin.

## 📄 Lisans

<!-- LICENSE dosyası eklediğinizde burayı güncelleyin -->

Bu proje için henüz bir lisans belirtilmemiştir.

---

<div align="center">

Projeyi beğendiyseniz ⭐ vermeyi unutmayın!

</div>
