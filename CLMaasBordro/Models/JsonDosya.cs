using CLMaasBordro.Abstract;
using CLMaasBordro.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CLMaasBordro.Models
{
    static public class JsonDosya
    {

        static public void Yaz<T>(List<T> personeller,string dosyaAdi)
        {
            
            var jsonAyarlar = new JsonSerializerOptions { WriteIndented = true };  //json ın yazım formatını daha okunaklı hale getirir.
            string jsonDosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "Data", dosyaAdi); //AppDomain.CurrentDomain.BaseDirectory Çalışan uygulamanın dizinini alır. Path.Combine, manuel olarak \ veya / koymamıza gerek kalmadan sistemi tanır ve uygun yolu oluşturur.
            string yeniJson = JsonSerializer.Serialize(personeller, jsonAyarlar); //personeller listesini json formatına çevirir.
            File.WriteAllText(jsonDosyaYolu, yeniJson); //yeniJson ı, jsonDosyaYolu na yazar.
        }
        static public List<T> Oku<T>(string dosyaAdi)
        {
            List<T> personeller = new List<T>();

            string jsonDosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "Data", dosyaAdi);
            string jsonVerileri = File.ReadAllText(jsonDosyaYolu); //Verdiğimiz dosya yolundaki tüm içeriği okur.

            var okunanVeriler = JsonSerializer.Deserialize<List<T>>(jsonVerileri); //Okuduğu içeriği, T tipindeki nesnelerden oluşan bir listeye dönüştürür.
            return okunanVeriler;
        }

    }
}

