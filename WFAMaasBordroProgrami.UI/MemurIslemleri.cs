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
        List<Memur> memurlar = new List<Memur>();
        public MemurIslemleri()
        {
            InitializeComponent();
        }
        public void ListeVeJsonGuncelle()
        {
            Memur secilenMemur = new Memur();
            secilenMemur.AdSoyad = dgvMemurlar.SelectedRows[0].Cells[4].Value.ToString();

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

            JsonDosya.MemurYaz(memurlar);

        }
        private void dgvMemurlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMemurlar.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow seciliSatir = dgvMemurlar.SelectedRows[0];

            txtMemurAdSoyad.Text = seciliSatir.Cells[4].Value.ToString();
            txtMemurCalismaSaati.Text = seciliSatir.Cells[5].Value.ToString();
            cmbMemurDerece.SelectedItem = (MemurDerecesi)dgvMemurlar.SelectedRows[0].Cells["MemurunDerecesi"].Value;

        }
        public void DataGridViewGuncelle()
        {
            memurlar = JsonDosya.MemurOku();
            dgvMemurlar.DataSource = null;
            dgvMemurlar.DataSource = memurlar;

            dgvMemurlar.Columns["Kadro"].Visible = false;
            dgvMemurlar.Columns["EkKazanc"].Visible = false;
            dgvMemurlar.Columns["SaatlikUcret"].Visible = false;
        }
        public void Temizle()
        {
            txtMemurAdSoyad.Text = txtMemurCalismaSaati.Text = string.Empty;
            cmbMemurDerece.SelectedItem = null;
        }

        private void MemurIslemleri_Load(object sender, EventArgs e)
        {
            cmbMemurDerece.DataSource = Enum.GetValues(typeof(MemurDerecesi));
            DataGridViewGuncelle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtMemurAdSoyad.Text == null )
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
