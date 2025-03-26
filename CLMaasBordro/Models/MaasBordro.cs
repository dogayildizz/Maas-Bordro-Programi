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
            string hedefDizin = Path.Combine(projeDizini, @"..\..\..\", $"{adSoyad} Maas Bordro, {DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("tr-TR"))} {DateTime.Now.Year}");
            string dosyaYolu = Path.Combine(hedefDizin, $"{adSoyad} bordro.json");
            //Data klasörüm var mı 
            if (!Directory.Exists(hedefDizin))
            {
                //eğer yoksa oluştur 
                Directory.CreateDirectory(hedefDizin);
            }

            var jsonAyarlar = new JsonSerializerOptions { WriteIndented = true };

            string yeniJson = JsonSerializer.Serialize<T>(personel, jsonAyarlar);
            File.WriteAllText(dosyaYolu, yeniJson);
        }

    }
}
