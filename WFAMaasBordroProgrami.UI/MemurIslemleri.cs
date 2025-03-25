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

        bool cellClickEdildiMi = false;
        List<Memur> memurlar = new List<Memur>();
        public MemurIslemleri()
        {
            InitializeComponent();
        }
        public void ListeVeJsonEkle()
        {
            Memur memur = new Memur
            {
                AdSoyad = txtMemurAdSoyad.Text,
                CalismaSaati = uint.Parse(txtMemurCalismaSaati.Text),
                MemurunDerecesi = (MemurDerecesi)cmbMemurDerece.SelectedItem
            };
            memurlar.Add(memur);
            JsonDosya.Yaz(memurlar,"memur.json");
        }
        public void ListeVeJsonSil()
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
            JsonDosya.Yaz(memurlar,"memur.json");
        }
        public void ListeVeJsonGuncelle()
        {
            Memur secilenMemur = new Memur();
            secilenMemur.AdSoyad = dgvMemurlar.SelectedRows[0].Cells[5].Value.ToString();

            for (int i = 0; i < memurlar.Count; i++)
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
            DataGridViewRow seciliSatir = dgvMemurlar.SelectedRows[0];

            txtMemurAdSoyad.Text = seciliSatir.Cells[5].Value.ToString();
            txtMemurCalismaSaati.Text = seciliSatir.Cells[6].Value.ToString();
            cmbMemurDerece.SelectedItem = (MemurDerecesi)dgvMemurlar.SelectedRows[0].Cells["MemurunDerecesi"].Value;

        }
        public void DataGridViewGuncelle()
        {
            memurlar = JsonDosya.Oku<Memur>("memur.json");
            dgvMemurlar.DataSource = null;
            dgvMemurlar.DataSource = memurlar;

            dgvMemurlar.Columns["EkKazanc"].Visible = false;
            dgvMemurlar.Columns["SaatlikUcret"].Visible = false;
            dgvMemurlar.Columns["AnaKazanc"].Visible = false;



        }
        public void Temizle()
        {
            txtMemurAdSoyad.Text = txtMemurCalismaSaati.Text = string.Empty;
            cmbMemurDerece.SelectedItem = null;
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
            if(txtMemurAdSoyad.Text==string.Empty || txtMemurCalismaSaati.Text==string.Empty || cmbMemurDerece.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm bilgileri girdiğinizden emin olun!");
                return;
            }
            ListeVeJsonEkle();
            DataGridViewGuncelle();
            Temizle();
        }
    }
}
