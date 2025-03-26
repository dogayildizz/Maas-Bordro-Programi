using CLMaasBordro.Abstract;
using CLMaasBordro.Data;
using CLMaasBordro.Models;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
            memurlar = JsonDosya.Oku<Memur>("memur.json");
            yoneticiler = JsonDosya.Oku<Yonetici>("yonetici.json");
            cmbBordrosuGoruntulenmekIstenenPersonelTuru.Items.Add("Memur");
            cmbBordrosuGoruntulenmekIstenenPersonelTuru.Items.Add("Yönetici");
            ListViewBasliklariOlustur();
        }

        private void cmbBordrosuGoruntulenmekIstenenPersonelTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBordrosuGoruntulenmekIstenenPersonel.Items.Clear();
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
            if (cmbBordrosuGoruntulenmekIstenenPersonel.SelectedItem == null)
            { return; }


            lvBireyselBordro.Items.Clear();

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
            foreach (Yonetici yonetici in yoneticiler)
            {
                if (cmbBordrosuGoruntulenmekIstenenPersonel.SelectedItem.ToString() == yonetici.AdSoyad)
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

        private void btnBireyselMailGonder_Click(object sender, EventArgs e)
        {
            string gonderimYapilacakMailAdresi = txtGonderilecekMailAdresi.Text;
            if (!gonderimYapilacakMailAdresi.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Yalnızca gmail uzantılı mail adresi girmelisiniz!");
                txtGonderilecekMailAdresi.Text = "example@gmail.com";
                return;
            }

            try
            {
                string excelDosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Bordro.xlsx");
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Bireysel Bordro");
                    for (int col = 0; col < lvBireyselBordro.Columns.Count; col++)
                    {
                        worksheet.Cell(1, col + 1).Value = lvBireyselBordro.Columns[col].Text;
                    }
                    int row = 2;
                    foreach (ListViewItem item in lvBireyselBordro.Items)
                    {
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            worksheet.Cell(row, i + 1).Value = item.SubItems[i].Text;
                        }
                        row++;
                    }
                    workbook.SaveAs(excelDosyaYolu);
                }
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                mailMessage.From = new MailAddress("dogayildizyzl@gmail.com");  //gönderen kişinin mail adresi
                mailMessage.To.Add(txtGonderilecekMailAdresi.Text);  //gönderdiğim kişinin mail adresi
                mailMessage.Subject = "Bireysel Bordro";
                mailMessage.Body = "Merhaba, iyi çalışmalar. \nEkteki dosya bireysel bordronuzdur.";

                mailMessage.Attachments.Add(new Attachment(excelDosyaYolu));

                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("dogayildizyzl@gmail.com", "rrfnaejkrnpkwwlq"); //gönderen eposta, uygulama şifresi google hesaplardan
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
                MessageBox.Show("E posta başarıyla gönderildi!");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnBireyselJsonOlustur_Click(object sender, EventArgs e)
        {
            if (cmbBordrosuGoruntulenmekIstenenPersonelTuru.SelectedItem == "Memur")
            {
                foreach (Memur memur in memurlar)
                {
                    if (cmbBordrosuGoruntulenmekIstenenPersonel.SelectedItem.ToString() == memur.AdSoyad)
                    {
                        MaasBordro.JsonYaz(memur, memur.AdSoyad);
                    }

                }

            }
            if (cmbBordrosuGoruntulenmekIstenenPersonelTuru.SelectedItem == "Yönetici")
            {
                foreach (Yonetici yonetici in yoneticiler)
                {
                    if (cmbBordrosuGoruntulenmekIstenenPersonel.SelectedItem.ToString() == yonetici.AdSoyad)
                    {
                        MaasBordro.JsonYaz(yonetici, yonetici.AdSoyad);
                    }

                }

            }
        }

        private void txtGonderilecekMailAdresi_Click(object sender, EventArgs e)
        {
            txtGonderilecekMailAdresi.Text = string.Empty;
        }
    }
}
