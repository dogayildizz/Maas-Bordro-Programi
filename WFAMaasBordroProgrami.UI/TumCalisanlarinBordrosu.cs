using CLMaasBordro.Data;
using CLMaasBordro.Models;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;

namespace WFAMaasBordroProgrami.UI
{
    public partial class TumCalisanlarinBordrosu : Form
    {
        List<Memur> memurlar = new List<Memur>();
        List<Yonetici> yoneticiler = new List<Yonetici>();

        public TumCalisanlarinBordrosu()
        {
            InitializeComponent();
        }

        private void TumCalisanlarinBordrosu_Load(object sender, EventArgs e)
        {
            memurlar = JsonDosya.Oku<Memur>("memur.json");
            yoneticiler = JsonDosya.Oku<Yonetici>("yonetici.json");


            lvTumCalisanlarinBordrosu.View = View.Details;  //.View öğelerin nasıl gösterileceğini belirler. View.Details detaylı görünüm demek
            lvTumCalisanlarinBordrosu.GridLines = true;  //satır ve sütun aralarındaki çizgilerin görünürlüğünü aktif ettik.
            lvTumCalisanlarinBordrosu.Columns.Add("Personel Adı Soyadı", 220, HorizontalAlignment.Center); //sütun ekledik : (sütunun başlığı, sütunun genişliği)
            lvTumCalisanlarinBordrosu.Columns.Add("Kadro", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Çalışma Saati ", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Ana Kazanç", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Ek Kazanç", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Toplam Kazanç", 180, HorizontalAlignment.Center);

            foreach (Memur memur in memurlar)
            {
                ListViewItem listViewItem = new ListViewItem(memur.AdSoyad);
                listViewItem.SubItems.Add(memur.Kadro);
                listViewItem.SubItems.Add(memur.CalismaSaati.ToString());
                listViewItem.SubItems.Add(memur.AnaKazanc.ToString("C2"));
                listViewItem.SubItems.Add(memur.EkKazanc.ToString("C2"));
                listViewItem.SubItems.Add(memur.ToplamMaasHesapla().ToString("C2"));

                // Çalışma saati 150'den düşükse, satırın rengini kırmızı yap
                if (memur.CalismaSaati < 150)
                {
                    listViewItem.BackColor = Color.LightSteelBlue;
                }

                lvTumCalisanlarinBordrosu.Items.Add(listViewItem);
            }
            foreach (Yonetici yonetici in yoneticiler)
            {

                ListViewItem listViewItem = new ListViewItem(yonetici.AdSoyad);
                listViewItem.SubItems.Add(yonetici.Kadro);
                listViewItem.SubItems.Add(yonetici.CalismaSaati.ToString());
                listViewItem.SubItems.Add(yonetici.AnaKazanc.ToString("C2"));
                listViewItem.SubItems.Add(yonetici.EkKazanc.ToString("C2"));
                listViewItem.SubItems.Add(yonetici.ToplamMaasHesapla().ToString("C2"));

                // Çalışma saati 150'den düşükse, satırın rengini kırmızı yap
                if (yonetici.CalismaSaati < 150)
                {
                    listViewItem.BackColor = Color.LightSteelBlue;
                }

                lvTumCalisanlarinBordrosu.Items.Add(listViewItem);
            }
        }

        private void btnExcelOlustur_Click(object sender, EventArgs e)
        {
            //Value property si kullanıcının yaptığı seçimi veya girdiyi almak için kullanılır.

            try
            {

                //using, farklı namespace'lerdeki sınıfları ve fonksiyonları projemize dahil etmek için kullanılır.

                //Excel çalışma kitabı oluşturur ve işlem tamamlandıktan sonra otomatik temizlenmesini sağlar.
                using (var workbook = new XLWorkbook())
                {
                    //Worksheet, Excel dosyası (Workbook) içindeki tek bir sayfayı (sheet) ifade eder. AddWorksheet ile "Çalışanların Maaş Bordroları" adında yeni bir sayfa(sheet) ekledik.
                    var workSheet = workbook.AddWorksheet("Çalışanların Maaş Bordroları");

                    workSheet.Cell(1, 1).Value = "Personel Adı Soyadı"; // Cell(satır,sütun) ==> excelde belirtilen konuma yazı yazdık.
                    workSheet.Cell(1, 2).Value = "Kadro";
                    workSheet.Cell(1, 3).Value = "Çalışma Saati";
                    workSheet.Cell(1, 4).Value = "Ana Kazanç";
                    workSheet.Cell(1, 5).Value = "Ek Kazanç";
                    workSheet.Cell(1, 6).Value = "Toplam Kazanç";

                    int satir = 2;
                    foreach (ListViewItem item in lvTumCalisanlarinBordrosu.Items)
                    {
                        //ListViewItem dan bilgileri alıyoruz, excele yazdırıyoruz.
                        workSheet.Cell(satir, 1).Value = item.SubItems[0].Text; //SubItems[0] ==> 2. satırdaki ilk öğe.
                        workSheet.Cell(satir, 2).Value = item.SubItems[1].Text;
                        workSheet.Cell(satir, 3).Value = item.SubItems[2].Text;
                        workSheet.Cell(satir, 4).Value = item.SubItems[3].Text;
                        workSheet.Cell(satir, 5).Value = item.SubItems[4].Text;
                        workSheet.Cell(satir, 6).Value = item.SubItems[5].Text;
                        satir++;
                    }

                    //SaveFileDialog, kullanıcının bir dosyayı kaydetmek için dosya adı ve konumu seçmesini sağlayan bir Windows bileşenidir.
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";   //Dosya türü
                        saveFileDialog.Title = "Excel Dosyasını Kaydet"; //Pencere başlığı

                        if (saveFileDialog.ShowDialog() == DialogResult.OK) //Kullanıcı açılan pencerede OK(tamam,evet,vs.. bir onay tuşuna) basarsa: (DialogResult.OK bu anlama geliyor. Zıttı ise(onaylamama durumu)  DialogResult.Cancel )
                        {
                            string filePath = saveFileDialog.FileName;
                            workbook.SaveAs(filePath); //Oluşturduğumuz workbook u (excel dosyasını), kullanıcının belirlediği konuma kaydet.
                            MessageBox.Show("Excel başarıyla oluşturuldu.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPdfOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); //Türkçe karakterlerin düzgün görünmesini sağlar.
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Dosyası|*.pdf"; //Dosya türü
                saveFileDialog.Title = "PDF Dosyası Kaydet"; //Pencere başlığı

                if (saveFileDialog.ShowDialog() == DialogResult.OK) //Kullanıcı açılan pencerede OK(tamam,evet,vs.. bir onay tuşuna) basarsa
                {
                    Document document = new Document();
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Türkçe karakterleri destekleyen bir font kullanıyoruz
                    BaseFont baseFont = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED); // Arial fontu ile
                    Font font = new Font(baseFont, 12); // Fontu ekliyoruz

                    PdfPTable table = new PdfPTable(lvTumCalisanlarinBordrosu.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (ColumnHeader column in lvTumCalisanlarinBordrosu.Columns)
                    {
                        PdfPCell pdfPCell = new PdfPCell(new Phrase(column.Text, font)); // Burada fontu kullandık
                        pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(pdfPCell);
                    }

                    foreach (ListViewItem item in lvTumCalisanlarinBordrosu.Items)
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            table.AddCell(new Phrase(subItem.Text, font)); // Burada da fontu kullandık
                        }
                    }

                    document.Add(table);
                    document.Close();
                    MessageBox.Show("PDF başarıyla oluşturuldu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturulurken bir hata oluştu: " + ex.Message);
            }


        }

        private void btnJsonKlasorOlustur_Click(object sender, EventArgs e)
        {

        }
    }
}
