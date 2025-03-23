using System.Text.Json.Serialization;

namespace CLMaasBordro.Abstract
{
    public abstract class Personel
    {
        public string AdSoyad { get; set; }
        [JsonIgnore]

        //[JsonIgnore]
        //public uint Id {get;}   //enkapsüle et

        public abstract string Kadro { get;}
       
        public uint CalismaSaati { get; set; }
        public abstract decimal SaatlikUcret { get; set; } 
        public abstract decimal ToplamMaasHesapla(uint calismaSaati);
        
    }
}
