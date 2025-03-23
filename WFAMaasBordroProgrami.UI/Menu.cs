using CLMaasBordro.Abstract;
using CLMaasBordro.Data;
using CLMaasBordro.Enum;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WFAMaasBordroProgrami.UI
{
    public partial class frmMenu : Form
    {

        public frmMenu()
        {
            InitializeComponent();
        }
        public void FormGetir(Form form)
        {
            pnlIcerik.Controls.Clear();
            form.MdiParent = this; //bu forma form2yi çaðýrdýk
            form.FormBorderStyle = FormBorderStyle.None; //hareket etmesini engelledik
            pnlIcerik.Controls.Add(form);
            form.Show(); //form2yi göster dedik.
        }
        private void frmAnaMenu_Load(object sender, EventArgs e)
        {

        }

        #region Buttonlarýn Click Eventleri
        private void btnProgramiKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaasGuncelle_Click(object sender, EventArgs e)
        {
            MaasGuncelleme frmMaasGuncelleme = new MaasGuncelleme();
            FormGetir(frmMaasGuncelleme);
        }

        private void btnBireyselBordroFormunuGetir_Click(object sender, EventArgs e)
        {
            BireyselBordro frmBireyselBordro = new BireyselBordro();
            FormGetir(frmBireyselBordro);
        }

        private void btnTumCalisanlarinBordrosu_Click(object sender, EventArgs e)
        {
            TumCalisanlarinBordrosu frmTumCalisanlarinBordrosu = new TumCalisanlarinBordrosu();
            FormGetir(frmTumCalisanlarinBordrosu);
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

        #endregion

    }
}
