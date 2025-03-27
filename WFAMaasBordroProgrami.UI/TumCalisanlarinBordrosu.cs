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
            lvTumCalisanlarinBordrosu.Columns.Add("Personel Adı Soyadı", 220, HorizontalAlignment.Center); //sütun ekledik : (sütunun başlığı, sütunun genişliği, sütundaki yazıyı ortala)
            lvTumCalisanlarinBordrosu.Columns.Add("Kadro", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Çalışma Saati ", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Ana Kazanç", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Ek Kazanç", 180, HorizontalAlignment.Center);
            lvTumCalisanlarinBordrosu.Columns.Add("Toplam Kazanç", 180, HorizontalAlignment.Center);

            foreach (Memur memur in memurlar)
            {
                ListViewItem listViewItem = new ListViewItem(memur.AdSoyad); //Burada newlememizin nedeni yeni bir satır oluşturuyoruz. ListViewItem bir class. Ondan yeni bir nesne ürettik.
                listViewItem.SubItems.Add(memur.Kadro); //SubItems, listViewItem satırının hücresi
                listViewItem.SubItems.Add(memur.CalismaSaati.ToString());
                listViewItem.SubItems.Add(memur.AnaKazanc.ToString("C2"));
                listViewItem.SubItems.Add(memur.EkKazanc.ToString("C2"));
                listViewItem.SubItems.Add(memur.ToplamMaasHesapla().ToString("C2"));

                // Çalışma saati 150'den düşükse, satırın rengini mavi yap
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

                // Çalışma saati 150'den düşükse, satırın rengini mavi yap
                if (yonetici.CalismaSaati < 150)
                {
                    listViewItem.BackColor = Color.LightSteelBlue;
                }

                lvTumCalisanlarinBordrosu.Items.Add(listViewItem);
            }
        }

        private void btnExcelOlustur_Click(object sender, EventArgs e)
        {

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

                    //SaveFileDialog, Windows Forms uygulamalarında kullanıcının bir dosya kaydetmek için konum ve isim seçmesine olanak tanıyan bir bileşendir. Kullanıcıya bir "Dosya Kaydet" penceresi açar ve belirlenen dosya adını/ dizinini döndürür.
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
                MessageBox.Show("Excel oluşturulurken bir hata oluştu. "+ex.Message);
            }
        }

        private void btnPdfOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); //Türkçe karakterlerin düzgün görünmesini sağlar.
                //SaveFileDialog, Windows Forms uygulamalarında kullanıcının bir dosya kaydetmek için konum ve isim seçmesine olanak tanıyan bir bileşendir. Kullanıcıya bir "Dosya Kaydet" penceresi açar ve belirlenen dosya adını/dizinini döndürür.
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Dosyası|*.pdf"; //Dosya türü
                saveFileDialog.Title = "PDF Dosyası Kaydet"; //Pencere başlığı

                if (saveFileDialog.ShowDialog() == DialogResult.OK) //Kullanıcı açılan pencerede OK(tamam,evet,vs.. bir onay tuşuna) basarsa
                {
                    Document document = new Document(); //Document sınıfı, iTextSharp kütüphanesi ile bir PDF belgesi oluşturmak için kullanılır.
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create)); //seçilen dosya konumuna PDF Yazıcı bağlanıyor.

                    document.Open(); //Pdf belgesine veri ekleyebilmek için açıyoruz.

                    // Türkçe karakterleri destekleyen bir font kullanıyoruz
                    BaseFont baseFont = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED); // Arial fontu ile
                    Font font = new Font(baseFont, 12); // 12 punto büyüklüğünde fontu ekliyoruz

                    PdfPTable table = new PdfPTable(lvTumCalisanlarinBordrosu.Columns.Count); //Bir tablo oluşturduk. ListViewdeki sütun sayısı kadar tabloda sütunlar oluşuyor.

                    table.WidthPercentage = 100;

                    foreach (ColumnHeader column in lvTumCalisanlarinBordrosu.Columns) //Tabloya arkaplanı gri renkte olacak şekilde sütun başlıkları ekleniyor.
                    {
                        PdfPCell pdfPCell = new PdfPCell(new Phrase(column.Text, font)); // Burada fontu kullandık
                        pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(pdfPCell);
                    }

                    foreach (ListViewItem item in lvTumCalisanlarinBordrosu.Items) //Tabloya listviewdeki veriler ekleniyor.
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            table.AddCell(new Phrase(subItem.Text, font)); // Burada da fontu kullandık
                        }
                    }

                    document.Add(table);  //Oluşan tabloyu ekliyoruz.
                    document.Close(); //PDF dosyasını kapatıyoruz.
                    MessageBox.Show("PDF başarıyla oluşturuldu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturulurken bir hata oluştu: " + ex.Message);
            }


        }


    }
}
