using CLMaasBordro;
using CLMaasBordro.Data;
using CLMaasBordro.Enum;
using CLMaasBordro.Models;
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
    public partial class YoneticiIslemleri : Form
    {
        bool cellClickEdildiMi = false; //Kullanıcı datagride tıkladığında true ya dönüyor. UI paketinden kaynaklı oluşan hataların önüne geçmek için tanımlandı.
        List<Yonetici> yoneticiler = new List<Yonetici>();
        public bool BilgilerGecerliMi() //Kullanıcının girdiği veriler, geçerli veriler mi kontrolü yapan metot
        {
            bool bilgilerGecerliMi = true;
            if (txtYoneticiAdSoyad.Text == string.Empty || txtYoneticiCalismaSaati.Text == string.Empty || String.IsNullOrWhiteSpace(txtYoneticiAdSoyad.Text))
            {
                bilgilerGecerliMi = false;
                MessageBox.Show("Lütfen tüm bilgileri girdiğinizden emin olun!");
                return bilgilerGecerliMi;
            }
            if (!Kontrol.AdSoyadMi(txtYoneticiAdSoyad.Text) || !Kontrol.CalismaSaatiMi(txtYoneticiCalismaSaati.Text))
            {
                bilgilerGecerliMi = false;
                MessageBox.Show("Tüm bilgileri doğru girdiğinizden emin olun!");
                return bilgilerGecerliMi;
            }

            return bilgilerGecerliMi;
        }
        public void ListeVeJsonGuncelle() //Kullanıcının seçtiği personeli, yazdığı yeni bilgiler ile yoneticiler listesinde günceller, güncel listeyi Jsona yazar.
        {
            Yonetici secilenYonetici = new Yonetici();
            secilenYonetici.AdSoyad = dgvYoneticiler.SelectedRows[0].Cells[4].Value.ToString();

            for (int i = 0; i < yoneticiler.Count; i++)  //Seçilen personelle aynı isimdeki personeli listede arıyor, o kişiyi bulunca yeni bilgilerini yazıyor.
            {
                Yonetici yonetici = yoneticiler[i];
                if (yonetici.AdSoyad == secilenYonetici.AdSoyad)
                {
                    yonetici.AdSoyad = txtYoneticiAdSoyad.Text;
                    yonetici.CalismaSaati = uint.Parse(txtYoneticiCalismaSaati.Text);
                }
            }

            //Listedeki kişi güncellendi.

            JsonDosya.Yaz(yoneticiler, "yonetici.json");

        }
        public void DataGridViewGuncelle()
        {
            yoneticiler = JsonDosya.Oku<Yonetici>("yonetici.json");
            yoneticiler.Reverse();
            dgvYoneticiler.DataSource = null;
            dgvYoneticiler.DataSource = yoneticiler;

            //DataGridViewde görünmesini istemediğimiz bilgilerin görünürlüğünü gizli yaptık.
            dgvYoneticiler.Columns["SaatlikUcret"].Visible = false;
            dgvYoneticiler.Columns["EkKazanc"].Visible = false;
            dgvYoneticiler.Columns["AnaKazanc"].Visible = false;

            //DataGridViewde otomatik olarak yazan başlıkları değiştirdik. (Yazım açısından güzel görünsün diye)
            dgvYoneticiler.Columns[4].HeaderText = "Ad Soyad";
            dgvYoneticiler.Columns[5].HeaderText = "Çalışma Saati";

        }
        public void ListeVeJsonEkle() //Yeni yönetici nesnesi oluşturup, bu nesneyi hem list imize hem de json ımıza ekleyen metot.
        {
            Yonetici yonetici = new Yonetici
            {
                AdSoyad = txtYoneticiAdSoyad.Text,
                CalismaSaati = uint.Parse(txtYoneticiCalismaSaati.Text)
            };
            yoneticiler.Add(yonetici);
            JsonDosya.Yaz(yoneticiler, "yonetici.json");
        }
        public void ListeVeJsonSil() //Kullanıcının seçtiği yönetici nesnesini listeden silen, güncel listeyi tekrardan jsona yazdıran metot.
        {
            Yonetici secilenYonetici = new Yonetici();

            secilenYonetici.AdSoyad = dgvYoneticiler.SelectedRows[0].Cells[4].Value.ToString();

            for (int i = 0; i < yoneticiler.Count; i++)
            {
                Yonetici yonetici = yoneticiler[i];
                if (yonetici.AdSoyad == secilenYonetici.AdSoyad)
                {
                    yoneticiler.RemoveAt(i);
                }
            }
            JsonDosya.Yaz(yoneticiler, "yonetici.json");
        }
        public void Temizle() //Form ekranındaki araçların içini temizleyen metot.
        {
            txtYoneticiAdSoyad.Text = txtYoneticiCalismaSaati.Text = string.Empty;
            dgvYoneticiler.ClearSelection();
            cellClickEdildiMi = false;
        }
        public YoneticiIslemleri()
        {
            InitializeComponent();
        }

        private void YoneticiIslemleri_Load(object sender, EventArgs e)
        {
            DataGridViewGuncelle();
            Temizle();
        }

        private void dgvYoneticiler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClickEdildiMi = true;
            if (dgvYoneticiler.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow seciliSatir = dgvYoneticiler.SelectedRows[0]; //Çoklu seçim kapalı olduğu için SelectedRows[0] seçili olan satırı ifade eder.

            //kullanıcının seçtiği satırdaki kişinin bilgileri yukarıdaki textboxlara yazdırıldı.
            txtYoneticiAdSoyad.Text = seciliSatir.Cells[4].Value.ToString();
            txtYoneticiCalismaSaati.Text = seciliSatir.Cells[5].Value.ToString();
        }

        private void btnYoneticiEkle_Click(object sender, EventArgs e)
        {
            //Kullanıcının girdiği bilgilerin geçerliliğine bakar, aynı isimde bir mevcut mu diye bakar. Her şey geçerliyse kayıt eder.

            if (!BilgilerGecerliMi())
            { return; }

            foreach (Yonetici yonetici in yoneticiler)
            {
                if (txtYoneticiAdSoyad.Text == yonetici.AdSoyad)
                {
                    MessageBox.Show("Bu isimde bir memur zaten mevcut!");
                    return;
                }
            }

            ListeVeJsonEkle();
            DataGridViewGuncelle();
            Temizle();
        }

        private void btnYoneticiSil_Click(object sender, EventArgs e)
        {
            //Kullanıcı bir personel seçti mi diye kontrol eder, seçiliyse o personeli siler.

            if (dgvYoneticiler.SelectedRows.Count == 0 || !cellClickEdildiMi)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz!");
                return;
            }
            ListeVeJsonSil();
            DataGridViewGuncelle();
            Temizle();
        }

        private void btnYoneticiGuncelle_Click(object sender, EventArgs e)
        {
            //Kullanıcı bir personel seçti mi diye kontrol eder, güncellemek istediği bilgiler geçerli mi diye kontrol eder. Her şey geçerliyse personeli günceller.

            if (dgvYoneticiler.SelectedRows.Count == 0 || !cellClickEdildiMi)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz!");
                return;
            }
            if (!BilgilerGecerliMi())
            { return; }
            ListeVeJsonGuncelle();
            DataGridViewGuncelle();
            Temizle();
        }
    }
}
