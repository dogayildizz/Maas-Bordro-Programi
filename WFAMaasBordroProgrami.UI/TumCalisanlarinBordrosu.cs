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
    public partial class TumCalisanlarinBordrosu : Form
    {
        List<Memur> memurlar = new List<Memur>();
        List<Yonetici> yoneticiler = new List<Yonetici>();

        public TumCalisanlarinBordrosu()
        {
            InitializeComponent();
        }

        private void TumCalisanlarinBordrosu_Load(object sender, EventArgs e)
        {
            memurlar = JsonDosya.MemurOku();
            yoneticiler = JsonDosya.YoneticiOku();

            lvTumCalisanlarinBordrosu.View = View.Details;  //.View öğelerin nasıl gösterileceğini belirler. View.Details detaylı görünüm demek
            lvTumCalisanlarinBordrosu.GridLines = true;  //satır ve sütun aralarındaki çizgilerin görünürlüğünü aktif ettik.
            lvTumCalisanlarinBordrosu.Columns.Add("Personel Adı Soyadı", 220, HorizontalAlignment.Center); //sütun ekledik : (sütunun başlığı, sütunun genişliği)
            lvTumCalisanlarinBordrosu.Columns.Add("Kadro", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Çalışma Saati ", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Ana Kazanç", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Ek Kazanç", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Toplam Kazanç", 180, HorizontalAlignment.Center);

            foreach (Memur memur in memurlar)
            {
                ListViewItem listViewItem = new ListViewItem(memur.AdSoyad);
                listViewItem.SubItems.Add(memur.Kadro);
                listViewItem.SubItems.Add(memur.CalismaSaati.ToString());
                listViewItem.SubItems.Add(memur.AnaKazanc.ToString("C2"));
                listViewItem.SubItems.Add(memur.EkKazanc.ToString("C2"));
                listViewItem.SubItems.Add(memur.ToplamMaasHesapla().ToString("C2"));
                lvTumCalisanlarinBordrosu.Items.Add(listViewItem);
            }
            foreach (Yonetici yonetici in yoneticiler)
            {

                ListViewItem listViewItem = new ListViewItem(yonetici.AdSoyad);
                listViewItem.SubItems.Add(yonetici.Kadro);
                listViewItem.SubItems.Add(yonetici.CalismaSaati.ToString());
                listViewItem.SubItems.Add(yonetici.AnaKazanc.ToString("C2"));
                listViewItem.SubItems.Add(yonetici.EkKazanc.ToString("C2"));
                listViewItem.SubItems.Add(yonetici.ToplamMaasHesapla().ToString("C2"));
                lvTumCalisanlarinBordrosu.Items.Add(listViewItem);
            }
        }
    }
}
