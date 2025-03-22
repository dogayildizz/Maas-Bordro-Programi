using CLMaasBordro.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CLMaasBordro.Data
{
    public class Yonetici : Personel
    {
        private decimal _saatlikUcret=550;
        public string Kadro { get;} = "Yonetici";

        [JsonIgnore]
        public override decimal SaatlikUcret
        {
            get { return _saatlikUcret; }
            set { _saatlikUcret = value;}
        }
       //public string AdSoyad { get; set; }
        public override decimal ToplamMaasHesapla(int calismaSaati)
        {
            throw new NotImplementedException();
        }
    }
}
