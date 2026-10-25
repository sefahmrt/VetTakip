using System;
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

        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var giris = new AnaForm())
            {
                if (giris.ShowDialog() != DialogResult.OK) return;
            }
            Application.Run(new AnaForm());
        }
    }
}
