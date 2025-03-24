using CLMaasBordro.Abstract;
using CLMaasBordro.Data;
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
    public partial class BireyselBordro : Form
    {
        List<Memur> memurlar = new List<Memur>();
        List<Yonetici> yoneticiler = new List<Yonetici>();

        public void ListViewBasliklariOlustur()
        {
            lvBireyselBordro.View = View.Details;  //.View öğelerin nasıl gösterileceğini belirler. View.Details detaylı görünüm demek
            lvBireyselBordro.GridLines = true;  //satır ve sütun aralarındaki çizgilerin görünürlüğünü aktif ettik.
            lvBireyselBordro.Columns.Add("Personel Adı Soyadı", 220, HorizontalAlignment.Center); //sütun ekledik : (sütunun başlığı, sütunun genişliği)
            lvBireyselBordro.Columns.Add("Çalışma Saati ", 180, HorizontalAlignment.Center);
            lvBireyselBordro.Columns.Add("Ana Kazanç", 180, HorizontalAlignment.Center);
            lvBireyselBordro.Columns.Add("Ek Kazanç", 180, HorizontalAlignment.Center);
            lvBireyselBordro.Columns.Add("Toplam Kazanç", 180, HorizontalAlignment.Center);
        }

        public BireyselBordro()
        {
            InitializeComponent();
        }

        private void BireyselBordro_Load(object sender, EventArgs e)
        {
            memurlar = JsonDosya.MemurOku();
            yoneticiler = JsonDosya.YoneticiOku();
            cmbBordrosuGoruntulenmekIstenenPersonelTuru.Items.Add("Memur");
            cmbBordrosuGoruntulenmekIstenenPersonelTuru.Items.Add("Yönetici");
            ListViewBasliklariOlustur();
        }

        private void cmbBordrosuGoruntulenmekIstenenPersonelTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBordrosuGoruntulenmekIstenenPersonelTuru.SelectedItem == "Memur")
            {
                foreach (Memur memur in memurlar)
                {
                    cmbBordrosuGoruntulenmekIstenenPersonel.Items.Add(memur.AdSoyad);
                }
            }
            else if (cmbBordrosuGoruntulenmekIstenenPersonelTuru.SelectedItem == "Yönetici")
            {
                foreach (Yonetici yonetici in yoneticiler)
                {
                    cmbBordrosuGoruntulenmekIstenenPersonel.Items.Add(yonetici.AdSoyad);
                }
            }
            else
                return;

        }

        private void btnBordroGoruntule_Click(object sender, EventArgs e)
        {
            foreach (Memur memur in memurlar)
            {
                if (cmbBordrosuGoruntulenmekIstenenPersonel.SelectedItem.ToString() == memur.AdSoyad)
                {
                    ListViewItem listViewItem = new ListViewItem(memur.AdSoyad);
                    listViewItem.SubItems.Add(memur.CalismaSaati.ToString());
                    listViewItem.SubItems.Add(memur.AnaKazanc.ToString("C2"));
                    listViewItem.SubItems.Add(memur.EkKazanc.ToString("C2"));
                    listViewItem.SubItems.Add(memur.ToplamMaasHesapla().ToString("C2"));
                    lvBireyselBordro.Items.Add(listViewItem);
                    return;
                }
            }
            foreach(Yonetici yonetici in yoneticiler)
            {
                if(cmbBordrosuGoruntulenmekIstenenPersonel.SelectedItem.ToString() == yonetici.AdSoyad)
                {
                    ListViewItem listViewItem = new ListViewItem(yonetici.AdSoyad);
                    listViewItem.SubItems.Add(yonetici.CalismaSaati.ToString());
                    listViewItem.SubItems.Add(yonetici.AnaKazanc.ToString("C2"));
                    listViewItem.SubItems.Add(yonetici.EkKazanc.ToString("C2"));
                    listViewItem.SubItems.Add(yonetici.ToplamMaasHesapla().ToString("C2"));
                    lvBireyselBordro.Items.Add(listViewItem);
                    return;
                }

            }
        }

        private void cmbBordrosuGoruntulenmekIstenenPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {


            
        }
    }
}
