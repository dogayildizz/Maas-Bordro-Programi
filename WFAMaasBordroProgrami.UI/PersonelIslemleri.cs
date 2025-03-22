using CLMaasBordro.Abstract;
using CLMaasBordro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAMaasBordroProgrami.UI
{
    public partial class PersonelIslemleri : Form
    {
        public PersonelIslemleri()
        {
            InitializeComponent();
        }

        private void PersonelIslemleri_Load(object sender, EventArgs e)
        {


        }

        public void FormGetir(Form form)
        {
            pnlPersonelIslemleri.Controls.Clear();
           // form.MdiChildren = this; //bu forma form2yi çağırdık
            form.FormBorderStyle = FormBorderStyle.None; //hareket etmesini engelledik
            pnlPersonelIslemleri.Controls.Add(form);
            form.Show(); //form2yi göster dedik.
        }

        private void btnYeniPersonelKayitFormunuGetir_Click(object sender, EventArgs e)
        {
            YeniPersonelKayit frmYeniPersonelKayit = new YeniPersonelKayit();
            FormGetir(frmYeniPersonelKayit);
        }

        private void btnMemurIslemleriFormunuGetir_Click(object sender, EventArgs e)
        {
            MemurIslemleri frmMemurIslemleri = new MemurIslemleri();
            FormGetir(frmMemurIslemleri);

        }

        private void btnYoneticiIslemleriFormunuGetir_Click(object sender, EventArgs e)
        {
            YoneticiIslemleri frmYoneticiIslemleri = new YoneticiIslemleri();
            FormGetir(frmYoneticiIslemleri);

        }
    }
}
