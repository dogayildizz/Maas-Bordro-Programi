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

        static public List<Personel> Oku()
        {
            List<Personel> personeller = new List<Personel>();

            string jsonDosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "Data", "data.json");
            string jsonVerileri = File.ReadAllText(jsonDosyaYolu);

            var okunanVeriler = JsonSerializer.Deserialize<List<Personel>>(jsonVerileri);

            personeller.AddRange(okunanVeriler);

            return personeller;

        }
    }
}

