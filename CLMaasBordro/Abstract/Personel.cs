using System.Text.Json.Serialization;

namespace CLMaasBordro.Abstract
{
    public abstract class Personel
    {
        //[JsonIgnore]
        //public uint Id {get;}   //enkapsüle et

        public string Kadro { get;}
        public string AdSoyad { get; set; }
        [JsonIgnore]
        public uint CalismaSaati { get; set; }
        public abstract decimal SaatlikUcret { get; set; } 
        public abstract decimal ToplamMaasHesapla(int calismaSaati);
        
    }
}
