using CLMaasBordro.Abstract;
using CLMaasBordro.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CLMaasBordro.Data
{
    public class Memur : Personel
    {
        private decimal _saatlikUcret;
        private decimal _ekKazanc;

        public override string Kadro { get; } = "Memur";
        [JsonIgnore]
        public decimal EkKazanc
        {
            get { return _ekKazanc; }
        }

        public MemurDerecesi MemurunDerecesi { get; set; }
        [JsonIgnore]
        public override decimal SaatlikUcret
        {
            get
            {
                switch (MemurunDerecesi)
                {
                    case MemurDerecesi.UstKidemli:
                        return 570;
                    case MemurDerecesi.Kidemli:
                        return 550;
                    case MemurDerecesi.OrtaKidemli:
                        return 530;
                    case MemurDerecesi.Deneyimli:
                        return 515;
                    case MemurDerecesi.YeniBaslayan:
                        return 500;
                    default:
                        return 0;
                }
            }
            set
            {
                _saatlikUcret = value;
            }
        }

        public override decimal ToplamMaasHesapla(uint calismaSaati)
        {
            decimal toplamMaas=0;

            if (calismaSaati <= 180)
            {
                toplamMaas = calismaSaati * _saatlikUcret;
            }
            else if (calismaSaati > 180)
            {
                _ekKazanc = ((decimal)(calismaSaati - 180) * _saatlikUcret)*1.5m;
                toplamMaas = _ekKazanc + (_saatlikUcret * 180);
            }

            return toplamMaas;
        }
    }
}
