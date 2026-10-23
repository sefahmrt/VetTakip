using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    internal static class Program
    {
        /// <summary>
        /// true: önce giriş ekranı açılır, doğru kullanıcı adı/şifre girilince ana form gelir.
        /// false: geliştirirken giriş ekranı atlanır, doğrudan ana form açılır.
        /// (Eskiden bunun için Application.Run(new GirisForm()) / Application.Run(new AnaForm()) satırı değiştiriliyordu.)
        /// </summary>
        private static readonly bool GirisEkraniGosterilsin = false;

        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (GirisEkraniGosterilsin)
            {
                using (GirisForm giris = new GirisForm())
                {
                    if (giris.ShowDialog() != DialogResult.OK) return;   // giriş yapılmadan kapatıldı: programdan çık
                }
            }
            Application.Run(new AnaForm());
        }
    }
}
