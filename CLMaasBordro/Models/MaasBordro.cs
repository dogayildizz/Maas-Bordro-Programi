using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CLMaasBordro.Data
{
    public static class MaasBordro
    {
        public static void JsonYaz<T>(T personel, string adSoyad)
        {
            //çalışan programın bulunduğu klasörün tam yolunu alır ve projeDizini değişkenine atar
            string projeDizini = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //Oluşacak dosya adını, bordrosu oluşturulacak kişinin adı soyadı, bordronun oluşturulduğu ay ve yıl olarak belirlettik.
            string hedefDizin = Path.Combine(projeDizini, @"..\..\..\", $"{adSoyad} Maas Bordro, {DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("tr-TR"))} {DateTime.Now.Year}");

            string dosyaYolu = Path.Combine(hedefDizin, $"{adSoyad} bordro.json");

            //Data klasörüm yok mu? 
            if (!Directory.Exists(hedefDizin))
            {
                //eğer yoksa oluştur 
                Directory.CreateDirectory(hedefDizin);
            }


            var jsonAyarlar = new JsonSerializerOptions { WriteIndented = true }; //Verileri satır satır yazsın dedik.

            string yeniJson = JsonSerializer.Serialize<T>(personel, jsonAyarlar); //Json formatına dönüştürdük.

            File.WriteAllText(dosyaYolu, yeniJson); //Belirlediğimiz dosya yoluna json ı yazdırdık.
        }

    }
}
