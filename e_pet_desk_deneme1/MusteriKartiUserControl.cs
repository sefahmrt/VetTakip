using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    public partial class MusteriKartiUserControl : UserControl
    {
        public MusteriKartiUserControl()
        {
            InitializeComponent();
        }

        // Dışarıdan bu karta veri gönderebilmemizi sağlayan özellikler (Properties)
        public string AdSoyad
        {
            get { return lblAdSoyad.Text; }
            set { lblAdSoyad.Text = value; }
        }

        public string Telefon
        {
            get { return lblTelefon.Text; }
            set { lblTelefon.Text = value; }
        }

        public string Adres
        {
            get { return lblAdres.Text; }
            set { lblAdres.Text = value; }
        }
    }
}
