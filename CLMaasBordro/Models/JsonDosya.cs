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

        static public void MemurYaz(List<Memur> memurlar)
        {
            var jsonAyarlar = new JsonSerializerOptions { WriteIndented = true };
            string jsonDosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "Data", "memur.json");
            string yeniJson = JsonSerializer.Serialize(memurlar, jsonAyarlar);
            File.WriteAllText(jsonDosyaYolu, yeniJson);
        }

        static public List<Memur> MemurOku()
        {
            List<Memur> memurlar = new List<Memur>();

            string jsonDosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "Data", "memur.json");
            string jsonVerileri = File.ReadAllText(jsonDosyaYolu);

            var okunanVeriler = JsonSerializer.Deserialize<List<Memur>>(jsonVerileri);

            memurlar.AddRange(okunanVeriler);

            return memurlar;
        }
        static public List<Yonetici> YoneticiOku()
        {
            List<Yonetici> yoneticiler = new List<Yonetici>();

            string jsonDosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "Data", "memur.json");
            string jsonVerileri = File.ReadAllText(jsonDosyaYolu);

            var okunanVeriler = JsonSerializer.Deserialize<List<Yonetici>>(jsonVerileri);

            yoneticiler.AddRange(okunanVeriler);

            return yoneticiler;
        }
    }
}

