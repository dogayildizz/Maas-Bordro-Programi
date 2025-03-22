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

        private void btnPersonelIslemleriFormunuGetir_Click(object sender, EventArgs e)
        {
            PersonelIslemleri frmPersonelIslemleri = new PersonelIslemleri();
            FormGetir(frmPersonelIslemleri);
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

        private void btnProgramiKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
