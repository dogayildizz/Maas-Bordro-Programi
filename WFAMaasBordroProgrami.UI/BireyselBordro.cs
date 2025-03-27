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

        bool bordroOlusturulduMu = false; //Bordro oluşturulmadan mail ve json oluşturulmasını engellemek için kullandığım bir değişken.
        public void ListViewBasliklariOlustur() //Manuel olarak Listviewin başlıklarını oluşturduk.
        {
            lvBireyselBordro.View = View.Details;  //.View öğelerin nasıl gösterileceğini belirler. View.Details detaylı görünüm demek
            lvBireyselBordro.GridLines = true;  //satır ve sütun aralarındaki çizgilerin görünürlüğünü aktif ettik.
            lvBireyselBordro.Columns.Add("Personel Adı Soyadı", 220, HorizontalAlignment.Center); //sütun ekledik : (sütunun başlığı, sütunun genişliği, sütundaki yazıyı ortala)
            lvBireyselBordro.Columns.Add("Çalışma Saati ", 180, HorizontalAlignment.Center);
            lvBireyselBordro.Columns.Add("Ana Kazanç", 180, HorizontalAlignment.Center);
            lvBireyselBordro.Columns.Add("Ek Kazanç", 180, HorizontalAlignment.Center);
            lvBireyselBordro.Columns.Add("Toplam Kazanç", 180, HorizontalAlignment.Center);
        }

        public BireyselBordro()
        {
            InitializeComponent();
        }

        private void BireyselBordro_Load(object sender, EventArgs e) //Form açılırken json dosyasından memurları ve yöneticileri aldık. Personel türlerini manuel olarak ekledik. ListView in başlıklarını oluşturttuk.
        {
            memurlar = JsonDosya.Oku<Memur>("memur.json");
            yoneticiler = JsonDosya.Oku<Yonetici>("yonetici.json");
            cmbBordrosuGoruntulenmekIstenenPersonelTuru.Items.Add("Memur");
            cmbBordrosuGoruntulenmekIstenenPersonelTuru.Items.Add("Yönetici");
            ListViewBasliklariOlustur();
        }

        private void cmbBordrosuGoruntulenmekIstenenPersonelTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBordrosuGoruntulenmekIstenenPersonel.Items.Clear(); //Üst üste yazmasın hepsini diye her personel türü seçildiğinde, personellerin ad soyadlarının yazılı olduğu comboboxı temizledik.
            lvBireyselBordro.Items.Clear();

            //Kullanıcı eğer comboboxtan personel türünü Memur seçerse, altındaki comboboxa memurlarımızın ad soyadlarını eklendi.
            if (cmbBordrosuGoruntulenmekIstenenPersonelTuru.SelectedItem == "Memur")
            {
                foreach (Memur memur in memurlar)
                {
                    cmbBordrosuGoruntulenmekIstenenPersonel.Items.Add(memur.AdSoyad);
                }
            }
            //Kullanıcı eğer comboboxtan personel türünü Yönetici seçerse, altındaki comboboxa yöneticilerimizin ad soyadları eklendi.
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
            if (cmbBordrosuGoruntulenmekIstenenPersonel.SelectedItem == null || cmbBordrosuGoruntulenmekIstenenPersonelTuru.SelectedItem == null)
            {
                MessageBox.Show("Lütfen önce bir personel seçiniz.");
                return;
            }

            bordroOlusturulduMu = true;
            lvBireyselBordro.Items.Clear();

            foreach (Memur memur in memurlar)
            {
                //Kullanıcının bordorsunu görüntülemek istediği personel eğer memur ise, memurlar listesinden o memuru bulup, ListView'e bilgilerini yazdırdık.
                if (cmbBordrosuGoruntulenmekIstenenPersonel.SelectedItem.ToString() == memur.AdSoyad)
                {
                    ListViewItem listViewItem = new ListViewItem(memur.AdSoyad); //Burada newlememizin nedeni yeni bir satır oluşturuyoruz. ListViewItem bir class. Ondan yeni bir nesne ürettik.
                    listViewItem.SubItems.Add(memur.CalismaSaati.ToString()); //SubItems, listViewItem satırının hücresi
                    listViewItem.SubItems.Add(memur.AnaKazanc.ToString("C2"));
                    listViewItem.SubItems.Add(memur.EkKazanc.ToString("C2"));
                    listViewItem.SubItems.Add(memur.ToplamMaasHesapla().ToString("C2"));
                    lvBireyselBordro.Items.Add(listViewItem);
                    return;
                }
            }

            //Yukarıdaki işlemleri, kullanıcının personel türünü Yönetici seçmesi halinde aşağıdaki şekilde uyguladık.
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

        private void btnBireyselMailGonder_Click(object sender, EventArgs e)
        {
            if (cmbBordrosuGoruntulenmekIstenenPersonel.SelectedItem == null || cmbBordrosuGoruntulenmekIstenenPersonelTuru.SelectedItem == null)
            {
                MessageBox.Show("Lütfen önce personel seçiniz.");
                return;
            }
            if (!bordroOlusturulduMu)
            {
                MessageBox.Show("Lütfen önce bordroyu görüntüleyin.");
                return;
            }
            

            string gonderimYapilacakMailAdresi = txtGonderilecekMailAdresi.Text; //Bordronun gönderileceği mail adresini kullanıcıdan alıyoruz.

            if (!gonderimYapilacakMailAdresi.EndsWith("@gmail.com")) //Eğer @gmail.com ile bitmiyorsa uyarı veriyoruz.
            {
                MessageBox.Show("Yalnızca gmail uzantılı mail adresi girmelisiniz!");
                txtGonderilecekMailAdresi.Text = "example@gmail.com";
                return;
            }
            if (gonderimYapilacakMailAdresi == "@gmail.com")
            {
                MessageBox.Show("Lütfen geçerli bir mail adresi giriniz!");
                txtGonderilecekMailAdresi.Text = "example@gmail.com";
                return;
            }

            try
            {
                string excelDosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Bordro.xlsx"); // Bordro adındaki excel dosyasının kullanıcının masaüstünde oluşmasını sağlar. Path.Combine ile bu dizini alır.

                using (var workbook = new XLWorkbook()) //XLWorkbook, excel dosyası gibi davranan bir nesne oluşturur. Using bloğu sayesinde, using'ten çıkarken bu nesne otomatik temizlenir.
                {
                    var worksheet = workbook.Worksheets.Add("Bireysel Bordro"); //Excel içine yeni bir sayfa ekledik.

                    for (int column = 0; column < lvBireyselBordro.Columns.Count; column++)
                    {
                        //1. satırın sütunlarına, listviewden aldığımız başlıkları sırasıyla yazdırdık.
                        worksheet.Cell(1, column + 1).Value = lvBireyselBordro.Columns[column].Text;
                    }

                    int row = 2; //Satır sayısını 2 aldık, diğer eklenecek öğeleri eklemeye 2. satırdan başlasın diye. Çünkü 1. satırda başlıklar var.


                    //ListViewItemdaki her satırın her hücresini sırayla excelin her satırının her hücresine yazdırıyor.
                    foreach (ListViewItem item in lvBireyselBordro.Items)
                    {
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            worksheet.Cell(row, i + 1).Value = item.SubItems[i].Text;
                        }
                        row++;
                    }
                    workbook.SaveAs(excelDosyaYolu);  //belirttiğimiz dosya yoluna excel dosyasını kaydediyor.

                }
                MailMessage mailMessage = new MailMessage();  //Yeni bir eposta oluşturuyor.
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");   //Gmail'in SMPTP(Simple Mail Transfer Protocol - Basit Posta Aktarım Protokolü) sunucusuna bağlanılıyor.

                mailMessage.From = new MailAddress("dogayildizyzl@gmail.com");  //gönderen kişinin mail adresi
                mailMessage.To.Add(txtGonderilecekMailAdresi.Text);  //gönderdiğim kişinin mail adresi
                mailMessage.Subject = "Bireysel Bordro"; //Konu
                mailMessage.Body = "Merhaba, iyi çalışmalar. \nEkteki dosya bireysel bordronuzdur."; //İçerik

                mailMessage.Attachments.Add(new Attachment(excelDosyaYolu)); //Oluşturduğumuz excel dosyası maile eklendi.

                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("dogayildizyzl@gmail.com", "rrfnaejkrnpkwwlq"); //gönderen eposta, uygulama şifresi google hesaplardan
                smtpClient.EnableSsl = true; //Şifreli bağlantı

                smtpClient.Send(mailMessage); //Maili gönderdik.
                MessageBox.Show("E posta başarıyla gönderildi!");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Mail gönderilirken bir hata oluştu .");
            }
        }

        private void btnBireyselJsonOlustur_Click(object sender, EventArgs e) //Kullanıcının seçtiği personelin Json dosyası oluşturulur.
        {
            
            if (cmbBordrosuGoruntulenmekIstenenPersonel.SelectedItem == null || cmbBordrosuGoruntulenmekIstenenPersonelTuru.SelectedItem == null)
            {
                MessageBox.Show("Lütfen önce personel seçiniz.");
                return;
            }
            if (!bordroOlusturulduMu)
            {
                MessageBox.Show("Lütfen önce bordroyu görüntüleyin.");
                return;
            }
            try
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
                MessageBox.Show("Json dosyası başarıyla oluşturuldu!");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Json dosyası oluşturulurken bir hata oluştu. ");
            }
        }

        private void txtGonderilecekMailAdresi_Click(object sender, EventArgs e)
        {
            txtGonderilecekMailAdresi.Text = string.Empty;
        }

        private void cmbBordrosuGoruntulenmekIstenenPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            bordroOlusturulduMu = false;
        }
    }
}
