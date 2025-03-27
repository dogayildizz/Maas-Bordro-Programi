using System.Text.Json.Serialization;

namespace CLMaasBordro.Abstract
{
    public abstract class Personel 
    {
        public string AdSoyad { get; set; }
        public abstract string Kadro { get;}       
        public uint CalismaSaati { get; set; }
        public abstract decimal SaatlikUcret { get;} 
        public abstract decimal ToplamMaasHesapla();
        
    }
}
