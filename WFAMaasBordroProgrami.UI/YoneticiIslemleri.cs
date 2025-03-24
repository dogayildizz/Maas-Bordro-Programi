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
        bool cellClickEdildiMi = false;
        List<Yonetici> yoneticiler = new List<Yonetici>();
        public void ListeVeJsonGuncelle()
        {
            Yonetici secilenYonetici = new Yonetici();
            secilenYonetici.AdSoyad = dgvYoneticiler.SelectedRows[0].Cells[4].Value.ToString();

            for (int i = 0; i < yoneticiler.Count; i++)
            {
                Yonetici yonetici = yoneticiler[i];
                if (yonetici.AdSoyad == secilenYonetici.AdSoyad)
                {
                    yonetici.AdSoyad = txtYoneticiAdSoyad.Text;
                    yonetici.CalismaSaati = uint.Parse(txtYoneticiCalismaSaati.Text);
                }
            }

            //Listedeki kişi güncellendi.

            JsonDosya.YoneticiYaz(yoneticiler);

        }
        public void DataGridViewGuncelle()
        {
            yoneticiler = JsonDosya.YoneticiOku();
            dgvYoneticiler.DataSource = null;
            dgvYoneticiler.DataSource = yoneticiler;

            dgvYoneticiler.Columns["SaatlikUcret"].Visible = false;
            dgvYoneticiler.Columns["EkKazanc"].Visible = false;
            dgvYoneticiler.Columns["AnaKazanc"].Visible = false;
        }
        public void ListeVeJsonEkle()
        {
            Yonetici yonetici = new Yonetici
            {
                AdSoyad = txtYoneticiAdSoyad.Text,
                CalismaSaati = uint.Parse(txtYoneticiCalismaSaati.Text)
            };
            yoneticiler.Add(yonetici);
            JsonDosya.YoneticiYaz(yoneticiler);
        }
        public void ListeVeJsonSil()
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
            JsonDosya.YoneticiYaz(yoneticiler);
        }
        public void Temizle()
        {
            txtYoneticiAdSoyad.Text = txtYoneticiCalismaSaati.Text = string.Empty;
            dgvYoneticiler.ClearSelection();
            //cellClickEdildiMi = false;
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
            DataGridViewRow seciliSatir = dgvYoneticiler.SelectedRows[0];

            txtYoneticiAdSoyad.Text = seciliSatir.Cells[4].Value.ToString();
            txtYoneticiCalismaSaati.Text = seciliSatir.Cells[5].Value.ToString();
        }

        private void btnYoneticiEkle_Click(object sender, EventArgs e)
        {
            if (txtYoneticiAdSoyad.Text == string.Empty || txtYoneticiCalismaSaati.Text == string.Empty)
            {
                MessageBox.Show("Lütfen tüm bilgileri girdiğinizden emin olun!");
                return;
            }
            ListeVeJsonEkle();
            DataGridViewGuncelle();
            Temizle();
        }

        private void btnYoneticiSil_Click(object sender, EventArgs e)
        {
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
            if (dgvYoneticiler.SelectedRows.Count == 0 || !cellClickEdildiMi)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz!");
                return;
            }
            ListeVeJsonGuncelle();
            DataGridViewGuncelle();
            Temizle();
        }
    }
}
