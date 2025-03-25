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
            
            var jsonAyarlar = new JsonSerializerOptions { WriteIndented = true };
            string jsonDosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "Data", dosyaAdi);
            string yeniJson = JsonSerializer.Serialize(personeller, jsonAyarlar);
            File.WriteAllText(jsonDosyaYolu, yeniJson);
        }
        static public List<T> Oku<T>(string dosyaAdi)
        {
            List<T> personeller = new List<T>();

            string jsonDosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "Data", dosyaAdi);
            string jsonVerileri = File.ReadAllText(jsonDosyaYolu);

            var okunanVeriler = JsonSerializer.Deserialize<List<T>>(jsonVerileri);

            personeller.AddRange(okunanVeriler);

            return personeller;
        }

    }
}

