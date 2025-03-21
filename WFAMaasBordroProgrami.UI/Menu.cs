using CLMaasBordro.Abstract;
using CLMaasBordro.Data;
using CLMaasBordro.Enum;

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

        }

        private void btnBireyselBordroFormunuGetir_Click(object sender, EventArgs e)
        {

        }

        private void btnTumCalisanlarinBordrosu_Click(object sender, EventArgs e)
        {

        }

        private void btnProgramiKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
