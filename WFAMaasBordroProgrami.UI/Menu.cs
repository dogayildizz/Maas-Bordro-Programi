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
            form.MdiParent = this; //this form(içinde bulunduðumuz form), ana formdur. parametreden aldýðýmýz form, ana formun alt formudur.
            form.FormBorderStyle = FormBorderStyle.None; //hareket etmesini engelledik
            pnlIcerik.Controls.Add(form);  //Çaðýrdýðýmýz formu pnlIcerik adýndaki panele ekledik.
            form.Show(); //Çaðýrdýðýmýz formu göster dedik.
        }

        #region Buttonlarýn Click Eventleri (pnlIcerik adlý panele formlar getirdik)

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

        #region Formu kapat ve alta at tuþlarýný manuel olarak ekledik.
        private void btnFormuAltaAt_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnProgramiKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

    }
}
