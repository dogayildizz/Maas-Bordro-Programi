using CLMaasBordro.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAMaasBordroProgrami.UI
{
    public partial class MaasGuncelleme : Form
    {
        Memur memur = new Memur();
        public MaasGuncelleme()
        {
            InitializeComponent();

        }

        private void MaasGuncelleme_Load(object sender, EventArgs e)
        {
            cmbKadrolar.Items.Add("Memur");
            cmbKadrolar.Items.Add("Yönetici");
        }

        private void cmbKadrolar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbKadrolar.SelectedItem == "Memur")
            {
                txtMemurMaasBilgilendirme.Text = $"Memur sınıfının saatlik aldığı ücretler listesi aşağıda verilmiştir :\r\nYeni Başlayan ==> {memur.SaatlikUcret}\r\nDeneyimli==> \r\nYeni Başlayan ==> 500\r\nYeni Başlayan ==> 500\r\nYeni Başlayan ==> 500";
            }
            else if (cmbKadrolar.SelectedItem == "Yönetici")
            {

            }
            else
                return;
        }
    }
}
