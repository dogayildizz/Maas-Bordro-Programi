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
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAMaasBordroProgrami.UI
{
    public partial class MemurIslemleri : Form
    {

        bool cellClickEdildiMi = false; //Kullanıcı datagride tıkladığında true ya dönüyor. UI paketinden kaynaklı oluşan hataların önüne geçmek için tanımlandı.
        List<Memur> memurlar = new List<Memur>();
        public MemurIslemleri()
        {
            InitializeComponent();
        }
        public bool BilgilerGecerliMi()  //Kullanıcının girdiği veriler, geçerli veriler mi kontrolü yapan metot
        {
            bool bilgilerGecerliMi = true;
            if (txtMemurAdSoyad.Text == string.Empty || txtMemurCalismaSaati.Text == string.Empty || cmbMemurDerece.SelectedItem == null || String.IsNullOrWhiteSpace(txtMemurAdSoyad.Text))
            {
                bilgilerGecerliMi = false;
                MessageBox.Show("Lütfen tüm bilgileri girdiğinizden emin olun!");
                return bilgilerGecerliMi;
            }
            if (!Kontrol.AdSoyadMi(txtMemurAdSoyad.Text) || !Kontrol.CalismaSaatiMi(txtMemurCalismaSaati.Text))
            {
                bilgilerGecerliMi = false;
                MessageBox.Show("Tüm bilgileri doğru girdiğinizden emin olun!");
                return bilgilerGecerliMi;
            }

            return bilgilerGecerliMi;
        }
        public void ListeVeJsonEkle() //Yeni memur nesnesi oluşturup, bu nesneyi hem list imize hem de json ımıza ekleyen metot.
        {
            Memur memur = new Memur
            {
                AdSoyad = txtMemurAdSoyad.Text,
                CalismaSaati = uint.Parse(txtMemurCalismaSaati.Text),
                MemurunDerecesi = (MemurDerecesi)cmbMemurDerece.SelectedItem
            };
            memurlar.Add(memur);
            JsonDosya.Yaz(memurlar, "memur.json");
        }
        public void ListeVeJsonSil() //Kullanıcının seçtiği memur nesnesini listeden silen, güncel listeyi tekrardan jsona yazdıran metot.
        {
            Memur secilenMemur = new Memur();
            secilenMemur.AdSoyad = dgvMemurlar.SelectedRows[0].Cells[5].Value.ToString();
            for (int i = 0; i < memurlar.Count; i++)
            {
                Memur memur = memurlar[i];
                if (memur.AdSoyad == secilenMemur.AdSoyad)
                {
                    memurlar.RemoveAt(i);
                }
            }
            JsonDosya.Yaz(memurlar, "memur.json");
        }
        public void ListeVeJsonGuncelle() //Kullanıcının seçtiği personeli, yazdığı yeni bilgiler ile memurlar listesinde günceller, güncel listeyi Jsona yazar.
        {
            Memur secilenMemur = new Memur();
            secilenMemur.AdSoyad = dgvMemurlar.SelectedRows[0].Cells[5].Value.ToString();

            for (int i = 0; i < memurlar.Count; i++) //Seçilen personelle aynı isimdeki personeli listede arıyor, o kişiyi bulunca yeni bilgilerini yazıyor.
            {
                Memur memur = memurlar[i];
                if (memur.AdSoyad == secilenMemur.AdSoyad)
                {
                    memur.AdSoyad = txtMemurAdSoyad.Text;
                    memur.CalismaSaati = uint.Parse(txtMemurCalismaSaati.Text);
                    memur.MemurunDerecesi = (MemurDerecesi)cmbMemurDerece.SelectedItem;
                }
            }

            //Listedeki kişi güncellendi.

            JsonDosya.Yaz(memurlar, "memur.json");

        }
        private void dgvMemurlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClickEdildiMi = true;
            if (dgvMemurlar.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow seciliSatir = dgvMemurlar.SelectedRows[0]; //Çoklu seçim kapalı olduğu için SelectedRows[0] seçili olan satırı ifade eder.

            //kullanıcının seçtiği satırdaki kişinin bilgileri yukarıdaki textboxlara yazdırıldı.
            txtMemurAdSoyad.Text = seciliSatir.Cells[5].Value.ToString();
            txtMemurCalismaSaati.Text = seciliSatir.Cells[6].Value.ToString();
            cmbMemurDerece.SelectedItem = (MemurDerecesi)dgvMemurlar.SelectedRows[0].Cells["MemurunDerecesi"].Value;

        }
        public void DataGridViewGuncelle()
        {
            memurlar = JsonDosya.Oku<Memur>("memur.json");
            memurlar.Reverse();
            dgvMemurlar.DataSource = null;
            dgvMemurlar.DataSource = memurlar;

            //DataGridViewde görünmesini istemediğimiz bilgilerin görünürlüğünü gizli yaptık.
            dgvMemurlar.Columns["EkKazanc"].Visible = false;
            dgvMemurlar.Columns["SaatlikUcret"].Visible = false;
            dgvMemurlar.Columns["AnaKazanc"].Visible = false;

            //DataGridViewde otomatik olarak yazan başlıkları değiştirdik. (Yazım açısından güzel görünsün diye)
            dgvMemurlar.Columns[3].HeaderText = "Derece";
            dgvMemurlar.Columns[5].HeaderText = "Ad Soyad";
            dgvMemurlar.Columns[6].HeaderText = "Çalışma Saati";
        }
        public void Temizle() //Form ekranındaki araçların içini temizleyen metot.
        {
            txtMemurAdSoyad.Text = txtMemurCalismaSaati.Text = string.Empty;
            cmbMemurDerece.SelectedIndex = -1;
            dgvMemurlar.ClearSelection();
            cellClickEdildiMi = false;
        }
        private void MemurIslemleri_Load(object sender, EventArgs e)
        {
            cmbMemurDerece.DataSource = Enum.GetValues(typeof(MemurDerecesi));
            DataGridViewGuncelle();
            Temizle();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            //Kullanıcı bir personel seçti mi diye kontrol eder, seçiliyse o personeli siler.

            if (dgvMemurlar.SelectedRows.Count == 0 || !cellClickEdildiMi)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz!");
                return;
            }
            ListeVeJsonSil();
            DataGridViewGuncelle();
            Temizle();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //Kullanıcı bir personel seçti mi diye kontrol eder, güncellemek istediği bilgiler geçerli mi diye kontrol eder. Her şey geçerliyse personeli günceller.

            if (!BilgilerGecerliMi())
            { return; }

            if (dgvMemurlar.SelectedRows.Count == 0 || !cellClickEdildiMi)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz!");
                return;
            }
            ListeVeJsonGuncelle();
            DataGridViewGuncelle();
            Temizle();
        }
        private void btnMemurEkle_Click(object sender, EventArgs e)
        {
            //Kullanıcının girdiği bilgilerin geçerliliğine bakar, aynı isimde bir mevcut mu diye bakar. Her şey geçerliyse kayıt eder.

            if (!BilgilerGecerliMi())
            { return; }
            foreach (Memur memur in memurlar)
            {
                if (txtMemurAdSoyad.Text == memur.AdSoyad)
                {
                    MessageBox.Show("Bu isimde bir memur zaten mevcut!");
                    return;
                }
            }
            ListeVeJsonEkle();
            DataGridViewGuncelle();
            Temizle();
        }


    }
}
