using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    public partial class Randevular : UserControl
    {
        public Randevular()
        {
            InitializeComponent();

            // Randevu takvimi bu panelin içinde, ana pencerede açılır (ayrı pencere değil).
            Controls.Add(new RandevuEkrani { Dock = DockStyle.Fill });
        }
    }
}